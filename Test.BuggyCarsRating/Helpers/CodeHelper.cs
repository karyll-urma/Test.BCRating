﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Test.BuggyCarsRating.Base;
using Test.BuggyCarsRating.Contexts;

namespace Test.BuggyCarsRating.Helpers
{
    public class CodeHelper : BaseHelper
    {
        public CodeHelper(DriverContext driverContext) : base(driverContext)
        {

        }

        // Generate random string
        public string RandomString(string randType, int length)
        {
            string chars = "TEST";
            switch (randType)
            {
                case "Alphabet":
                    chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
                    break;
                case "Numeric":
                    chars = "0123456789";
                    break;
                case "AlphaNumeric":
                    chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
                    break;
                default:
                    chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
                    break;
            }

            Random random = new Random();
            return new string(Enumerable.Repeat(chars, length)
                .Select(s => s[random.Next(s.Length)]).ToArray());
        }


    }
}
