using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
//using System.Web.Hosting;

namespace Mecca.Project.Services
{
    //public class FileService
    //{
    //    private static readonly string UPLOAD_FOLDER_PATH = "~/MeccaUploads/";
        

    //    public static void CreateFolderStructure()
    //    {
    //        Directory.CreateDirectory(HostingEnvironment.MapPath(UPLOAD_FOLDER_PATH));
    //        Directory.CreateDirectory(HostingEnvironment.MapPath(UPLOAD_FOLDER_PATH + "Courts/"));
    //    }

        
    //    public static string GetRalativePath(string filename)
    //    {
    //        string path = Path.Combine(UPLOAD_FOLDER_PATH, filename);
    //        return path;
    //    }

    //    public enum FilePrefeix
    //    {
    //        PURCHASE_,
    //        COLLECTIVE,
    //        BANK_STATEMENT,
    //        BANK_DEPOSIT,

    //    }

    //    public static string UploadFile(HttpPostedFileBase file)
    //    {
    //        string filename = null;

    //        //CreateEmployeeFolderStructure(employeeId);

    //        string uploadPath = UPLOAD_FOLDER_PATH;

    //        if (file != null && file.ContentLength > 0)
    //        {
    //            filename = GenerateUniqueFileName(file.FileName);
    //            string mapped = HostingEnvironment.MapPath(uploadPath);
    //            string path = Path.Combine(mapped, filename);
    //            file.SaveAs(path);
    //        }

    //        return filename;
    //    }

    //    public static string GenerateUniqueFileName(string uploadedFileName)
    //    {
    //        string filename = Guid.NewGuid() + Path.GetExtension(uploadedFileName);
    //        return filename;
    //    }
    //}
}