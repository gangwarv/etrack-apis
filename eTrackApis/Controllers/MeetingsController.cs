using eTrackApis.ViewModels;
using eTrackModels.Models;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;

namespace eTrackApis.Controllers
{
    public class MeetingsController : ApiController
    {
        private TPN_CRMEntities db = new TPN_CRMEntities();

        public HttpResponseMessage Get([FromUri]MeetingGetVm param)
        {
            var shops = db.GetMeeting(param.CompCode, param.CentCode, param.ScmCode,
                param.StateCode, param.CityCode, param.TypeCode, param.LocationCode
                       , param.DistributerCode, param.UserId, param.FromDate, param.ToDate, param.ReportType, param.Extra, param.Extra1, param.Extra2).ToList();

            return Request.CreateResponse(new ResponseData(shops) { Message = "Success" });

        }
        public HttpResponseMessage Post([FromBody] MeetingVm param)
        {
            try
            {
                if (param == null)
                {
                    //throw new Exception("Request parameter is null.");
                    param = new MeetingVm();
                    var httpRequest = HttpContext.Current.Request;
                    param.CompCode = httpRequest.Form["CompCode"];
                    param.CentCode = httpRequest.Form["CentCode"];
                    param.ScmCode = httpRequest.Form["ScmCode"];
                    param.StateCode = httpRequest.Form["StateCode"];
                    param.CityCode = httpRequest.Form["CityCode"];
                    param.TypeCode = httpRequest.Form["TypeCode"];
                    param.LocationCode = httpRequest.Form["LocationCode"];
                    param.DistributerCode = httpRequest.Form["DistributerCode"];
                    param.DistProduct = httpRequest.Form["DistProduct"];
                    param.DistRemarks = httpRequest.Form["DistRemarks"];
                    param.ClientCode = httpRequest.Form["ClientCode"];
                    param.ClientName = httpRequest.Form["ClientName"];
                    param.Mobile = httpRequest.Form["Mobile"];
                    param.VisitStatus = httpRequest.Form["VisitStatus"];
                    param.Addr1 = httpRequest.Form["Addr1"];
                    param.Addr2 = httpRequest.Form["Addr2"];
                    param.NextDate = GetDate(httpRequest.Form["NextDate"]);
                    param.PayMode = httpRequest.Form["PayMode"];
                    param.ChequeNo = httpRequest.Form["ChequeNo"];
                    param.ChequeDate = GetDate(httpRequest.Form["ChequeDate"]);
                    param.BankCode = httpRequest.Form["BankCode "];
                    param.BankName = httpRequest.Form["BankName"];
                    param.Amount = GetDecimal(httpRequest.Form["Amount"]);
                    param.ClientProduct = httpRequest.Form["ClientProduct"];
                    param.PhotoPath = httpRequest.Form["PhotoPath"];
                    param.OrderYN = httpRequest.Form["OrderYN"];
                    param.Remarks = httpRequest.Form["Remarks"];
                    param.EMI = httpRequest.Form["EMI"];
                    param.CreatedBy = httpRequest.Form["CreatedBy"];
                    param.Extra = httpRequest.Form["Extra"];
                    param.Extra1 = httpRequest.Form["Extra1"];
                    param.Extra2 = httpRequest.Form["Extra2"];

                    // For Update
                    param.PhotoPath = httpRequest.Form["PhotoPath"];
                }
                SaveFiles(param);

                //var data = 1;
                var data = db.AddMeeting(param.CompCode, param.CentCode, param.ScmCode, param.StateCode, param.CityCode, param.TypeCode, param.LocationCode
                       , param.DistributerCode, param.DistProduct, param.DistRemarks, param.ClientCode, param.ClientName, param.Mobile, param.VisitStatus,
                       param.Addr1, param.Addr2, param.NextDate, param.PayMode, param.ChequeNo, param.ChequeDate, param.BankCode
                       , param.BankName, param.Amount, param.ClientProduct,
                       param.PhotoPath, param.OrderYN,
                       param.Remarks, param.EMI, param.CreatedBy, param.Extra, param.Extra1, param.Extra2);

                return Request.CreateResponse(HttpStatusCode.Created, new ResponseData(data) { R = data > -1 ? "Y" : "N", Message = data.ToString() });
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.Created, new ResponseData(ex) { R = "N", Message = ex.InnerException == null ? ex.Message : ex.InnerException.Message });
            }
        }
        private DateTime? GetDate(string str)
        {
            return string.IsNullOrEmpty(str) ? null : DateTime.Parse(str) as DateTime?;
        }
        private decimal? GetDecimal(string str)
        {
            decimal val;
            if (!string.IsNullOrEmpty(str) && decimal.TryParse(str, out val))
            {
                return val as decimal?;
            }
            return null;
        }
        private void SaveFiles(MeetingVm param)
        {
            var relativePath = "~/Content/Meetings/";

            var basePath = HttpContext.Current.Server.MapPath(relativePath);

            var httpRequest = HttpContext.Current.Request;
            var i = 0;
            if (httpRequest.Files.Count > 0)
            {
                if (!Directory.Exists(basePath))
                {
                    Directory.CreateDirectory(basePath);
                }
                var file = httpRequest.Files[0];
                var filename = Guid.NewGuid().ToString() + "_" + Path.GetFileName(file.FileName);
                var filePath = basePath + filename;
                if (i == 0)
                    param.PhotoPath = relativePath.Substring(1) + filename;
                //if (i == 1)
                //    param.PhotoPath1 = filePath;
                //if (i == 2)
                //    param.PhotoPath2 = filePath;
                //if (i == 3)
                //    param.PhotoPath3 = filePath;
                //if (i == 4)
                //    param.PhotoPath4 = filePath;
                i++;
                file.SaveAs(filePath);

            }
        }
    }
}
