using System;
using System.Collections.Generic;
using System.Text;
using Test.BuggyCarsRating.Contexts;

namespace Test.BuggyCarsRating.Base
{
    public abstract class BaseHelper
    {
        public DriverContext _driverContext;

        public BaseHelper(DriverContext driverContext)
        {
            _driverContext = driverContext;
        }
    }
}
