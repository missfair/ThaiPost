using Microsoft.AspNetCore.Http;
using ThaiPost.ExceptionBase;

namespace ThaiPost.Validation
{
    public static class Validation
    {
        public static void CheckAuthorization(this HttpRequest request)
        {
            var authorization = request.Headers["Authorization"];
            if (!authorization.Equals("Bearer keyxxx"))
            {
                throw new ValidationException("Token ไม่ถูกต้อง");
            }
        }
    }
}
