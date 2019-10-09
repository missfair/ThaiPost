namespace ThaiPost.ExceptionBase
{
    public class NotFoundException : BaseException
    {
        public NotFoundException() : base("000001", "Data Not Found")
        {
        }
        public NotFoundException(string message) : base("000001", message)
        {
        }
    }
}
