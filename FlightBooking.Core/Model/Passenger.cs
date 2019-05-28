using FlightBooking.Core.BusinessLogic;
using FlightBooking.Core.Interface;

namespace FlightBooking.Core
{
    public class Passenger : IPassenger
    {
        #region "Public Properties"
        public int Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public bool IsUserInputValid { get; set; }
        //public double BasePriceMutiplier { get; set; }
        public EPassengerSelection EPassengerSelection { get; set; }
        #endregion
        #region "Constructor"
        public Passenger()
        {
            //BasePriceMutiplier = 1;
        }
        #endregion
        #region"Methods"
        public virtual void UpdateBasePriceMultiplier() { }
        public virtual void ValidatePassengerInput(string passengerInput, string regularExpression)
        {
            IsUserInputValid = !string.IsNullOrWhiteSpace(passengerInput) ? EnumHelper.MatchRegularExpression(passengerInput, regularExpression) : false;
        }
        public virtual void AddPassenger(string PassengerName, string passengerAge) { }
        public virtual double BasePriceMultiplier()
        {
            return 1;
        }
        public virtual int GetBaggage()
        {
            return 1;
        }
        #endregion
    }
    public class Loyalty : Passenger, ILoyaltyPassenger
    {
        public int LoyaltyPoints { get; set; }
        public bool IsUsingLoyaltyPoints { get; set; }
        public virtual void AddPassenger(string passengerName, string passengerAge, int loyaltyPoints, bool IsUsingLoyaltyPoints) { }
    }
}
