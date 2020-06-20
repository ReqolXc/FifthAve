using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MySm.Models;
using MySm.Models.Feed;

namespace MySm.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public class her
        {
            public string imageLink { get; set; }
            public string name { get; set; }
            public string homeLink { get; set; }
            public string nickname { get; set; }
            public int friendsNumber { get; set; }
            public int postsNumber { get; set; }
        }

        [Route("/me")]
        [HttpGet]
        public her a()
        {
            HttpContext.Response.Headers.Add("Access-Control-Allow-Origin", "*");

            var a = new her
            {
                name = "Dmitry Bym",
                imageLink =
                    "https://innogun.ru/shop/wp-content/uploads/2019/07/MERKEL-DocterSight_52-DS-900-600x376.jpg",
                friendsNumber = 10,
                homeLink = "https://github.com/dmitry-bym",
                nickname = "dmitry_bym",
                postsNumber = 30
            };

            return a;
        }

        [Route("")]
        public IActionResult Index()
        {
            var model = new FeedViewModel
            {
                posts = new List<FeedPostViewModel>
                {
                    new FeedPostViewModel
                    {
                        StarsFromYou = StarsNumber.Zero,
                        StarsNumber = 30,
                        PostedTextPart ="wowowov bfbkgfbkcgbmkcvb bcbcvbbc",
                        PostedDate = "2009.10.15",
                        UserAvatarUri = "ZG5d2UAlwU8.jpg",
                        CommentsNumber = 13,
                        UserNickname = "@dmitry",
                        PostedAgo = "12h",
                        PostUri = "#",
                        MainPostImageUri = "ZG5d2UAlwU8.jpg",
                        PostHeader = "Header"
                        
                    },
                    new FeedPostViewModel
                    {
                        StarsFromYou = StarsNumber.One,
                        StarsNumber = 30,
                        PostedTextPart ="wowowov bfbkgfbkcgbmkcvb bcbcvbbc",
                        PostedDate = "2009.10.15",
                        UserAvatarUri = "ZG5d2UAlwU8.jpg",
                        CommentsNumber = 13,
                        UserNickname = "@dmitry",
                        PostedAgo = "12h",
                        PostUri = "#",
                        MainPostImageUri = "ZG5d2UAlwU8.jpg",
                        PostHeader = "Header"
                    },
                    new FeedPostViewModel
                    {
                        StarsFromYou = StarsNumber.Two,
                        StarsNumber = 30,
                        PostedTextPart ="wowowov bfbkgfbkcgbmkcvb bcbcvbbc",
                        PostedDate = "2009.10.15",
                        UserAvatarUri = "ZG5d2UAlwU8.jpg",
                        CommentsNumber = 13,
                        UserNickname = "@dmitry",
                        PostedAgo = "12h",
                        PostUri = "#",
                        MainPostImageUri = "ZG5d2UAlwU8.jpg",
                        PostHeader = "Header"
                    }
                }
            };
            return View(model);
        }
    }
}
