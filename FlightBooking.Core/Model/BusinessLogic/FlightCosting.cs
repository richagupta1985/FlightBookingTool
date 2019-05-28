using System;
using System.Linq;
using System.Collections.Generic;
using FlightBooking.Core.Model;

namespace FlightBooking.Core
{
    public class FlightCosting
    {
        #region "Private variables"
        private ScheduledFlight _scheduledFlight;
        #endregion
        #region "Public Properties"
        public double? CostOfFlight { get; private set; }
        public double? ProfitFromFlight { get; private set; }
        public int TotalLoyaltyPointsAccrued { get; private set; }
        public int TotalLoyaltyPointsRedeemed { get; private set; }
        public int TotalExpectedBaggage { get; private set; }
        public int SeatsTaken { get; private set; }
        public double? ProfitSurplus { get; private set; }
        public List<Passenger> GeneralPassengers { get; private set; }
        public List<Passenger> AirlineEmployeePassengers { get; private set; }
        public List<Passenger> DiscountedPassengers { get; private set; }
        public List<Loyalty> LoyaltyPassengers { get; private set; }
        #endregion
        #region  "Constructor"
        public FlightCosting(ScheduledFlight scheduledFlight)
        {
            this._scheduledFlight = scheduledFlight;
            GeneralPassengers = scheduledFlight.Passengers.Where(x => x.EPassengerSelection == EPassengerSelection.GeneralPassenger).ToList();
            AirlineEmployeePassengers = scheduledFlight.Passengers.Where(x => x.EPassengerSelection == EPassengerSelection.AirlineEmployeePassenger).ToList();
            DiscountedPassengers = scheduledFlight.Passengers.Where(x => x.EPassengerSelection == EPassengerSelection.DiscountedPassenger).ToList();
            LoyaltyPassengers = scheduledFlight.Passengers.Where(x => x.EPassengerSelection == EPassengerSelection.LoyaltyMemberPassenger).Cast<Loyalty>().ToList();
            CalculateFlightData();
        }
        #endregion
        #region "Methods"
        /// <summary>
        /// Calculate all current flight related data
        /// </summary>
        public void CalculateFlightData()
        {
            if (_scheduledFlight.Passengers != null && _scheduledFlight.Passengers.Any())
            {
                CalculateProfitFromFlight();
                CalculateTotalExpectedBaggage();
                CalculateCostOfFlight();
                CalculateTotalLoyaltyPointsRedeemed();
                CalculateTotalLoyaltyPointsAccrued();
                CalculateTotalSeatTaken();
                CalculateSurplusProfit();
            }
        }
        /// <summary>
        /// Calculate flight profit
        /// </summary>
        private void CalculateProfitFromFlight()
        {
            this.ProfitFromFlight = _scheduledFlight.Passengers.Select(x => x.BasePriceMultiplier() * _scheduledFlight.FlightRoute.BasePrice).ToList().Sum();
        }
        /// <summary>
        /// Calculate total expected baggage by passengers
        /// </summary>
        private void CalculateTotalExpectedBaggage()
        {
            this.TotalExpectedBaggage = _scheduledFlight.Passengers.Select(x => x.GetBaggage()).ToList().Sum();
        }
        /// <summary>
        /// calculate flight cost
        /// </summary>
        private void CalculateCostOfFlight()
        {
            this.CostOfFlight = _scheduledFlight.FlightRoute.BaseCost * _scheduledFlight.Passengers.Count();
        }
        /// <summary>
        /// calculate total loyaly pointd redeemed by Loyalty Member passengers
        /// </summary>
        private void CalculateTotalLoyaltyPointsRedeemed()
        {
            int loyaltyPointsRedeemed = Convert.ToInt32(Math.Ceiling(_scheduledFlight.FlightRoute.BasePrice));
            var loyaltyPassengerUsingLoyaltyPoints = this.LoyaltyPassengers.Where(x => x.IsUsingLoyaltyPoints).ToList();
            if (loyaltyPassengerUsingLoyaltyPoints != null && loyaltyPassengerUsingLoyaltyPoints.Any())
                this.TotalLoyaltyPointsRedeemed = loyaltyPassengerUsingLoyaltyPoints.Count() * loyaltyPointsRedeemed;
        }
        /// <summary>
        /// calculate total loyaly pointd accrues by Loyalty Member passengers
        /// </summary>
        private void CalculateTotalLoyaltyPointsAccrued()
        {
            var loyaltyPassengerNotUsingLoyaltyPoints = this.LoyaltyPassengers.Where(x => !x.IsUsingLoyaltyPoints).ToList();
            if (loyaltyPassengerNotUsingLoyaltyPoints != null && loyaltyPassengerNotUsingLoyaltyPoints.Any())
                this.TotalLoyaltyPointsAccrued = loyaltyPassengerNotUsingLoyaltyPoints.Count() * _scheduledFlight.FlightRoute.LoyaltyPointsGained;
        }
        /// <summary>
        /// Calculate total seats taken by passengers
        /// </summary>
        private void CalculateTotalSeatTaken()
        {
            this.SeatsTaken = _scheduledFlight.Passengers.Count();
        }
        /// <summary>
        /// Calculate surplus profit
        /// </summary>
        private void CalculateSurplusProfit()
        {
            if (ProfitFromFlight.HasValue && CostOfFlight.HasValue)
                this.ProfitSurplus = ProfitFromFlight.Value - CostOfFlight.Value;
        }
        #endregion
    }
}