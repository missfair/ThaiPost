namespace ThaiPost.ExceptionBase
{
    public class ResponseException
    {
        public string errorCode { get; set; }
        public string errorMessage { get; set; }
        public object errorMessageObject { get; set; }
    }
}
