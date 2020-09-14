using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace School.Shared
{
    public class DocumentHelper : IDocumentHandler
    {
        private string message = "file cannot be empty";
        private string directoryname="Document";

        public string UploadImage(IFormFile file)
        {
            var currentDirectory = Path.Combine(Directory.GetCurrentDirectory(), directoryname);

         //   if (file == null) throw new Exception(message);

            var directory = Directory.Exists(currentDirectory);

            if (!directory)
            {
               Directory.CreateDirectory(currentDirectory);
            }
            var imageFolder = Path.Combine(Directory.GetCurrentDirectory(), directoryname);
            
            using(var image = new FileStream(imageFolder,FileMode.Create))
            {
                file.CopyTo(image);
            }
            return currentDirectory + file.FileName;
        }
    }
}
