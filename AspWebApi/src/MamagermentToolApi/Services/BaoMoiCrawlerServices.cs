using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using MamagermentToolApi.Dtos;
using MamagermentToolApi.Utils;
using Newtonsoft.Json;

namespace MamagermentToolApi.Services
{
    /// <summary>
    /// Crwaler data from site BaoMoi.com
    /// </summary>
    public class BaoMoiCrawlerServices
    {
        /// <summary>
        /// Get list feed news
        /// </summary>
        /// <param name="page">number of page, use for paging</param>
        /// <returns></returns>
        public string GetFeed(string page)
        {
            string result;
            List<FeedDTO> resultDTOs = new List<FeedDTO>();
            /*Using Regex to parse html*/
            MatchCollection collectionItem;
            /*Get Html document*/
            string linkRequest = Constant.baoMoiFeedUrl.Replace(Constant.replaceUrlBaoMoi, page);
            string htmDocument = Crawler.getResponse(linkRequest);
            //Get feed from HTML
            collectionItem = Utils.RegexHandle.Matches(Utils.Constant.patternFeedBaoMoi, htmDocument);
            FeedDTO item;
            foreach (Match matchItem in collectionItem)
            {
                item = new FeedDTO();
                item.href = Constant.baoMoiHost + matchItem.Groups[1].Value;
                item.title = matchItem.Groups[2].Value;
                item.imageUrl = matchItem.Groups[3].Value;
                item.source = matchItem.Groups[4].Value;
                item.dateTime = matchItem.Groups[5].Value;
                item.shortDescription = matchItem.Groups[6].Value;
                resultDTOs.Add(item);
            }
            result = JsonConvert.SerializeObject(resultDTOs);
            return result;
        }
    }
}
