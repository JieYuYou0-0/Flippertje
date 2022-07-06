using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Text.Json;

namespace GhibliFlix
{

    public class Translator
    {
        public En en { get; set; }
    }

    public abstract class Language
    {
        public string Continue { get; set; }
        public string Dear { get; set; }

        public string EmailReservationConfirmation { get; set; }
        public string EmailAccountVerification { get; set; }
        public string EmailCancelReservation { get; set; }


        #region Guest Menu
        public string Greet { get; set; }
        public string GuestMenuTitle { get; set; }
        public string GuestMenuLogin { get; set; }
        public string GuestMenuRegister { get; set; }
        //public string GuestMenuReview { get; set; }
        public string PromptCreateReservation { get; set; }
        public string MembershipLogin { get; set; }
        public string InvalidMembershipCode { get; set; }
        #endregion

        #region Admin Menu
        public string AdminMenu { get; set; }
        public string AdminAnotherDate { get; set; }
        public string ChangeMenu { get; set; }
        public string ChangeMovie1 { get; set; }
        public string Movie1Changed { get; set; }
        public string ChangeTitle { get; set; }
        public string ChangeDescription { get; set; }
        public string ChangePrice { get; set; }
        public string ChangeDuration { get; set; }
        public string ChangeMovie2 { get; set; }
        public string Movie2Changed { get; set; }
        public string ChangeMovie3 { get; set; }
        public string Movie3Changed { get; set; }
        public string ChangeMovie4 { get; set; }
        public string Movie4Changed { get; set; }
        public string ChangeMovie5 { get; set; }
        public string Movie5Changed { get; set; }
        public string ChangeMovie6 { get; set; }
        public string Movie6Changed { get; set; }
        public string ChangeMovie7 { get; set; }
        public string Movie7Changed { get; set; }
        public string ChangeMovie8 { get; set; }
        public string Movie8Changed { get; set; }


        public string InvalidOption { get; set; }
        public string AdminMenuChoices { get; set; }
        #endregion

        #region Membership Menu
        public string MembershipMenuGreet { get; set; }
        public string MembershipMenuTitle { get; set; }
        public string MembershipCreateReservation { get; set; }
        public string MembershipCancelReservation { get; set; }
        public string MembershipLookup { get; set; }
        public string MembershipCreateReview { get; set; }
        public string MembershipOverview { get; set; }
        public string MembershipCreated { get; set; }
        public string EnterFullName { get; set; }
        public string EnterEmail { get; set; }
        public string EnterCreditcard { get; set; }
        public string VerificationCodeSend { get; set; }
        public string EnteredWrongCode { get; set; }
        #endregion

        #region Create Reservation
        public string ReservationMenuGreet { get; set; }
        public string AskForGuests { get; set; }
        public string GuestAdded { get; set; }
        public string EnterGuestMail { get; set; }
        //public string EnterGuestAllergies { get; set; }
        public string EnterDate { get; set; }
        public string SelectMovie { get; set; }
        //public string EnterCalories { get; set; }
        public string InvalidDate { get; set; }
        public string DateAtCapacity { get; set; }
        public string DateIsMonday { get; set; }
        public string DateIsUnavailable { get; set; }
        public string ConfirmSuggestedDate { get; set; }
        public string NotifySeatNumber { get; set; }
        public string NoYes { get; set; }
        public string AskMovieChoice { get; set; }
        public string ReservationDate { get; set; }
        public string SeatNumber { get; set; }
        public string DateOfCreation { get; set; }
        public string Guests { get; set; }
        public string Name { get; set; }
        public string MovieChoice { get; set; }
        public string TotalCost { get; set; }
        #endregion

        public string AskVerificationCode { get; set; }
        public string VerificationCodeWrong { get; set; }
        public string CancelReservation { get; set; }
        public string ReservationCancelOptions { get; set; }
        public string InvalidInput { get; set; }
        public string CancelTooLate { get; set; }
        public string ReservationCanceled { get; set; }
        public string ReservationChanged { get; set; }
    }

    public class En : Language
    {

    }

}
