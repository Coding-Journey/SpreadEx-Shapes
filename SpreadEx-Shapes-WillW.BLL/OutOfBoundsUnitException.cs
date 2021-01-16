using System;

namespace SpreadEx_Shapes_WillW.BLL
{
    [Serializable]
    public class OutOfBoundsUnitException : Exception
    {
        public OutOfBoundsUnitException() : base() { }
        public OutOfBoundsUnitException(string message) : base(message) { }
    }
}
