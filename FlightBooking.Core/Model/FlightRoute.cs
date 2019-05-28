namespace FlightBooking.Core
{
    public class FlightRoute
    {
        #region "Private variables"
        private readonly string _origin;
        private readonly string _destination;
        #endregion
        #region "Constructor"
        public FlightRoute(string origin, string destination)
        {
            _origin = origin;
            _destination = destination;
        }
        #endregion
        #region "Public Properties"
        public string Title { get { return _origin + " to " + _destination; } }
        public double BasePrice { get; set; }
        public double BaseCost { get; set; }
        public int LoyaltyPointsGained { get; set; }
        public double MinimumTakeOffPercentage { get; set; }
        #endregion
    }
}
