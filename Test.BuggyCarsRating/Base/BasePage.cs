using System;
using System.Collections.Generic;
using System.Text;
using Test.BuggyCarsRating.Contexts;
using Test.BuggyCarsRating.Helpers;

namespace Test.BuggyCarsRating.Base
{
    public abstract class BasePage
    {
        public DriverContext _driverContext;
        public CustomControlHelper _customControlHelper;
        public CodeHelper _codeHelper;
        public BasePage(DriverContext driverContext)
        {
            _driverContext = driverContext;
            _customControlHelper = new CustomControlHelper(_driverContext);
            _codeHelper = new CodeHelper(_driverContext);
        }
    }
}
