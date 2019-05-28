using System;
using System.Collections.Generic;
using System.Linq;

namespace FlightBooking.Core.Model
{
    public class AirlineEmployeePassenger : Passenger
    {
        public AirlineEmployeePassenger(string passengerInput)
        {
            ValidatePassengerInput(passengerInput, Constants.GENERALPASSENGERREGEX);
            if (IsUserInputValid)
            {
                base.EPassengerSelection = EPassengerSelection.AirlineEmployeePassenger;
                List<string> passengerData = passengerInput.Split(' ').ToList();
                AddPassenger(passengerData[0], passengerData[1]);
            }
        }
        public override Double BasePriceMultiplier()
        {
            return 0;
        }
        public override void AddPassenger(string PassengerName, string passengerAge)
        {
            this.Name = PassengerName;
            this.Age = Convert.ToInt16(passengerAge);
        }
    }
}
