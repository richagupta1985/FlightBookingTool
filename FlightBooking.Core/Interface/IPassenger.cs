using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FlightBooking.Core.Interface
{
    interface IPassenger
    {
        void ValidatePassengerInput(string passengerInput, string regularExpression);
        double BasePriceMultiplier();
        void AddPassenger(string PassengerName, string passengerAge);
        int GetBaggage();
    }
}
