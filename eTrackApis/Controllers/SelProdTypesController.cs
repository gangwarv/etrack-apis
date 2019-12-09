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
    public class SelProdTypesController : ApiController
    {
        private TPN_CRMEntities db = new TPN_CRMEntities();

        public HttpResponseMessage Get([FromUri]SelProdTypeVm param)
        {
            var data= db.GetSelProdTypes(param.CompCode,param.CentCode, param.ProdCode, param.ProdName, param.Extra1, param.Extra2, param.Extra3).ToList();

            return Request.CreateResponse(new ResponseData(data));
        }
    }
}
