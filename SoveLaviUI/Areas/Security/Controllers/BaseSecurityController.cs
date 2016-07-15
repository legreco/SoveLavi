using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SoveLaviUI.Areas.Security.Controllers
{
    public class BaseSecurityController : Controller
    {
        // GET: Security/BaseSecurity
        public ActionResult Index()
        {
            return View();
        }
    }
}