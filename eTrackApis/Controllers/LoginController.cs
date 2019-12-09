using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using eTrackModels.Models;
using eTrackApis.ViewModels;

namespace eTrackApis.Controllers
{
    public class LoginController : ApiController
    {
        private TPN_CRMEntities db = new TPN_CRMEntities();

        //public HttpResponseMessage Get(string userName, string password)
        //{
        //    if (!string.IsNullOrEmpty(userName) && !string.IsNullOrEmpty(password))
        //    {
        //        var result = db.AppLoginUser(userName, password).SingleOrDefault();
        //        return Request.CreateResponse(result);
        //    }
        //    else
        //    {
        //        return Request.CreateErrorResponse(HttpStatusCode.BadRequest, "Username & Password is required.");
        //    }
        //}

        public HttpResponseMessage Post([FromBody]AppUser user)
        {
            if (user != null && !string.IsNullOrEmpty(user.UserName) && !string.IsNullOrEmpty(user.Password))
            {
                var result = db.AppLoginUser(user.UserName, user.Password).SingleOrDefault();
                return Request.CreateResponse(result);
            }
            else
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, "Username & Password is required.");
            }
        }
    }
}
