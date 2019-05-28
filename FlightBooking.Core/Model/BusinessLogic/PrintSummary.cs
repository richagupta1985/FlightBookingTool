using System.Linq;
using System.Text;

namespace FlightBooking.Core.Model
{
    public class PrintSummary
    {
        #region "Private Varaibles"
        private ScheduledFlight _scheduledFlight;
        private FlightCosting _flightCosting;
        #endregion
        #region "Public Properties"
        public StringBuilder FlightSummary
        { get; set; }
        #endregion
        #region "Constructor"
        public PrintSummary(ScheduledFlight scheduledFlight)
        {
            this._scheduledFlight = scheduledFlight;
            PrintFlightSummary();
        }
        #endregion
        #region "Methods"
        /// <summary>
        /// Print Flight Summary
        /// </summary>
        public void PrintFlightSummary()
        {
            FlightSummary = new StringBuilder();
            if (!_scheduledFlight.Passengers.Any())
                FlightSummary.AppendFormat("{0}", Constants.NODATAFORSUMMARY);
            else
            {
                _flightCosting = _scheduledFlight.FlightCosting;
                if (_flightCosting != null)
                {
                    TotalPassengersSummary();
                    FlightCalculationsSummary();
                    FlightProceedOrLooseSummary();
                }
            }
        }
        /// <summary>
        /// Print passengers count summary
        /// </summary>
        private void TotalPassengersSummary()
        {
            StringFormat(Constants.PRINTSUMMARYFORMAT, Constants.FLIGHTSUMMARY, _scheduledFlight.FlightRoute.Title, Constants.VERTICALWHITESPACE);
            StringFormat(Constants.PRINTSUMMARYFORMAT, Constants.TOTALPASSENGERS, _flightCosting.SeatsTaken.ToString(), Constants.NEWLINE);
            StringFormat(Constants.PRINTSUMMARYFORMATWITHTAB, Constants.GENERALSALES, _flightCosting.GeneralPassengers.Count().ToString(), Constants.NEWLINE);
            StringFormat(Constants.PRINTSUMMARYFORMATWITHTAB, Constants.LOYALTYMMEMBERSALES, _flightCosting.LoyaltyPassengers.Count().ToString(), Constants.NEWLINE);
            StringFormat(Constants.PRINTSUMMARYFORMATWITHTAB, Constants.AIRLINEEMPLOYEECOMPS, _flightCosting.AirlineEmployeePassengers.Count().ToString(), Constants.NEWLINE);
            StringFormat(Constants.PRINTSUMMARYFORMATWITHTAB, Constants.DISCOUNTEDSALES, _flightCosting.DiscountedPassengers.Count().ToString(), Constants.VERTICALWHITESPACE);
        }
        /// <summary>
        /// Print flight calculation summary
        /// </summary>
        private void FlightCalculationsSummary()
        {
            StringFormat(Constants.PRINTSUMMARYFORMAT, Constants.TOTALBAGGAGE, _flightCosting.TotalExpectedBaggage.ToString(), Constants.VERTICALWHITESPACE);
            StringFormat(Constants.PRINTSUMMARYFORMAT, Constants.TOTALFLIGHTREVENUE, _flightCosting.ProfitFromFlight.HasValue ? _flightCosting.ProfitFromFlight.Value.ToString() : "0", Constants.NEWLINE);
            StringFormat(Constants.PRINTSUMMARYFORMAT, Constants.TOTALFLIGHTCOST, _flightCosting.CostOfFlight.ToString(), Constants.NEWLINE);
            StringFormat(Constants.PRINTSUMMARYFORMAT, _flightCosting.ProfitSurplus > 0 ? Constants.FLIGHTPROFIT : Constants.FLIGHTLOOSE, _flightCosting.ProfitSurplus.HasValue ? _flightCosting.ProfitSurplus.Value.ToString() : "0", Constants.VERTICALWHITESPACE);
            StringFormat(Constants.PRINTSUMMARYFORMAT, Constants.TOTALLOYALTYGIVEN, _flightCosting.TotalLoyaltyPointsAccrued.ToString(), Constants.NEWLINE);
            StringFormat(Constants.PRINTSUMMARYFORMAT, Constants.TOTALLOYALTYREDEEM, _flightCosting.TotalLoyaltyPointsRedeemed.ToString(), Constants.VERTICALWHITESPACE);

        }
        /// <summary>
        /// Check if flight can proceed or not based upon some business rules
        /// </summary>
        /// <returns></returns>
        public bool CanFlightProceed()
        {
            return (((_flightCosting.AirlineEmployeePassengers.Count() / (double)_scheduledFlight.Aircraft.NumberOfSeats > _scheduledFlight.FlightRoute.MinimumTakeOffPercentage)
                          || _flightCosting.ProfitSurplus > 0)
             && _flightCosting.SeatsTaken < _scheduledFlight.Aircraft.NumberOfSeats
             && _flightCosting.SeatsTaken / (double)_scheduledFlight.Aircraft.NumberOfSeats > _scheduledFlight.FlightRoute.MinimumTakeOffPercentage);

        }
        /// <summary>
        /// print summary based on if flight will proceed or not
        /// </summary>
        public void FlightProceedOrLooseSummary()
        {
            if (CanFlightProceed())
                FlightSummary.AppendFormat("{0}", Constants.FLIGHTPROCEED);
            else
            {
                FlightSummary.AppendFormat("{0}{1}", Constants.FLIGHTLOOSE, Constants.VERTICALWHITESPACE);

                if (_flightCosting.SeatsTaken > _scheduledFlight.Aircraft.NumberOfSeats)
                {
                    FlightSummary.AppendFormat("{0}{1}", Constants.OTHERSUITABLEFLIGHT, Constants.VERTICALWHITESPACE);
                    FlightSummary.AppendFormat("{0}{1}", Constants.BOMBARDIERFLIGHT, Constants.VERTICALWHITESPACE);
                    FlightSummary.AppendFormat("{0}{1}", Constants.ATRFLIGHT, Constants.VERTICALWHITESPACE);
                }
            }
        }
        private void StringFormat(string format, string text1, string text2, string text3)
        {
            FlightSummary.AppendFormat(format, text1, text2, text3);
        }
        #endregion
    }
}
