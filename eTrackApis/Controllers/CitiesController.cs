using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using eTrackApis.ViewModels;
using eTrackModels.Models;

namespace eTrackApis.Controllers
{
    public class CitiesController : ApiController
    {
        private TPN_CRMEntities db = new TPN_CRMEntities();

        public HttpResponseMessage Get([FromUri]CityVm param)
        {
            var cities = db.GetCities(param.Country, param.City, param.StateCode).ToList();
            return Request.CreateResponse(new ResponseData(cities));
        }
        // test
        public HttpResponseMessage Post()
        {
            try
            {
                var httpRequest = HttpContext.Current.Request;
                var c = HttpContext.Current.Request.Files.Count;
                var keys = httpRequest.Form.AllKeys;


                if (httpRequest.Files.Count > 0)
                {
                    foreach (string fileName in httpRequest.Files.Keys)
                    {
                        var file = httpRequest.Files[fileName];
                        var filePath = HttpContext.Current.Server.MapPath("~/content/" + file.FileName);
                        file.SaveAs(filePath);
                    }

                    return Request.CreateResponse(HttpStatusCode.Created, c);

                }
                return Request.CreateResponse(HttpStatusCode.Created, "no f");
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.OK, ex.InnerException == null ? ex.Message : ex.InnerException.Message);
            }

        }
    }
    //public class TestPic
    //{
    //    public int Id { get; set; }
    //    public string compCode { get; set; }
    //    public HttpPostedFileBase Photo { get; set; }
    //    public string Photo1 { get; set; }
    //}
}
