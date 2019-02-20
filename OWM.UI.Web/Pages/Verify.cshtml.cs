using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using OWM.Application.Services;
using OWM.Domain.Entities;
using OWM.Domain.Services.Interfaces;
using System;
using System.Linq;
using System.Text.Encodings.Web;
using System.Threading.Tasks;

namespace OWM.UI.Web.Pages
{
    public class VerificationModel : PageModel
    {
        private readonly IServiceProvider _serviceProvider;
        private readonly UserManager<UserIdentity> _userManager;
        private readonly SignInManager<UserIdentity> _signInManager;
        private readonly IUserService _userService;
        private bool _notRegistered;
        private UserIdentity _userIdentity;

        public bool DirectVisit;
        public bool emailAlreadyConfirmed;
        public bool UserNotFound;
        public string Message;

        public VerificationModel(IServiceProvider serviceProvider, UserManager<UserIdentity> userManager,
            SignInManager<UserIdentity> signInManager)
        {
            _serviceProvider = serviceProvider;
            _userManager = userManager;
            _signInManager = signInManager;

            _userService = serviceProvider.GetRequiredService<IUserService>();
        }

        public async Task<IActionResult> OnGetAsync(string userId, string code)
        {
           DirectVisit = false;
            if (userId == null || code == null)
            {
                DirectVisit = true;

                emailAlreadyConfirmed = IsEmailConfirmed(userId).Result;
                if (emailAlreadyConfirmed)
                {
                    await _signInManager.SignInAsync(_userIdentity, true);
                    RedirectToPage("/User/NewsFeed");
                }

                if (_notRegistered) return LocalRedirect("/Index");

                Message = "Your account is not verified. Please check your email to verify your account.";
                return Page();
            }

            var user = await _userManager.FindByIdAsync(userId);
            if (user == null)
            {
                UserNotFound = true;
                Message = "Unable to find user.";
                return Page();
            }
            UserNotFound = false;

            var result = await _userManager.ConfirmEmailAsync(user, code);
            emailAlreadyConfirmed = result.Succeeded;
            Message = !emailAlreadyConfirmed
                ? "Error confirming email"
                : "Your account has been successfully verified.";

            return Page();
        }

        public async Task<IActionResult> OnPostAsync([FromQuery] string userId)
        {
            var user = _userService.Queryable().Include(x => x.Identity)
                .FirstOrDefault(x => x.Identity.Id.Equals(userId));
            if (user == null)
            {
                DirectVisit = false;
                UserNotFound = true;
                Message = "Unable to find user.";
                return Page();
            }

            SendVerificationEmail(user.Identity, user.Name);
            return LocalRedirect("/Verify");
        }

        private void SendVerificationEmail(UserIdentity identity, string name)
        {
            var code = _userManager.GenerateEmailConfirmationTokenAsync(identity).Result;
            var callbackUrl = Url.Page(
                "/Verify",
                pageHandler: null,
                values: new { userId = identity.Id, code = code },
                protocol: Request.Scheme);
            string encodedUrl = HtmlEncoder.Default.Encode(callbackUrl);
            var hostingEnv = _serviceProvider.GetRequiredService<IHostingEnvironment>();

            VerificationEmailSender emailSender = new VerificationEmailSender(hostingEnv, name, identity.Email, encodedUrl);
            emailSender.Send();
        }

        private async Task<bool> IsEmailConfirmed(string id)
        {
            _userIdentity = await _userManager.FindByIdAsync(id);
            if (_userIdentity == null)
            {
                _notRegistered = true;
                return false;
            }

            _notRegistered = false;
            return await _userManager.IsEmailConfirmedAsync(_userIdentity);
        }
    }
}