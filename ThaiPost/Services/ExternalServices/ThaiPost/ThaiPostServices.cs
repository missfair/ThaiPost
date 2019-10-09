using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Net;
using ThaiPost.Models;
using static ThaiPost.Models.HookData;

namespace ThaiPost.Services
{
    public class ThaiPostServices
    {
        private string _token;
        private DateTime _expireDate;
        public ThaiPostServices()
        {
            GetToken();
        }

        private void GetToken()
        {
            if (DateTime.Now >= _expireDate)
            {
                WebClient webc = new WebClient();
                webc.Headers["Content-Type"] = "application/json";
                webc.Headers["Authorization"] = "Token " + @"AHJvD8B+K5MDVQTaLDAPBgJMQ=A1NLBHG0XSHwH_Z&S/KkVlP:H8AqE?G/BUSLA!V8VXS2FmPPG_MhGDWoD-L:MqJJHwA0DWS^UP";
                string url = @"https://trackapi.thailandpost.co.th/post/api/v1/authenticate/token";
                string response = webc.UploadString(url, "POST");
                var tokenReponse = JsonConvert.DeserializeObject<TokenResponse>(response);
                _token = tokenReponse.token;
                _expireDate = string.IsNullOrEmpty(tokenReponse.expire) ? DateTime.Now.Date : Convert.ToDateTime(tokenReponse.expire);
            }

        }

        public ItemsRessponse GetItems(ItemsRequest request)
        {
            WebClient webc = new WebClient();
            webc.Headers["Content-Type"] = "application/json";
            webc.Headers["Authorization"] = "Token " + _token;
            string url = @"https://trackapi.thailandpost.co.th/post/api/v1/track";
            string jsonRequest = JsonConvert.SerializeObject(request);
            string jsonResult = webc.UploadString(url, "POST", jsonRequest);
            var itemResponse = MapItems(jsonResult, request.barcode);
            return itemResponse;
        }

        public ItemsRessponse MapItems(string json, List<string> barcodes)
        {
            var result = new List<ItemDetail>();
            JObject jObject = JObject.Parse(json);
            JToken jResponse = jObject["response"];
            JToken jItems = jResponse["items"];
            foreach (var barcode in barcodes)
            {
                JToken jItemDetail = jItems[barcode];
                var itemDetails = jItemDetail.ToObject<List<ItemDetail>>();
                result.AddRange(itemDetails);
            }
            var trackModel = JsonConvert.DeserializeObject<ItemsRessponse>(json);
            trackModel.response.items.itemDetail = result;
            return trackModel;
        }


        public HooktrackResponse PostHookTrack(HooktrackRequest request) 
        {
            WebClient webc = new WebClient();
            webc.Headers["Content-Type"] = "application/json";
            webc.Headers["Authorization"] = "Token " + _token;
            string url = @"https://trackwebhook.thailandpost.co.th/post/api/v1/hook";
            string jsonRequest = JsonConvert.SerializeObject(request);
            string jsonResult = webc.UploadString(url, "POST", jsonRequest);
            var hookTrackResponse = JsonConvert.DeserializeObject<HooktrackResponse>(jsonResult);
            return hookTrackResponse;

        }




    }
}
