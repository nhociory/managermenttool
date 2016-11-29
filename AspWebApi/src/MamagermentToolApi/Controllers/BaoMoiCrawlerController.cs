using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MamagermentToolApi.Services;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace MamagermentToolApi.Controllers
{
    [Route("api/[controller]")]
    public class BaoMoiCrawlerController : Controller
    {
        BaoMoiCrawlerServices services = new BaoMoiCrawlerServices();
        // GET api/BaoMoiCrawler/1
        [HttpGet("{page}")]
        public string GetFeed(string page)
        {
            string result;
            result = services.GetFeed(page);
            return result;
        }
    }
}
