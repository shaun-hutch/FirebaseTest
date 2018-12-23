using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace FirebaseTest.Controllers
{
    [ApiController]
    public class MessageController : Controller
    {
        private static readonly HttpClient client = new HttpClient();

        [HttpGet]
        [Route("message")]
        public JsonResult Index()
        {
            return new JsonResult(new { test = "test" });
        }

        [Route("message/call")]
        public JsonResult Call()
        {

            var notification = new Dictionary<string, string>()
            {
                { "title" ,  "Portugal vs. Denmark" },
                { "body", "5 to 1" },
                { "icon", "firebase-logo.png" },
                { "click_action", "http://localhost:8081" }
            };


            return new JsonResult(new { notification });

        }
    }
}
