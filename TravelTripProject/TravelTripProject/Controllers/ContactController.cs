using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TravelTripProject.Models.Sınıflar;

namespace TravelTripProject.Controllers
{
    public class ContactController : Controller
    {
        // GET: Contact
        Context c = new Context();

        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }  
        
        [HttpPost]
        public ActionResult Index(Iletisim il)
        {
            c.Iletisims.Add(il);
            c.SaveChanges();
            return RedirectToAction("Index");
        }
        
       
    }
}