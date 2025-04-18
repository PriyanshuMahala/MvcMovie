using Microsoft.AspNetCore.Mvc;
using System.Text.Encodings.Web;
using System.Xml.Linq;

namespace MvcMovie.Controllers
{
    public class pmoController : Controller
    {
        // GET: pmo
        public IActionResult Index()
        {
            return View();
        }

        // GET: pmo/Welcome
        public IActionResult Welcome(string name, int ID = 1)
        {
            ViewData["Message"] = "Hello " +  name;
            ViewData["ID"] = ID;
            return View();
        }
    }   
}
