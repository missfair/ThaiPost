using System.Collections.Generic;

namespace ThaiPost.Models
{
    public class HooktrackRequest
    {
        public string status { get; set; }
        public string language { get; set; }
        public List<string> barcode { get; set; }
    }

    public class HooktrackResponse
    {
        public ResponseHookTrack response { get; set; }
        public string message { get; set; }
        public string status { get; set; }
    }

    public class ResponseHookTrack
    {
        public List<Item> items { get; set; }
        public TrackCount trackCount { get; set; }
    }

    public class Item
    {
        public string barcode { get; set; }
        public bool status { get; set; }
    }

    public class TrackCount
    {
        public string trackDate { get; set; }
        public string countNumber { get; set; }
        public string trackCountLimit { get; set; }
    }
}
