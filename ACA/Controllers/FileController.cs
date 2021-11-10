using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace DemoUpFiles.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FileController : ControllerBase
    {
        [HttpPost("uploadfile")]
        public async Task<IActionResult> UploadImage()
        {
            HttpRequest req = HttpContext.Request;
            Guid id = new Guid();
            string fileName = id + req.Form.Files[0].FileName;

            //crée le dossier si inexistant
            if (!Directory.Exists("upfile")) Directory.CreateDirectory("upfile");

            string filePath = Path.Combine(Directory.GetCurrentDirectory(), "upfile/", fileName);

            //supprime le fichier si existant
            if (System.IO.File.Exists(filePath))
            {
                System.IO.File.Delete(filePath);
            }

            //copie le fichier dans le repertoire cible "upfile"
            using (FileStream fs = new FileStream(Path.Combine(Directory.GetCurrentDirectory(), "upfile/", fileName), FileMode.Create))
            {
                await req.Form.Files[0].CopyToAsync(fs);

                return this.StatusCode(200, "https://localhost:44350/upfile/" + fileName);
            }
        }
    }
}
