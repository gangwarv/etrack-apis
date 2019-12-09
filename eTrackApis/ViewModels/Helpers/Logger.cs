using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Script.Serialization;

namespace eTrackApis.ViewModels.Helpers
{
    public class Logger
    {
        public static void APILog(object msg, string apiUrl)
        {
            string strpath1 = HttpContext.Current.Server.MapPath(@"~/Content/Logs/" + DateTime.Now.ToString("yyyy-MM-dd") + ".txt");// string.Format(@"C:\mSellerUtilities\iPad\Log_" + DateTime.Now.ToString("yyyyMMdd") + ".txt");
            var jserializer = new JavaScriptSerializer();

            //var js = jserializer.Serialize(msg);

            if (!Directory.Exists(Path.GetDirectoryName(strpath1)))
            {
                Directory.CreateDirectory(Path.GetDirectoryName(strpath1));
            }
            using (StreamWriter writer = new StreamWriter(strpath1, true))
            {
                writer.WriteLine("-------------------------------- @" + DateTime.Now.ToString("dd MMM yyyy hh:mm tt") + "-------------------------------------");
                writer.WriteLine(apiUrl);
                writer.WriteLine(jserializer.Serialize(msg));
                writer.Close();
            }
            //Console.WriteLine(msg);
        }
    }
}