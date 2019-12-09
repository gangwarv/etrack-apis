//using eTrackApis.ViewModels;
//using eTrackModels.Models;
//using System;
//using System.Collections.Generic;
//using System.Drawing;
//using System.IO;
//using System.Linq;
//using System.Net;
//using System.Net.Http;
//using System.Web;
//using System.Web.Http;

//namespace eTrackApis.Controllers
//{
//    public class MeetingsLegacyController : ApiController
//    {
//        private TPN_CRMEntities db = new TPN_CRMEntities();
//        public HttpResponseMessage Post([FromBody] MeetingVm param)
//        {
//            try
//            {
//                if (param == null)
//                {
//                    throw new Exception("Request parameter is null.");
//                }
//                SaveFiles(param);
//                var data = db.AddMeeting(param.CompCode, param.CentCode, param.TypeCode, param.CityCode, param.ClientCode, param.ClientName
//                       , param.Mobile, param.VisitStatus, param.Addr1, param.Addr2, param.NextDate, param.PayMode, param.ChequeNo, param.ChequeDate, param.BankCode
//                       , param.BankName, param.Amount, param.ClientProduct, param.ProductTypeCode, param.ProductSizeCode
//                       , param.OpeningQty, param.OrderQty, param.PhotoPath, param.PhotoPath1, param.PhotoPath2, param.PhotoPath3, param.PhotoPath4,
//                       param.Remarks, param.EMI, param.CreatedBy, param.Extra, param.Extra1, param.Extra2);

//                return Request.CreateResponse(HttpStatusCode.Created, new ResponseData(data) { R = data > -1 ? "Y" : "N", Message = data.ToString() });
//            }
//            catch (Exception ex)
//            {
//                return Request.CreateResponse(HttpStatusCode.Created, new ResponseData(ex) { R = "N", Message = ex.InnerException == null ? ex.Message : ex.InnerException.Message });
//            }
//        }
//        private string MoveFile(string OldPath, string BasePath)
//        {
//            OldPath = HttpContext.Current.Server.MapPath("~/Content/Temp/" + OldPath);
//            string NewPath = BasePath + Path.GetFileName(OldPath);
//            if (!Directory.Exists(Path.GetDirectoryName(NewPath)))
//            {
//                Directory.CreateDirectory(Path.GetDirectoryName(NewPath));
//            }
//            File.Move(OldPath, NewPath);

//            return NewPath;
//        }
//        private void SaveFiles(MeetingVm param)
//        {
//            var basePath = System.Configuration.ConfigurationManager.AppSettings["FilesPath"];
//            if (basePath == null)
//            {
//                basePath = "~/Content/";
//            }
//            if (basePath.StartsWith("~"))
//            {
//                basePath = HttpContext.Current.Server.MapPath(basePath + "/Meetings/");
//            }

//            if (!string.IsNullOrEmpty(param.PhotoPath))
//            {
//                param.PhotoPath = MoveFile(param.PhotoPath, basePath);
//            }
//            if (!string.IsNullOrEmpty(param.PhotoPath1))
//            {
//                param.PhotoPath1 = MoveFile(param.PhotoPath1, basePath);
//            }
//            if (!string.IsNullOrEmpty(param.PhotoPath2))
//            {
//                param.PhotoPath2 = MoveFile(param.PhotoPath2, basePath);
//            }
//            if (!string.IsNullOrEmpty(param.PhotoPath3))
//            {
//                param.PhotoPath3 = MoveFile(param.PhotoPath3, basePath);
//            }
//            if (!string.IsNullOrEmpty(param.PhotoPath4))
//            {
//                param.PhotoPath4 = MoveFile(param.PhotoPath4, basePath);
//            }
//            //var httpRequest = HttpContext.Current.Request;
//            //var i = 0;
//            //if (httpRequest.Files.Count > 0)
//            //{
//            //    foreach (string fileName in httpRequest.Files.Keys)
//            //    {
//            //        var file = httpRequest.Files[fileName];
//            //        var filePath = basePath + Guid.NewGuid().ToString() + "_" +  FileName;
//            //        if (i == 0)
//            //            param.PhotoPath = filePath;
//            //        if (i == 1)
//            //            param.PhotoPath1 = filePath;
//            //        if (i == 2)
//            //            param.PhotoPath2 = filePath;
//            //        if (i == 3)
//            //            param.PhotoPath3 = filePath;
//            //        if (i == 4)
//            //            param.PhotoPath4 = filePath;
//            //        i++;
//            //        SaveAs(filePath);
//            //    }
//            //}
//            //else
//            //{
//            //    if (!string.IsNullOrEmpty(param.PhotoPath))
//            //    {
//            //        SaveBase64Image(param.Photo, basePath, param.PhotoPath);
//            //    }
//            //    if (!string.IsNullOrEmpty(param.PhotoPath1))
//            //    {
//            //        SaveBase64Image(param.Photo1, basePath, param.PhotoPath1);
//            //    }
//            //    if (!string.IsNullOrEmpty(param.PhotoPath2))
//            //    {
//            //        SaveBase64Image(param.Photo2, basePath, param.PhotoPath2);
//            //    }
//            //    if (!string.IsNullOrEmpty(param.PhotoPath3))
//            //    {
//            //        SaveBase64Image(param.Photo3, basePath, param.PhotoPath3);
//            //    }
//            //    if (!string.IsNullOrEmpty(param.PhotoPath4))
//            //    {
//            //        SaveBase64Image(param.Photo4, basePath, param.PhotoPath4);
//            //    }
//            //}
//        }
//    }
//}
