using eTrackApis.ViewModels;
using eTrackApis.ViewModels.Helpers;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;

namespace eTrackApis.Controllers
{
    public class FileReqest
    {
        public string[] Files { get; set; }

    }
    public class FilesController : ApiController
    {
        public HttpResponseMessage Post(FileReqest param)
        {
            try
            {
                var dir = HttpContext.Current.Server.MapPath("~/Content/Temp/");
                var data = new List<string>();

                if (!Directory.Exists(dir))
                    Directory.CreateDirectory(dir);
                DeleteTempFiles(dir);
                if (param != null && param.Files != null)
                {
                    var files = param.Files;
                    foreach (var file in files)
                    {
                        var fn = HttpFile.SaveBase64Image(file, dir, ".jpg");

                        data.Add(fn);
                    }

                }

                var httpRequest = HttpContext.Current.Request;


                if (httpRequest.Files.Count > 0)
                {
                    foreach (string fileName in httpRequest.Files.Keys)
                    {
                        var file = httpRequest.Files[fileName];
                        var filePathRelative = Guid.NewGuid().ToString() + "_" + Path.GetFileName(file.FileName);
                        file.SaveAs(dir + filePathRelative);

                        data.Add(filePathRelative);
                    }

                    //return Request.CreateResponse(HttpStatusCode.OK,
                    //    new ResponseData(string.Join(",", data)) { R = "Y", Message = httpRequest.Files.Count + " Files stored in temp location." });

                }

                return Request.CreateResponse(HttpStatusCode.OK,
                    new ResponseData(data) { R = data.Count() > 0 ? "Y" : "N", Message = "Success" });
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex.InnerException == null ? ex.Message : ex.InnerException.Message);
            }
        }

        private void DeleteTempFiles(string dirPath)
        {
            var dir = new DirectoryInfo(dirPath);

            var files = dir.GetFiles().Where(f => f.CreationTime < DateTime.Now.AddMinutes(-30)).ToList();

            foreach (var file in files)
            {
                file.Delete();
            }

        }
    }
}
