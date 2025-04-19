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

        //POST: pmo/HandleForm
        [HttpPost]
        public IActionResult HandleForm(int id, string name)
        {
            // Process the form data
            ViewData["ID"] = id;
            ViewData["Name"] = name;

            return View("Welcome");

        }

        // GET: pmo/Welcome
        [HttpGet]
        public IActionResult Welcome()
        {
            
            return View();
        }   
    }   
}
