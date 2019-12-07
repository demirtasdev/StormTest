using SPTechnicalTest.DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SPTechnicalTest.Controllers
{
    public class HomeController : Controller
    {
        public readonly StormContext db = new StormContext();

        public ActionResult Index()
        {
            var users = db.Users.Where(u => u.Name == "Joe Bloggs" || u.Name == "Jane Doe" || u.Name == "Bob James").ToList();
            var startDate = DateTime.Parse("14/10/2019");
            var endDate = DateTime.Parse("20/10/2019");

            var indexVMList = users.GetWeeklyReports(startDate, endDate, db);

            return View(indexVMList);
        }
    }
}