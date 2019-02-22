using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace NajmetAlraqeeSite.Services
{
    public class FileService
    {
        private static readonly string UPLOAD_FOLDER_PATH = "\\Uploads\\";
       

        public static string GetRalativePath(string filename)
        {
            string path = Path.Combine(UPLOAD_FOLDER_PATH, filename);
            return path;
        }

        

        public static async Task<string> UploadFileAsync(IFormFile file , IHostingEnvironment _environment)
        {
            string filename = null;
           
            //CreateEmployeeFolderStructure(employeeId);
            string uploadPath = UPLOAD_FOLDER_PATH;

            if (file != null && file.Length > 0)
            {
                var filePath = Path.Combine(_environment.WebRootPath + UPLOAD_FOLDER_PATH, "");
                filename = GenerateUniqueFileName(file.FileName);
               
                 //await file.CopyToAsync(new FileStream(filePath, FileMode.Create,)); 
                //string mapped = HostingEnvironment.MapPath(uploadPath);
                string path = Path.Combine(filePath, filename);
               await file.CopyToAsync(new FileStream(path, FileMode.Create));
            }

            return filename;
        }

        public static string GenerateUniqueFileName(string uploadedFileName)
        {
            string filename = Guid.NewGuid() + Path.GetExtension(uploadedFileName);
            return filename;
        }
    }
}
