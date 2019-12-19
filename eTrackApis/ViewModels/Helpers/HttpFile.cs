using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Web;

namespace eTrackApis.ViewModels.Helpers
{
    public class HttpFile
    {
        public static string SaveBase64Image(string base64String, string basePath, string fileName)
        {
            try
            {
                fileName = Guid.NewGuid() + "_" + Path.GetFileName(fileName);

                byte[] bytes = Convert.FromBase64String(base64String);
                File.WriteAllBytes(basePath + fileName, bytes);
            }
            catch (Exception ex)
            {
                throw ex;
                //return null;
            }

            return fileName;
        }
    }
}