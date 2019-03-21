﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using OWM.Data;

namespace OWM.Data.Migrations
{
    [DbContext(typeof(OwmContext))]
    partial class OwmContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.1-servicing-10028")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("OWM.Domain.Entities.City", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("CountryId");

                    b.Property<int>("CustomCityId");

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.HasIndex("CountryId");

                    b.ToTable("Cities");
                });

            modelBuilder.Entity("OWM.Domain.Entities.CompletedMiles", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("Created");

                    b.Property<float>("Miles");

                    b.Property<DateTime>("Modified");

                    b.Property<int?>("PledgedMileId");

                    b.HasKey("Id");

                    b.HasIndex("PledgedMileId");

                    b.ToTable("CompletedMiles");
                });

            modelBuilder.Entity("OWM.Domain.Entities.Country", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.ToTable("Countries");
                });

            modelBuilder.Entity("OWM.Domain.Entities.Ethnicity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name");

                    b.Property<int>("Order");

                    b.HasKey("Id");

                    b.ToTable("Ethnicities");
                });

            modelBuilder.Entity("OWM.Domain.Entities.Interest", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name");

                    b.Property<int?>("ProfileId");

                    b.HasKey("Id");

                    b.HasIndex("ProfileId");

                    b.ToTable("Interests");
                });

            modelBuilder.Entity("OWM.Domain.Entities.Message", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("BoardId");

                    b.Property<DateTime>("Created");

                    b.Property<int?>("FromId");

                    b.Property<DateTime>("Modified");

                    b.Property<int?>("ReplyToMessageId");

                    b.Property<string>("Text");

                    b.HasKey("Id");

                    b.HasIndex("BoardId");

                    b.HasIndex("FromId");

                    b.HasIndex("ReplyToMessageId");

                    b.ToTable("Messages");
                });

            modelBuilder.Entity("OWM.Domain.Entities.MessageBoard", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("Created");

                    b.Property<DateTime>("Modified");

                    b.Property<int>("TeamId");

                    b.HasKey("Id");

                    b.HasIndex("TeamId")
                        .IsUnique();

                    b.ToTable("MessageBoards");
                });

            modelBuilder.Entity("OWM.Domain.Entities.MilesPledged", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("Created");

                    b.Property<float>("Miles");

                    b.Property<DateTime>("Modified");

                    b.Property<int?>("ProfileId");

                    b.Property<int?>("TeamId");

                    b.HasKey("Id");

                    b.HasIndex("ProfileId");

                    b.HasIndex("TeamId");

                    b.ToTable("MilesPledged");
                });

            modelBuilder.Entity("OWM.Domain.Entities.Occupation", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name");

                    b.Property<int>("Order");

                    b.HasKey("Id");

                    b.ToTable("Occupations");
                });

            modelBuilder.Entity("OWM.Domain.Entities.Participant", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("BoardId");

                    b.Property<DateTime>("Created");

                    b.Property<DateTime>("LastReadTimeStamp");

                    b.Property<DateTime>("Modified");

                    b.Property<int?>("ProfileId");

                    b.HasKey("Id");

                    b.HasIndex("BoardId");

                    b.HasIndex("ProfileId");

                    b.ToTable("Participants");
                });

            modelBuilder.Entity("OWM.Domain.Entities.Profile", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("CityId");

                    b.Property<int?>("CountryId");

                    b.Property<DateTime>("Created");

                    b.Property<DateTime>("DateOfBirth");

                    b.Property<int?>("EthnicityId");

                    b.Property<int>("Gender");

                    b.Property<string>("HowDidYouHearUs");

                    b.Property<string>("IdentityId");

                    b.Property<DateTime>("Modified");

                    b.Property<string>("Name");

                    b.Property<int?>("OccupationId");

                    b.Property<string>("ProfileImageUrl");

                    b.Property<string>("Surname");

                    b.HasKey("Id");

                    b.HasIndex("CityId");

                    b.HasIndex("CountryId");

                    b.HasIndex("EthnicityId");

                    b.HasIndex("IdentityId");

                    b.HasIndex("OccupationId");

                    b.ToTable("Profiles");
                });

            modelBuilder.Entity("OWM.Domain.Entities.Role", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ConcurrencyStamp");

                    b.Property<string>("Name");

                    b.Property<string>("NormalizedName");

                    b.HasKey("Id");

                    b.ToTable("Roles");
                });

            modelBuilder.Entity("OWM.Domain.Entities.RoleClaim", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<string>("RoleId");

                    b.HasKey("Id");

                    b.ToTable("RoleClaims");
                });

            modelBuilder.Entity("OWM.Domain.Entities.Team", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("AgeRange");

                    b.Property<DateTime>("Created");

                    b.Property<Guid>("Identity");

                    b.Property<bool>("IsClosed");

                    b.Property<DateTime>("Modified");

                    b.Property<string>("Name");

                    b.Property<bool>("OccupationFilter");

                    b.Property<string>("ShortDescription");

                    b.HasKey("Id");

                    b.ToTable("Teams");
                });

            modelBuilder.Entity("OWM.Domain.Entities.TeamInvitation", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("Created");

                    b.Property<Guid>("InvitationGuid");

                    b.Property<DateTime>("Modified");

                    b.Property<bool>("Read");

                    b.Property<string>("RecipientEmailAddress");

                    b.Property<int?>("RecipientProfileId");

                    b.Property<int>("SenderProfileId");

                    b.Property<Guid>("TeamGuid");

                    b.HasKey("Id");

                    b.ToTable("TeamInvitations");
                });

            modelBuilder.Entity("OWM.Domain.Entities.TeamMember", b =>
                {
                    b.Property<int>("TeamId");

                    b.Property<int>("ProfileId");

                    b.Property<DateTime>("Created");

                    b.Property<bool>("IsCreator");

                    b.Property<bool>("KickedOut");

                    b.Property<DateTime>("Modified");

                    b.HasKey("TeamId", "ProfileId");

                    b.HasIndex("ProfileId");

                    b.ToTable("TeamMembers");
                });

            modelBuilder.Entity("OWM.Domain.Entities.TeamOccupations", b =>
                {
                    b.Property<int>("TeamId");

                    b.Property<int>("OccupationId");

                    b.Property<DateTime>("Created");

                    b.Property<DateTime>("Modified");

                    b.HasKey("TeamId", "OccupationId");

                    b.HasIndex("OccupationId");

                    b.ToTable("TeamOccupations");
                });

            modelBuilder.Entity("OWM.Domain.Entities.User", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("AccessFailedCount");

                    b.Property<string>("ConcurrencyStamp");

                    b.Property<string>("Email");

                    b.Property<bool>("EmailConfirmed");

                    b.Property<bool>("LockoutEnabled");

                    b.Property<DateTimeOffset?>("LockoutEnd");

                    b.Property<string>("NormalizedEmail");

                    b.Property<string>("NormalizedUserName");

                    b.Property<string>("PasswordHash");

                    b.Property<string>("PhoneNumber");

                    b.Property<bool>("PhoneNumberConfirmed");

                    b.Property<string>("SecurityStamp");

                    b.Property<bool>("TwoFactorEnabled");

                    b.Property<string>("UserName");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("OWM.Domain.Entities.UserClaim", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<string>("UserId");

                    b.HasKey("Id");

                    b.ToTable("UserClaims");
                });

            modelBuilder.Entity("OWM.Domain.Entities.UserLogin", b =>
                {
                    b.Property<string>("LoginProvider");

                    b.Property<string>("ProviderKey");

                    b.Property<string>("ProviderDisplayName");

                    b.Property<string>("UserId");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.ToTable("UserLogins");
                });

            modelBuilder.Entity("OWM.Domain.Entities.UserRole", b =>
                {
                    b.Property<string>("UserId");

                    b.Property<string>("RoleId");

                    b.HasKey("UserId", "RoleId");

                    b.ToTable("UserRoles");
                });

            modelBuilder.Entity("OWM.Domain.Entities.UserToken", b =>
                {
                    b.Property<string>("UserId");

                    b.Property<string>("LoginProvider");

                    b.Property<string>("Name");

                    b.Property<string>("Value");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("UserTokens");
                });

            modelBuilder.Entity("OWM.Domain.Entities.City", b =>
                {
                    b.HasOne("OWM.Domain.Entities.Country", "Country")
                        .WithMany()
                        .HasForeignKey("CountryId");
                });

            modelBuilder.Entity("OWM.Domain.Entities.CompletedMiles", b =>
                {
                    b.HasOne("OWM.Domain.Entities.MilesPledged", "PledgedMile")
                        .WithMany("CompletedMiles")
                        .HasForeignKey("PledgedMileId");
                });

            modelBuilder.Entity("OWM.Domain.Entities.Interest", b =>
                {
                    b.HasOne("OWM.Domain.Entities.Profile")
                        .WithMany("Interests")
                        .HasForeignKey("ProfileId");
                });

            modelBuilder.Entity("OWM.Domain.Entities.Message", b =>
                {
                    b.HasOne("OWM.Domain.Entities.MessageBoard", "Board")
                        .WithMany("Messages")
                        .HasForeignKey("BoardId");

                    b.HasOne("OWM.Domain.Entities.Participant", "From")
                        .WithMany()
                        .HasForeignKey("FromId");

                    b.HasOne("OWM.Domain.Entities.Message", "ReplyToMessage")
                        .WithMany()
                        .HasForeignKey("ReplyToMessageId");
                });

            modelBuilder.Entity("OWM.Domain.Entities.MessageBoard", b =>
                {
                    b.HasOne("OWM.Domain.Entities.Team", "ForTeam")
                        .WithOne("Board")
                        .HasForeignKey("OWM.Domain.Entities.MessageBoard", "TeamId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("OWM.Domain.Entities.MilesPledged", b =>
                {
                    b.HasOne("OWM.Domain.Entities.Profile", "Profile")
                        .WithMany("MilesPledged")
                        .HasForeignKey("ProfileId");

                    b.HasOne("OWM.Domain.Entities.Team", "Team")
                        .WithMany("PledgedMiles")
                        .HasForeignKey("TeamId");
                });

            modelBuilder.Entity("OWM.Domain.Entities.Participant", b =>
                {
                    b.HasOne("OWM.Domain.Entities.MessageBoard", "Board")
                        .WithMany("Participants")
                        .HasForeignKey("BoardId");

                    b.HasOne("OWM.Domain.Entities.Profile", "Profile")
                        .WithMany()
                        .HasForeignKey("ProfileId");
                });

            modelBuilder.Entity("OWM.Domain.Entities.Profile", b =>
                {
                    b.HasOne("OWM.Domain.Entities.City", "City")
                        .WithMany()
                        .HasForeignKey("CityId");

                    b.HasOne("OWM.Domain.Entities.Country", "Country")
                        .WithMany()
                        .HasForeignKey("CountryId");

                    b.HasOne("OWM.Domain.Entities.Ethnicity", "Ethnicity")
                        .WithMany()
                        .HasForeignKey("EthnicityId");

                    b.HasOne("OWM.Domain.Entities.User", "Identity")
                        .WithMany()
                        .HasForeignKey("IdentityId");

                    b.HasOne("OWM.Domain.Entities.Occupation", "Occupation")
                        .WithMany()
                        .HasForeignKey("OccupationId");
                });

            modelBuilder.Entity("OWM.Domain.Entities.TeamMember", b =>
                {
                    b.HasOne("OWM.Domain.Entities.Profile", "MemberProfile")
                        .WithMany("Teams")
                        .HasForeignKey("ProfileId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("OWM.Domain.Entities.Team", "Team")
                        .WithMany("Members")
                        .HasForeignKey("TeamId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("OWM.Domain.Entities.TeamOccupations", b =>
                {
                    b.HasOne("OWM.Domain.Entities.Occupation", "Occupation")
                        .WithMany("InTeams")
                        .HasForeignKey("OccupationId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("OWM.Domain.Entities.Team", "Team")
                        .WithMany("AllowedOccupations")
                        .HasForeignKey("TeamId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
