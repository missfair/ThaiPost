using Microsoft.AspNetCore.Mvc;
using ThaiPost.Models;
using ThaiPost.Services;
using ThaiPost.Validation;
using static ThaiPost.Models.HookData;

namespace ThaiPost.Controllers
{
    public class ThaiPostController : Controller
    {
        public ThaiPostController()
        {
        }

        [HttpPost("api/thai-post/items")]
        public ItemsRessponse GetItems([FromBody] ItemsRequest request)
        {
            var response = new ThaiPostServices().GetItems(request);
            return response;
        }

        [HttpPost("api/thai-post/hook-track")]
        public HooktrackResponse PostHooktrack(HooktrackRequest request)
        {
            var response = new ThaiPostServices().PostHookTrack(request);
            return response;
        }

        [HttpPost("api/thai-post/hook-data")]
        public HookDataRequest PostHookData([FromBody] HookDataRequest request)
        {
            Request.CheckAuthorization();

            //เอา URL : api/thai-post/hook-data นี้ไปใส่ใน หน้า dashboard ของ https://track.thailandpost.co.th/dashboard# เวลาเค้ายิงกลับมาจะได้เข้า path นี้
            //เวลาสถานะวัสดุเปลี่ยนเค้าจะยิง request นี่มาบอกสถานะ

            return request;
        }
    }
}
