using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MamagermentToolApi.Dtos
{

    /// <summary>
    /// Object DTO of feed crawler from BaoMoi.com
    /// </summary>
    public class FeedDTO
    {
        public string title { get; set; }
        public string href { get; set; }
        public string imageUrl { get; set; }
        public string source { get; set; }
        public string dateTime { get; set; }
        public string shortDescription { get; set; }
    }
}
