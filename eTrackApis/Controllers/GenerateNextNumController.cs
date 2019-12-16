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
    public class GenerateNextNumController : ApiController
    {
        private TPN_CRMEntities db = new TPN_CRMEntities();

        public HttpResponseMessage Get()
        {
            var number = Convert.ToInt32(db.Database.SqlQuery<Decimal>("SCM_NUM_GEN").SingleOrDefault().ToString());
            return Request.CreateResponse(new ResponseData(number) { Message = "SCM_APP Next number" });
        }
        public HttpResponseMessage Get(string type)
        {
            var number = db.GenerateNextNum().SingleOrDefault();
            return Request.CreateResponse(new ResponseData(number) { Message = type + " Next number" });
        }
    }
}
