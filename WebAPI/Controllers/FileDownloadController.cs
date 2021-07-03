using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.IO;
using Microsoft.AspNetCore.Hosting.Server.Features;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Hosting;
namespace WebAPI.Controllers
{
    public class FileDownloadController : Controller
    {
        private IHostingEnvironment Environment;
          public FileDownloadController(IHostingEnvironment _environment)
        {
            Environment = _environment;
        }
        public async Task<ActionResult> Index()
        {
            string filename = HttpContext.Request.Query["fn"].ToString();
            var path = this.Environment.WebRootPath;
            var path2 = Path.Combine(path, "musics");
            var filePath = Path.Combine(path2, filename);
            var bytes = await System.IO.File.ReadAllBytesAsync(filePath);
            return File(bytes, "text/plain", Path.GetFileName(filePath));
        }
      
        //public async Task<ActionResult> DownloadFile()
        //{
        //    string filename = HttpContext.Request.Query["fn"].ToString();
        //    var path = this.Environment.WebRootPath;
        //    var path2 = Path.Combine(path, "musics");
        //    var filePath = Path.Combine(path2, filename);
        //    var bytes = await System.IO.File.ReadAllBytesAsync(filePath);
        //    return File(bytes, "text/plain", Path.GetFileName(filePath));
        //}
    }
}