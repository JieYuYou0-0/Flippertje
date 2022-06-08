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
        internal string Continue { get; set; }

        // Mail
        internal string EmailReservationConfirmation { get; set; }
        internal string EmailAccVerification { get; set; }
        internal string EmailCancelReservation { get; set; }

        // MenuOverview
        internal string Greet { get; set; }
        internal string GuestMenuTitle { get; set; }
        internal string GuestMenuLogin { get; set; }
        internal string GuestMenuRegister { get; set; }
        internal string MembershipLogin { get; set; }
        internal string InvalidMembershipCode { get; set; }
        internal string PromptCreateReservation { get; set; }

        // MembershipMenu
        internal string MembershipMenuGreet { get; set; }
        internal string MembershipMenuTitle { get; set; }
        internal string MembershipCreateReservation { get; set; }
        internal string MembershipCancelReservation { get; set; }
        internal string MembershipOverview { get; set; }
        internal string MembershipCreated { get; set; }
        internal string EnterFullName { get; set; }
        internal string EnterEmail { get; set; }
        internal string EnterCreditcard { get; set; }
        internal string VerificationCodeSend { get; set; }
        internal string EnteredWrongCode { get; set; }
        internal string CancelReservation { get; set; }
        internal string AskVerificationCode { get; set; }


        // Create reservation
        internal string ReservationMenuGreet { get; set; }
        internal string AskForGuests { get; set; }
        internal string GuestAdded { get; set; }
        internal string EnterGuestMail { get; set; }
        internal string EnterDate { get; set; }
        internal string InvalidDate { get; set; }
        internal string InvalidInput { get; set; }
        internal string CancelTooLate { get; set; }
        internal string ConfirmSuggestedDate { get; set; }
        internal string NotifySeatNumber { get; set; }
        internal string ReservationDate { get; set; }
        internal string SeatNumber { get; set; }
        internal string DateOfCreation { get; set; }
        internal string ReservationCanceled { get; set; }
        internal string NamesToRemove { get; set; }
        internal string ReservationChanged { get; set; }
        internal string EmailCancelRes { get; set; }

        internal string ReservationCancelOptions { get; set; }
        internal string Price { get; set; }
        internal string Guests { get; set; }
        internal string Name { get; set; }

    }
}
