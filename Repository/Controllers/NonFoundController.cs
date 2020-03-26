using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Repository.Controllers
{
    public class NonFoundController : Controller
    {
        // GET: NonFound
        public ActionResult NotFound()
        {
            var result = new FilePathResult("~/Static/Pages/NotFound.html", "text/html");
            return result;
        }
    }
}