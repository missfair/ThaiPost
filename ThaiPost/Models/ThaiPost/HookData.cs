using System.Collections.Generic;

namespace ThaiPost.Models
{
    public class HookData
    {
        public class HookDataRequest
        {
            public List<Item> items { get; set; }
            public string track_datetime { get; set; }
        }

        public class Item
        {
            public string barcode { get; set; }
            public string status { get; set; }
            public string status_description { get; set; }
            public string status_date { get; set; }
            public string location { get; set; }
            public string postcode { get; set; }
            public object delivery_status { get; set; }
            public object delivery_description { get; set; }
            public object delivery_datetime { get; set; }
            public object receiver_name { get; set; }
            public object signature { get; set; }
        }


    }
}
