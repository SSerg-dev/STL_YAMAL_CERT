using System;
using System.Runtime.Serialization;

namespace SmartQA1._1._2.Exceptions
{
    //Рекомендации Микрософт по созданию собственных классов исключений
    //https://docs.microsoft.com/ru-ru/visualstudio/code-quality/ca1032-implement-standard-exception-constructors
    //https://docs.microsoft.com/ru-ru/dotnet/csharp/programming-guide/exceptions/creating-and-throwing-exceptions

    [Serializable()]
    public class IdempotentOperationException : Exception
    {
        /*this type of exception is thrown primarily when Idemponent operations are called twice
         * For example - mocking HttpContext in Unit test where's there'a method that clears
         * current HttpContext. When calling not completely idempotent operation that can have side-effects
         * can cause some other errors - for instance, NullReferenceException
         * */
        public IdempotentOperationException() { }

        public IdempotentOperationException(string message) : base(message) { }

        //in case we need inner exceptions:
        public IdempotentOperationException(string message, Exception innerEx) : base(message, innerEx) { }
        
        //A constructor is needed for serialization when an
        //exception propagates from a remoting server to the client.
        protected IdempotentOperationException(SerializationInfo info, StreamingContext context) : base(info, context) { }
    }
}