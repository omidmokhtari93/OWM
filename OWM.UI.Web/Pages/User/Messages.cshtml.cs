using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using OWM.Application.Services.Dtos;
using OWM.Application.Services.Interfaces;

namespace OWM.UI.Web.Pages.User
{
    [Authorize]
    public class MessagesModel : PageModel
    {
        private readonly SignInManager<Domain.Entities.User> _signInManager;
        private readonly UserManager<Domain.Entities.User> _userManager;
        private readonly IUserInformationService _userInformation;
        private readonly ITeamMessageBoardService _msgBoardService;
        private int _profileId;
        private bool _canAccessBoard;

        public MessagesModel(ITeamMessageBoardService msgBoardService
            , SignInManager<Domain.Entities.User> signInManager
            , UserManager<Domain.Entities.User> userManager
            , IUserInformationService userInformation)
        {
            _msgBoardService = msgBoardService;
            _signInManager = signInManager;
            _userManager = userManager;
            _userInformation = userInformation;
        }


        public bool EmptyState { get; set; }
        public List<MessageDto> BoardMessages { get; set; }
        public List<TeamBoardsDto> TeamBoards { get; set; }


        [BindProperty(SupportsGet = true)] public int BoardId { get; set; }
        [BindProperty] public string MessageText { get; set; }

        public async Task OnGetAsync()
        {
            EmptyState = true;
            await InitializePage();
        }

        public async Task<IActionResult> OnGetBoardAsync()
        {
            EmptyState = false;
            await InitializePage();
            if (!_canAccessBoard) return NotFound();

            BoardMessages = await _msgBoardService.GetMessagesInBoard(BoardId);
            await _msgBoardService.UpdateParticipantReadCheck(_profileId, BoardId);
            return Page();
        }

        public async Task<IActionResult> OnPostBoardAsync()
        {
            await InitializePage();
            if (!_canAccessBoard) return NotFound();
            if (!string.IsNullOrEmpty(MessageText) && BoardId != default(int))
            {
                string identityId = _signInManager.UserManager.GetUserId(User);
                int profileId = await _userInformation.GetUserProfileIdAsync(identityId);

                await _msgBoardService.PostMessage(profileId, BoardId, MessageText);
                await _msgBoardService.UpdateParticipantReadCheck(_profileId, BoardId);
            }

            BoardMessages = await _msgBoardService.GetMessagesInBoard(BoardId);
            return Page();
        }


        private async Task InitializePage()
        {
            string identityId = _signInManager.UserManager.GetUserId(User);
            _profileId = await _userInformation.GetUserProfileIdAsync(identityId);

            TeamBoards = _msgBoardService.GetAllTeamBoards(_profileId);
            if (BoardId != default(int))
                _canAccessBoard = await _msgBoardService.CanAccessBoard(_profileId, BoardId);
        }
    }
}