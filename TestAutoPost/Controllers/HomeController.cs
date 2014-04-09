using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TestAutoPost.DAL;
using TestAutoPost.Models;

namespace TestAutoPost.Controllers
{
    public class HomeController : Controller
    {
        //
        // GET: /Home/\
        
        public ActionResult Index()
        {
            //if (!Request.IsAuthenticated)
            //{
            //    return RedirectToAction("Login", "User");
            //}

            return View();
        }
    }
}
