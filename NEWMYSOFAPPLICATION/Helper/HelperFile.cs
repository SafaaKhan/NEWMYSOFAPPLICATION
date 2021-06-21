using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

namespace NEWMYSOFAPPLICATION.Helper
{
    public class HelperFile
    {


        public static bool UploadImage(MemoryStream memoryStream, string folderName, string fileName)
        {
            try
            {
                memoryStream.Position = 0;
                var path = Path.Combine(HttpContext.Current.Server.MapPath(folderName), fileName);
                File.WriteAllBytes(path, memoryStream.ToArray());
            }
            catch
            {
                return false;
            }
            return true;



        }
    }
}