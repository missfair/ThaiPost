using System.Collections.Generic;

namespace ThaiPost.Models
{
    #region Request
    public class ItemsRequest
    {
        public string status { get; set; }
        public string language { get; set; }
        public List<string> barcode { get; set; }
    }
    #endregion


    public class ItemsRessponse
    {
        public Response response { get; set; }
        public string message { get; set; }
        public bool status { get; set; }
    }

    public class Response
    {
        public Items items { get; set; }
        public Track_Count track_count { get; set; }
    }

    public class Items
    {
        public List<ItemDetail> itemDetail { get; set; }
    }

    public class ItemDetail
    {
        public string barcode { get; set; }
        public string status { get; set; }
        public string status_description { get; set; }
        public string status_date { get; set; }
        public string location { get; set; }
        public string postcode { get; set; }
        public string delivery_status { get; set; }
        public string delivery_description { get; set; }
        public string delivery_datetime { get; set; }
        public string receiver_name { get; set; }
        public string signature { get; set; }
    }

    public class Track_Count
    {
        public string track_date { get; set; }
        public int count_number { get; set; }
        public int track_count_limit { get; set; }
    }

}
