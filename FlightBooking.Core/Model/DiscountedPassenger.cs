using System;
using System.Collections.Generic;
using System.Linq;

namespace FlightBooking.Core.Model
{
    public class DiscountedPassenger : Loyalty
    {
        #region "Constructor"
        public DiscountedPassenger(string passengerInput)
        {
            ValidatePassengerInput(passengerInput, Constants.GENERALPASSENGERREGEX);
            if (IsUserInputValid)
            {
                base.EPassengerSelection = EPassengerSelection.DiscountedPassenger;
                List<string> passengerData = passengerInput.Split(' ').ToList();
                AddPassenger(passengerData[0], passengerData[1]);
            }
        }
        #endregion
        #region "Methods"
        public override double BasePriceMultiplier()
        {
            return 0.5;
        }
        public override void AddPassenger(string PassengerName, string passengerAge)
        {
            this.Name = PassengerName;
            this.Age = Convert.ToInt16(passengerAge);
        }
        public override int GetBaggage()
        {
            return 0;
        }
        #endregion
    }
}
