﻿using System.Linq;
using System.Web.Mvc;
using TsBlog.AutoMapperConfig;
using TsBlog.Frontend.Extensions;
using TsBlog.Services;

namespace TsBlog.Frontend.Controllers
{
    public class HomeController : Controller
    {
        /// <summary>
        /// 文章服务接口
        /// </summary>
        private readonly IPostService _postService;
        public HomeController(IPostService postService)
        {
            _postService = postService;
        }
        /// <summary>
        /// 首页
        /// </summary>
        /// <returns></returns>
        public ActionResult Index()
        {
            var list = _postService.FindHomePagePosts();
            var model = list.Select(x => x.ToModel().FormatPostViewModel());
            return View(model);
        }
    }
}