using System;

namespace ThaiPost.ExceptionBase
{
    public class BaseException : Exception
    {
        public string code { get; set; }
        public string message { get; set; }
        public object messageObject { get; set; }
        public BaseException(string code, string message)
        {
            this.code = code;
            this.message = message;
        }

        public BaseException(string code, object message)
        {
            this.code = code;
            this.messageObject = message;
        }
    }
}
