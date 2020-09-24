using System;
using System.Collections.Generic;

namespace OOP003interfaces
{
    class ModelReversePriceComparer : IComparer<Car>
    {
        public int Compare(Car x, Car y)
        {
            int ReturnValue = String.Compare(x.Model, y.Model);
            if (ReturnValue == 0) ReturnValue = (int)(y.Price - x.Price);
            return ReturnValue;
        }
    }
}