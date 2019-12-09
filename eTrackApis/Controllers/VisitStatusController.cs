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
    public class VisitStatusController : ApiController
    {
        private TPN_CRMEntities db = new TPN_CRMEntities();

        public HttpResponseMessage Get([FromUri]VisitStatusVm param)
        {
            var data = db.GetVisitStatus(param.CompCode, param.Extra).ToList();

            return Request.CreateResponse(new ResponseData(data));
        }
    }
}
