using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GhibliFlix.jsonClasses;
using GhibliFlix.menus;

namespace GhibliFlix
{
    internal class Settings
    {
        public string Continue { get; set; }

        // Mail
        public string EmailReservationConfirmation { get; set; }
        public string EmailAccVerification { get; set; }
        public string EmailCancelReservation { get; set; }

        // MenuOverview
        public string Greet { get; set; }
        public string GuestMenuTitle { get; set; }
        public string GuestMenuLogin { get; set; }
        public string GuestMenuRegister { get; set; }
        public string MembershipLogin { get; set; }
        public string InvalidMembershipCode { get; set; }
        public string PromptCreateReservation { get; set; }

        // MembershipMenu
        public string MembershipMenuGreet { get; set; }
        public string MembershipMenuTitle { get; set; }
        public string MembershipCreateReservation { get; set; }
        public string MembershipCancelReservation { get; set; }
        public string MembershipOverview { get; set; }
        public string MembershipCreated { get; set; }
        public string EnterFullName { get; set; }
        public string EnterEmail { get; set; }
        public string EnterCreditcard { get; set; }
        public string VerificationCodeSend { get; set; }
        public string EnteredWrongCode { get; set; }

        // Create reservation
        public string ReservationMenuGreet { get; set; }
        public string AskForGuests { get; set; }
        public string GuestAdded { get; set; }
        public string EnterGuestMail { get; set; }
        public string EnterDate { get; set; }
        public string InvalidDate { get; set; }
        public string ConfirmSuggestedDate { get; set; }
        public string NotifySeatNumber { get; set; }
        public string ReservationDate { get; set; }
        public string SeatNumber { get; set; }
        public string DateOfCreation { get; set; }
        public string Price { get; set; }
        public string Guests { get; set; }
        public string Name { get; set; }

    }
}
