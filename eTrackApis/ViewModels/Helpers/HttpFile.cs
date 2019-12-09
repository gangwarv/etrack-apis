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
        public static void SaveBase64Image(string base64String, string basePath, string path)
        {
            path = basePath + new Guid() + "_" + Path.GetFileName(path);
            byte[] bytes = Convert.FromBase64String(base64String);
            File.WriteAllBytes(path, bytes);
        }
    }
}