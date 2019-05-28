using FlightBooking.Core.Model;
using System;
using System.Collections.Generic;

namespace FlightBooking.Core.BusinessLogic
{
    public class FlightBookingViewModel
    {
        #region "Private Varaibles"
        private PrintSummary _printSummary;
        private KeyValuePair<string, EPassengerSelection> _passengerInput;

        #endregion
        #region "Public Properties"
        public string PrintText { get; set; }
        public bool IsPrintRequired { get; set; }
        public ConsoleColor PrintTextColor { get; set; }
        public Passenger Passenger { get; set; }
        public ScheduledFlight ScheduledFlight { get; set; }
        #endregion
        #region "Constructor"
        public FlightBookingViewModel()
        {
            ScheduledFlight = new ScheduledFlight();
        }
        #endregion
        #region "Methods"
        /// <summary>
        /// Analyse passenger input
        /// </summary>
        /// <param name="userInput"></param>
        public void AnalysePassengerInput(string userInput)
        {
            _passengerInput = EnumHelper.GetEnumValue<EPassengerSelection>(userInput.Trim().ToLower().ToUpper());
            var _passengerData = userInput.Remove(0, _passengerInput.Key.Length).Trim();
            AddPassenger(_passengerInput.Value, _passengerData);
        }
        /// <summary>
        /// Check if the passenger data is in valid format and add passenger to the system
        /// </summary>
        /// <param name="passengerSelection"></param>
        /// <param name="passengerData"></param>
        public void AddPassenger(EPassengerSelection passengerSelection, string passengerData)
        {
            switch (passengerSelection)
            {
                case EPassengerSelection.AirlineEmployeePassenger:
                case EPassengerSelection.DiscountedPassenger:
                case EPassengerSelection.GeneralPassenger:
                case EPassengerSelection.LoyaltyMemberPassenger:
                    CreatePassenger(passengerSelection, passengerData);

                    break;
                case EPassengerSelection.PrintSummary:
                    PrintFlightSummary();
                    break;
                case EPassengerSelection.Exit:
                    Environment.Exit(1);
                    break;
            }
        }
      
        /// <summary>
        /// Create Flight Summary 
        /// </summary>
        private void PrintFlightSummary()
        {
            if (_printSummary == null)
            {
                _printSummary = new PrintSummary(ScheduledFlight);
                PrintTextForConsole(_printSummary.FlightSummary.ToString(), ConsoleColor.Cyan, true);
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="passengerSelection"></param>
        /// <param name="passengerData"></param>
        private void CreatePassenger(EPassengerSelection passengerSelection, string passengerData)
        {
            object passengerInstance = GetPassengerClassBasedOnPassengerType(passengerSelection, passengerData);
            AddPassengerBasedOnSelection(passengerInstance);
        }
        /// <summary>
        /// Get passenger class instance based on passenger type
        /// </summary>
        /// <param name="passengerSelection"></param>
        /// <param name="passengerData"></param>
        /// <returns></returns>
        public object GetPassengerClassBasedOnPassengerType(EPassengerSelection passengerSelection, string passengerData)
        {
            string currentAssemblyName = this.GetType().Assembly.GetName().Name.ToString();
            object passengerInstance = GetInstance(currentAssemblyName + Constants.MODELWORD + passengerSelection.ToString(), passengerData);
            return passengerInstance;
        }
        /// <summary>
        ///  Add passenger based on user selection
        /// </summary>
        /// <param name="passenger"></param>
        private void AddPassengerBasedOnSelection(object passengerInstance)
        {
            Passenger = passengerInstance != null ? (Passenger)passengerInstance : null;
            if (Passenger != null && Passenger.IsUserInputValid)
            {
                ScheduledFlight.AddPassenger(Passenger);
                PrintText = "";
                _printSummary = null;
            }
            else
                PrintTextForConsole(Constants.UNKOWNINPUT, ConsoleColor.Red, true);
        }
        private void PrintTextForConsole(string text, ConsoleColor color, bool isPrintRequired)
        {
            PrintText = text;
            PrintTextColor = color;
            IsPrintRequired = isPrintRequired;
        }
        /// <summary>
        /// Method will create the class instance based on passenger type selection
        /// </summary>
        /// <param name="strFullyQualifiedName"></param>
        /// <param name="passengerData"></param>
        /// <returns></returns>
        private object GetInstance(string strFullyQualifiedName, string passengerData)
        {
            if (!string.IsNullOrEmpty(strFullyQualifiedName))
            {
                Type type = Type.GetType(strFullyQualifiedName);
                if (type != null)
                    return Activator.CreateInstance(type, passengerData);
            }
            return null;
        }
        #endregion
    }
}
