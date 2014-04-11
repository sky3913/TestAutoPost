using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TestAutoPost.DAL;
using TestAutoPost.Helper;
using TestAutoPost.Models;

namespace TestAutoPost.Controllers
{
    public class HomeController : Controller
    {
        //
        // GET: /Home/\
        
        public ActionResult Index()
        {
            if (!Request.IsAuthenticated)
            {
                return RedirectToAction("Login", "User");
            }

            return View();
        }

        [HttpPost]
        public ActionResult Index(Post post)
        {
            User user = (User)Session["user"];
            PostMessage.Send(user.UserName, user.Password, post.MessageTitle + post.MessageBody);
            return View();
        }
    }
}
