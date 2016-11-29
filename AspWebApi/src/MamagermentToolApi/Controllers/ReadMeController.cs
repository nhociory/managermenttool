using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace MamagermentToolApi.Controllers
{
    [Route("api/[controller]")]
    public class ReadMeController : Controller
    {
        // GET api/ReadMe
        [HttpGet]
        public string Get()
        {
            return "Created by Võ Trọng Nghĩa";
        }

    }
}
