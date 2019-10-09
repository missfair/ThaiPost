namespace ThaiPost.ExceptionBase
{
    public class ValidationException : BaseException
    {
        public ValidationException(string message) : base("000002", message)
        {
        }

        public ValidationException(object message) : base("000002", message)
        {
        }
    }
}
