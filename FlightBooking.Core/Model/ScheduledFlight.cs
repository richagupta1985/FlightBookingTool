using System.Collections.Generic;

namespace FlightBooking.Core.Model
{
    public class ScheduledFlight
    {
        #region "Private Variables"
        private FlightCosting _flightCosting;
        #endregion
        #region "Public Properties"
        public FlightRoute FlightRoute { get; set; }
        public Plane Aircraft { get; set; }
        public List<Passenger> Passengers { get; set; }
        public FlightCosting FlightCosting
        {
            get
            {
                if (_flightCosting == null)
                {
                    return LoadFlightCosting();
                }
                else return _flightCosting;
            }
            set
            {
                if (value == null)
                    _flightCosting = value;
            }
        }
        #endregion
        #region "Constructor"
        public ScheduledFlight()
        {
            LoadFlightRouteDetails();
            LoadPlaneDetails();
            Passengers = new List<Passenger>();
        }
        #endregion
        #region "Methods"
        /// <summary>
        /// Load Flight Route Details
        /// </summary>
        public void LoadFlightRouteDetails()
        {
            FlightRoute = new FlightRoute("London", "Paris")
            {
                BaseCost = 50,
                BasePrice = 100,
                LoyaltyPointsGained = 5,
                MinimumTakeOffPercentage = 0.7
            };

        }
        /// <summary>
        /// Load Flight Cost
        /// </summary>
        /// <returns></returns>
        public FlightCosting LoadFlightCosting()
        {
            return new FlightCosting(this);
        }
        /// <summary>
        /// Load Plane Details
        /// </summary>
        public void LoadPlaneDetails()
        {
            Aircraft = new Plane { Id = 123, Name = "Antonov AN-2", NumberOfSeats = 12 };
        }
        /// <summary>
        /// Add Passenger to list of existing passengers
        /// </summary>
        /// <param name="passenger"></param>
        public void AddPassenger(Passenger passenger)
        {
            this.Passengers.Add(passenger);
        }
        #endregion
    }
}
