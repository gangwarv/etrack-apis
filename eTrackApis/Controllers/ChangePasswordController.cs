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
    public class ChangePasswordController : ApiController
    {
        private TPN_CRMEntities db = new TPN_CRMEntities();

        public HttpResponseMessage Post([FromBody]ChangePasswordVm param)
        {
            if (param != null)
            {
                var result = db.ChangePassword(param.UserName, param.OldPassword, param.NewPassword, param.Extra).SingleOrDefault();
                return Request.CreateResponse(result);
            }
            else
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, "Username, OldPassword & NewPassword is required.");
            }
        }
    }
}
