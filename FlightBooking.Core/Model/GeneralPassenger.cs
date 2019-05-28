using System;
using System.Collections.Generic;
using System.Linq;

namespace FlightBooking.Core.Model
{
    public class GeneralPassenger : Passenger
    {
        #region "Constructor"
        public GeneralPassenger(string passengerInput)
        {
            ValidatePassengerInput(passengerInput, Constants.GENERALPASSENGERREGEX);
            if (IsUserInputValid)
            {
                base.EPassengerSelection = EPassengerSelection.GeneralPassenger;
                List<string> passengerData = passengerInput.Split(' ').ToList();
                AddPassenger(passengerData[0], passengerData[1]);
            }
        }
        #endregion
        #region"Methods"
        public override void AddPassenger(string PassengerName, string passengerAge)
        {
            this.Name = PassengerName;
            this.Age = Convert.ToInt16(passengerAge);
        }
        #endregion
    }
}
