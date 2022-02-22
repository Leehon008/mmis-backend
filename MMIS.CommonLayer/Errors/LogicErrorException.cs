using System;
using MMIS.CommonLayer.Errors.Contracts;


namespace MMIS.CommonLayer.Errors
{
    public class LogicErrorException : Exception, ICustomException
    {
        public LogicErrorException(string message) : base(message) { }
        public LogicErrorException(string message, Exception innerException) : base(message, innerException) { }
    }
}
