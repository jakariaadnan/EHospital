using Microsoft.AspNetCore.Hosting.Server;
using Microsoft.AspNetCore.Http;
using System;
using System.Drawing;
using System.IO;
using System.Linq;

namespace HospitalManagementSystem.Helpers
{
    public static class FileSave
    {
        public static string SaveFile(out string fileName, IFormFile file, string localPath)
        {
            var allowedExtensions = new[] { ".jpg", ".jpeg", ".png" , ".pdf", ".xlsx", ".csv", ".docx" };
            string message = "success";

            var extention = Path.GetExtension(file.FileName);
            fileName = Path.Combine(localPath, DateTime.Now.Ticks + extention);

            if (file.Length > 2000000)
                return "Select jpg or jpeg or png or pdf less than 2Μ";
            else if (!allowedExtensions.Contains(extention.ToLower()))
                return "Must be jpg or jpeg or png or pdf or xlsx or csv or docx";

            
            var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", fileName);
            try
            {
                using (var stream = new FileStream(path, FileMode.Create))
                {
                    file.CopyTo(stream);
                }
            }
            catch
            {
                return "can not upload image";
            }
            return message;
        }

        public static string SaveEmpImage(out string fileName, IFormFile img)
        {
            var allowedExtensions = new[] { ".jpg", ".jpeg", ".png" };
            string message = "success";

            var extention = Path.GetExtension(img.FileName);
            if (img.Length > 2000000)
                message = "Select jpg or jpeg or png less than 2Μ";
            else if (!allowedExtensions.Contains(extention.ToLower()))
                message = "Must be jpeg or png";

            fileName = Path.Combine("EmpImages", DateTime.Now.Ticks + extention);
            var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", fileName);
            try
            {
                using (var stream = new FileStream(path, FileMode.Create))
                {
                    img.CopyTo(stream);
                }
            }
            catch
            {
                message = "can not upload image";
            }
            return message;
        }

        public static string UploadUserImage(out string fileName, IFormFile img)
        {
            var allowedExtensions = new[] { ".jpg", ".jpeg", ".png",".gif" };
            string message = "success";

            var extention = Path.GetExtension(img.FileName);
            if (img.Length > 2000000)
                message = "Select jpg or jpeg or png less than 2Μ";
            else if (!allowedExtensions.Contains(extention.ToLower()))
                message = "Must be jpeg or png";

            fileName = Path.Combine("Upload/GenarelUser", DateTime.Now.Ticks + extention);
            var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", fileName);
            try
            {
                using (var stream = new FileStream(path, FileMode.Create))
                {
                    img.CopyTo(stream);
                }
            }
            catch
            {
                message = "can not upload image";
            }
            return message;
        }

        public static string SaveImage(out string fileName, string filePath, IFormFile img)
        {
            var allowedExtensions = new[] { ".jpg", ".jpeg", ".png" };
            string message = "success";
            var extention = Path.GetExtension(img.FileName);
            fileName = Path.Combine(filePath, DateTime.Now.Ticks + extention);

            if (img.Length > 2000000)
                return "Select jpg or jpeg or png less than 2Μ";
            else if (!allowedExtensions.Contains(extention.ToLower()))
                return "Must be jpg or jpeg or png";

            
            var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", fileName);
            try
            {
                using (var stream = new FileStream(path, FileMode.Create))
                {
                    img.CopyTo(stream);
                }
            }
            catch
            {
               return "can not upload image";
            }
            return message;
        }

        public static string SaveNIDImage(out string fileName, string filePath, byte[] imge)
        {
            string message = "success";
            var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot");
           
            //Check if directory exist
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path); //Create directory if it doesn't exist
            }
            fileName = filePath+"/"+DateTime.Now.Ticks + ".jpeg";
            string currentPath = Path.Combine(path, fileName);
            try
            {
                File.WriteAllBytes(currentPath, imge);
            }
            catch
            {
                return "can not upload image";
            }
            
            return message;
        }

        //public static string ImageFileSave(out string fileName, string filePath, byte[] imge)
        //{

        //    var allowedExtensions = new[] { ".jpg", ".jpeg", ".png" };
        //    string message = "success";
        //    //var extention = Path.GetExtension(img.FileName);

        //    fileName = Path.Combine(filePath, DateTime.Now.Ticks + ".jpeg");
        //    var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", fileName);
        //    //if (img.Length > 2000000)
        //    //    return "Select jpg or jpeg or png less than 2Μ";
        //    //else if (!allowedExtensions.Contains(extention.ToLower()))
        //    //    return "Must be jpg or jpeg or png";

        //    File.WriteAllBytes(path, imge);

        //    var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", fileName);
        //    try
        //    {
        //        using (var stream = new FileStream(path, FileMode.Create))
        //        {
        //            img.CopyTo(stream);
        //        }
        //    }
        //    catch
        //    {
        //        return "can not upload image";
        //    }

        //    //MemoryStream ms = new MemoryStream(imge);
        //    //File img = File.me(ms);
        //    //var extention = Path.GetExtension(filePath);
        //    //fileName = Path.Combine(filePath, DateTime.Now.Ticks + extention);
        //    return message;

        //    //var allowedExtensions = new[] { ".jpg", ".jpeg", ".png" };
        //    //string message = "success";
        //    //string folderPath = Server.MapPath("~/ImagesFolder/");  //Create a Folder in your Root directory on your solution.
        //    //string fileNames = "IMageName.jpg";
        //    //string imagePath = folderPath + fileNames;

        //    //string cleandata = imge.Replace("data:image/png;base64,", "");
        //    //byte[] data = System.Convert.FromBase64String(cleandata);
        //    //MemoryStream ms = new MemoryStream(data);
        //    //Image img = Image.FromStream(ms);
        //    //img.Save(imagePath, System.Drawing.Imaging.ImageFormat.Jpeg);
        //    //return message;
        //}
        public static string SaveProfilePicture(out string fileName, string filePath, IFormFile img)
        {
            var allowedExtensions = new[] { ".jpg", ".jpeg", ".png" };
            string message = "success";
            var extention = Path.GetExtension(img.FileName);
            fileName = Path.Combine("img/user", DateTime.Now.Ticks + extention);

            if (img.Length > 2000000)
                return "Select jpg or jpeg or png less than 2Μ";
            else if (!allowedExtensions.Contains(extention.ToLower()))
                return "Must be jpg or jpeg or png";


            var path = Path.Combine(filePath, fileName);
            try
            {
                using (var stream = new FileStream(path, FileMode.Create))
                {
                    img.CopyTo(stream);
                }
            }
            catch
            {
                return "can not upload image";
            }
            return message;
        }
        public static void DeleteImage(string filePath)
        {
            var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", filePath);
            if (File.Exists(path))
            {
                File.Delete(path);
            }
        }
    }
}
