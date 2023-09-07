using Microsoft.AspNetCore.Mvc;
using mvcApp.Models;
using System.Diagnostics;
using System.IO;
namespace mvcApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            Info info = new Info();
            return View(info);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Index(Info info)
        {
            if(info.file != null)
            {
                if(info.file.FileName.Substring(info.file.FileName.LastIndexOf('.')+1,3)!="txt")
                {
                    info.text = "you should upload a .txt file";
                }else
                {
                    //read the file
                    var reader = new StreamReader(info.file.OpenReadStream());
                    string contents = reader.ReadToEnd();
                    // return value of file
                    info.text = contents;
                }
            }
            return View(info);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}