using eTrackApis.ViewModels;
using eTrackModels.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace eTrackApis.Controllers
{
    public class LocationController : ApiController
    {
        private TPN_CRMEntities db = new TPN_CRMEntities();

        public HttpResponseMessage Get([FromUri]LocationVm param)
        {
            var data = db.GetLocations(param.CompCode, param.CentCode, param.LocCode, param.LocName, param.Extra1, param.Extra2, param.Extra3).ToList();

            return Request.CreateResponse(new ResponseData(data));
        }

        //public HttpResponseMessage Post(LocationPostVm param)
        //{
        //    if (param.Type == null)
        //    {
        //        param.Type = "I";
        //    }
        //    try
        //    {
        //        var data = db.UpsertLocation(param.CompCode, param.LocCode, param.CityCode,
        //              param.LocName, param.Remarks, param.Status,
        //              param.IP, param.CreatedBy, param.Type);
                
        //        return Request.CreateResponse(HttpStatusCode.Created, new ResponseData(data) { R = data > -1 ? "Y" : "N", Message = data.ToString() });
        //    }
        //    catch(Exception ex)
        //    {
        //        return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex.InnerException == null ? ex.Message : ex.InnerException.Message);
        //    }
        //}
    }
    
}
