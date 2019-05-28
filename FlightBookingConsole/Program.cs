using FlightBooking.Core;
using FlightBooking.Core.BusinessLogic;
using System;
using System.Collections.Generic;

namespace FlightBookingProblem
{
    class Program
    {
        static void Main(string[] args)
        {
            string userInput = string.Empty;
            FlightBookingViewModel flightBookingViewModel = new FlightBookingViewModel();
            UpdateConsoleToChooseOptions();
            do
            {
                userInput = Console.ReadLine() ?? "";
                try
                {
                    flightBookingViewModel.AnalysePassengerInput(userInput);
                    if (flightBookingViewModel.IsPrintRequired)
                        UpdateConsoleForInvalidInput(flightBookingViewModel.PrintText.ToString(), flightBookingViewModel.PrintTextColor);
                }
                catch (Exception )
                {
                    UpdateConsoleForInvalidInput(Constants.UNKOWNINPUT, ConsoleColor.Red);
                }
            } while (userInput != EPassengerSelection.Exit.ToString());

        }
        /// <summary>
        /// Update console to chosse options
        /// </summary>
        private static void UpdateConsoleToChooseOptions()
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine(Constants.CHOOSEOPTIONS);
            Console.WriteLine(Constants.ADDGENERAL);
            Console.WriteLine(Constants.ADDLOYALTY);
            Console.WriteLine(Constants.ADDAIRLINE);
            Console.WriteLine(Constants.ADDDISCOUNTED);
            Console.WriteLine(Constants.PRINTSUMMARY);
            Console.WriteLine(Constants.EXIT);
        }
        /// <summary>
        /// Update console for invalid input
        /// </summary>
        /// <param name="text"></param>
        /// <param name="color"></param>
        public static void UpdateConsoleForInvalidInput(string text, ConsoleColor color)
        {
            Console.ForegroundColor = color;
            Console.WriteLine(text);
            Console.ResetColor();
        }
    }
}