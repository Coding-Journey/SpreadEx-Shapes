using System;

namespace SpreadEx_Shapes_WillW.BLL
{
    [Serializable]
    class NegativeUnitException : Exception
    {
        public NegativeUnitException() : base() { }
        public NegativeUnitException(string message) : base(message) { }
    }
}
