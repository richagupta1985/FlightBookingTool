using System;
using System.ComponentModel;

namespace FlightBooking.Core
{
    public static class Constants
    {
        public static string FLIGHTSUMMARY = "Flight summary for";
        public static string TOTALPASSENGERS = "Total passengers:";
        public static string GENERALSALES = "General sales:";
        public static string LOYALTYMMEMBERSALES = "Loyalty member sales:";
        public static string AIRLINEEMPLOYEECOMPS = "Airline employee comps:";
        public static string DISCOUNTEDSALES = "Discounted Sales:";
        public static string TOTALBAGGAGE = "Total expected baggage:";
        public static string TOTALFLIGHTREVENUE = "Total revenue from flight: ";
        public static string TOTALFLIGHTCOST = "Total costs from flight:";
        public static string FLIGHTPROFIT = "Flight generating profit of:";
        public static string FLIGHTLOOSE = "FLIGHT MAY NOT PROCEED";
        public static string TOTALLOYALTYGIVEN = "Total loyalty points given away:";
        public static string TOTALLOYALTYREDEEM = "Total loyalty points redeemed:";
        public static string FLIGHTPROCEED = "THIS FLIGHT MAY PROCEED";
        public static string CHOOSEOPTIONS = "Please choose from below options";
        public static string ADDGENERAL = "1. Add General(Format: General [Name] [Age])";
        public static string ADDLOYALTY = "2. Add Loyalty(Format: Loyalty [Name] [Age] [Loyalty Points] [IsUsingLoyaltyPoints(True/False)])";
        public static string ADDAIRLINE = "3. Airline (Format: Loyalty [Name] [Age])";
        public static string ADDDISCOUNTED = "4. Discounted (Format: Loyalty [Name] [Age])";
        public static string EXIT = "Exit";
        public static string PRINTSUMMARY = "Print Summary";
        public static string CONTINUE = "Press Any Key to Continue";
        public static string UNKOWNINPUT = "UNKNOWN INPUT";
        public static string GENERALPASSENGERREGEX = @"^+[a-zA-Z]*\s[0-9]*$";
        public static string LOYALTYPASSENGERREGEX = @"^+[a-zA-Z]*\s[0-9]*\s[0-9]*\strue|false$";
        public static string NEWLINE = Environment.NewLine;
        public static string VERTICALWHITESPACE = Environment.NewLine + Environment.NewLine;
        public static string PRINTSUMMARYFORMAT = "{0} {1}{2}";
        public static string PRINTSUMMARYFORMATWITHTAB = "    {0} {1}{2}";
        public static string PRINTSUMMARYFORMAT2 = "{0} {1}{2}{3}";
        public static string NODATAFORSUMMARY = "No data to display. Please add passenger details first";
        public static string MODELWORD = ".Model.";
        public static string OTHERSUITABLEFLIGHT = "Other more suitable aircraft are:";
        public static string BOMBARDIERFLIGHT = "Bombardier Q400 could handle this flight.";
        public static string ATRFLIGHT = "ATR 640 could handle this flight.";
    }

    public enum EPassengerSelection
    {
        [Description("ADD GENERAL")]
        GeneralPassenger = 0,
        [Description("ADD LOYALTY")]
        LoyaltyMemberPassenger = 1,
        [Description("ADD AIRLINE")]
        AirlineEmployeePassenger = 2,
        [Description("ADD DISCOUNTED")]
        DiscountedPassenger = 3,
        [Description("EXIT")]
        Exit =4,
        [Description("PRINT SUMMARY")]
        PrintSummary=5
    }

}
