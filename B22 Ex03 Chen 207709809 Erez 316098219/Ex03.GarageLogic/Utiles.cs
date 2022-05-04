using System;
using System.Collections.Generic;

namespace Ex03.GarageLogic
{
    public static class Utiles
    {
        public delegate bool TryParse<Type>(string i_FromString, out Type o_ToType);

        public static void ConvertAndSetFromStringToType<Type>(string i_FromString, out Type o_ToType, TryParse<Type> i_TryParseMethod)
        {
            bool isParseSuccssed = i_TryParseMethod(i_FromString, out o_ToType);

            if (!isParseSuccssed)
            {
                throw new FormatException("Error: Invalid input inserted! please try again.");
            }
        }

        public static Dictionary<string, string> ConcatDictionaries(Dictionary<string, string> i_FirstDictionary, Dictionary<string, string> i_SecondDictionary)
        {
            Dictionary<string, string> dictionaryDestantaion = new Dictionary<string, string>();

            foreach (KeyValuePair<string, string> details in i_FirstDictionary)
            {
                dictionaryDestantaion.Add(details.Key, details.Value);
            }

            foreach (KeyValuePair<string, string> details in i_SecondDictionary)
            {
                dictionaryDestantaion.Add(details.Key, details.Value);
            }

            return dictionaryDestantaion;
        }
    }
}
