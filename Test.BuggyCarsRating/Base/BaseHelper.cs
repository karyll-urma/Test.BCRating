using System.Collections.Generic;
using System.Text;
using Test.BuggyCarsRating.Contexts;
using Test.BuggyCarsRating.Helpers;

namespace Test.BuggyCarsRating.Base
{
    public abstract class BaseHelper
    {
        public DriverContext _driverContext;
        //public CodeHelper _codeHelper;

        public BaseHelper(DriverContext driverContext)
        {
            _driverContext = driverContext;
            //_codeHelper = new CodeHelper(_driverContext);
        }
    }
}
