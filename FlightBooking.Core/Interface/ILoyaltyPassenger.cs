using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FlightBooking.Core.Interface
{
    interface ILoyaltyPassenger
    {
        void AddPassenger(string passengerName, string passengerAge, int loyaltyPoints, bool IsUsingLoyaltyPoints);
    }
}
