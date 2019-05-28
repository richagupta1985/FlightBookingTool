using System;
using System.Collections.Generic;
using System.Linq;

namespace FlightBooking.Core.Model
{
    public class LoyaltyMemberPassenger : Loyalty
    {
        #region "Constructor"
        public LoyaltyMemberPassenger(string passengerInput)
        {
            ValidatePassengerInput(passengerInput, Constants.LOYALTYPASSENGERREGEX);
            if (IsUserInputValid)
            {
                base.EPassengerSelection = EPassengerSelection.LoyaltyMemberPassenger;
                List<string> passengerData = passengerInput.Split(' ').ToList();
                AddPassenger(passengerData[0], passengerData[1], Convert.ToInt32(passengerData[2]), Convert.ToBoolean(passengerData[3]));
            }
        }
        #endregion
        #region"Methods"
        public override void AddPassenger(string passengerName, string passengerAge, int loyaltyPoints, bool isUsingLoyaltyPoints)
        {
            this.Name = passengerName;
            this.Age = Convert.ToInt16(passengerAge);
            this.IsUsingLoyaltyPoints = isUsingLoyaltyPoints;
            this.LoyaltyPoints = loyaltyPoints;
        }
        public override Double BasePriceMultiplier()
        {
            if (IsUsingLoyaltyPoints)
                return 0;
            else
                return 1;
        }
        public override int GetBaggage()
        {
            return 2;
        }
        #endregion
    }
}
