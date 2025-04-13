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
        public string Welcome(string name, int ID = 1)
        {
            return HtmlEncoder.Default.Encode($"Hello {name}, NumTimes is: {ID}");
        }
    }   
}
