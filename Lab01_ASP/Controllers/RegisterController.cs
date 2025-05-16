using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Lab01_ASP.Controllers
{
    public class RegisterController : Controller
    {
        private IWebHostEnvironment hosting;
        public RegisterController(IWebHostEnvironment _hosting)
        {
            hosting = _hosting;
        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult XuLy(Models.PersonViewModel m, IFormFile FHinh)
        {
            if (FHinh != null)
            {
                string filename = Guid.NewGuid().ToString() + Path.GetExtension(FHinh.FileName);
                string path = Path.Combine(hosting.WebRootPath, "images");
                using (var filestream = new FileStream(Path.Combine(path, filename), FileMode.Create))
                {
                    FHinh.CopyTo(filestream);
                }
                m.Picture = filename;
            }
            return View(m);
        }
    }
}
