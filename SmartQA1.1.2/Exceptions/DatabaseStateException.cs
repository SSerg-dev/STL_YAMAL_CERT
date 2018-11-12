using System;
using System.Runtime.Serialization;

namespace SmartQA1._1._2.Exceptions
{
    //Рекомендации Микрософт по созданию собственных классов исключений
    //https://docs.microsoft.com/ru-ru/visualstudio/code-quality/ca1032-implement-standard-exception-constructors
    //https://docs.microsoft.com/ru-ru/dotnet/csharp/programming-guide/exceptions/creating-and-throwing-exceptions

    [Serializable()]
    public class DatabaseStateException : Exception
    {
        /*
            This type of the exception is intended to be fired when the state of the database
            doesn't corresponds Application or Developer anticipations - for example, service dictionaries
            haven't the required rows or when IIS user hasn't enough of right to execute database
            stored procedures.
            Usually this exception fires after DEV database updating by SQL developers.
        */        
        public DatabaseStateException() { }

        public DatabaseStateException(string message): base(message) { }

        //in case we need inner exceptions:
        public DatabaseStateException(string message, Exception innerEx) : base(message, innerEx) { }
        
        //A constructor is needed for serialization when an
        //exception propagates from a remoting server to the client.
        protected DatabaseStateException(SerializationInfo info, StreamingContext context) : base(info, context) { }
    }
}