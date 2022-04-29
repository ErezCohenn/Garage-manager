using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ex03.GarageLogic
{
    public enum eCarColors
    {
        Red,
        White,
        Green,
        Blue,
    }
    public class Car
    {
        private readonly eCarColors r_carColor;
        private readonly int r_numberOfDoors;
    }
}
