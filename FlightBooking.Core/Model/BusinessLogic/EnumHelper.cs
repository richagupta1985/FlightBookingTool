using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text.RegularExpressions;

namespace FlightBooking.Core.BusinessLogic
{
    public static class EnumHelper
    {
        /// <summary>
        /// Return Enum value depending upon description
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="userInput"></param>
        /// <returns></returns>
        public static KeyValuePair<string,T> GetEnumValue<T>(string userInput) where T : IConvertible
        {
            if (!string.IsNullOrEmpty(userInput))
            {
                Type type = typeof(T);
                Array values = System.Enum.GetValues(type);

                foreach (int val in values)
                {
                    var memInfo = type.GetMember(type.GetEnumName(val));
                    var descriptionAttribute = memInfo[0]
                        .GetCustomAttributes(typeof(DescriptionAttribute), false)
                        .FirstOrDefault() as DescriptionAttribute;

                    if (descriptionAttribute != null && descriptionAttribute.Description != null && userInput.StartsWith(descriptionAttribute.Description))
                    {
                        return new KeyValuePair<string, T>(descriptionAttribute.Description, (T)Enum.Parse(typeof(T), memInfo[0].Name));
                    }
                }
            }
            throw new ArgumentException();
        }
        /// <summary>
        /// Return yes if string matches with given regex format else will return false
        /// </summary>
        /// <param name="input"></param>
        /// <param name="regularExpression"></param>
        /// <returns></returns>
        public static bool MatchRegularExpression(string input,string regularExpression)
        {
            bool isvalid = Regex.IsMatch(input, regularExpression);
            return isvalid;
        }
    }
}
