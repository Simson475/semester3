using System;
using System.Collections.Generic;

namespace OOP003interfaces
{
    class MakeModelPriceComparer : IComparer<Car>
    {
        public int Compare(Car x, Car y)
        {
            int ReturnValue = String.Compare(x.Make, y.Make);
            if (ReturnValue == 0) ReturnValue = String.Compare(x.Model, y.Model);
            if (ReturnValue == 0) ReturnValue = (int)(x.Price - y.Price);
            return ReturnValue;
        }
    }
}