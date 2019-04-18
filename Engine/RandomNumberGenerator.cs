using System;
using System.Security.Cryptography;

namespace Engine
{
    public static class RandomNumberGenerator
    {
        private static readonly RNGCryptoServiceProvider _generator = new RNGCryptoServiceProvider();

        public static int NumberBetween(int minimumValue, int maximumValue)
        {
            byte[] randomNumber = new byte[1];

            _generator.GetBytes(randomNumber);

            double asciiValueRandomCharacter = Convert.ToDouble(randomNumber[0]);

            double multiplier = Math.Max(0, (asciiValueRandomCharacter / 255d) - 0.00000000001d);

            int range = maximumValue - minimumValue + 1;

            double randomValueInRange = Math.Floor(multiplier * range);

            return (int) (minimumValue + randomValueInRange);
        }

/*        // Simple version, with less randomness.
        //
        // If you want to use this version, 
        // you can delete (or comment out) the NumberBetween function above,
        // and rename this from SimpleNumberBetween to NumberBetween
        private static readonly Random _simpleGenerator = new Random();

        public static int SimpleNumberBetween(int minimumValue, int maximumValue)
        {
            return _simpleGenerator.Next(minimumValue, maximumValue + 1);#2#
        }*/
    }
}