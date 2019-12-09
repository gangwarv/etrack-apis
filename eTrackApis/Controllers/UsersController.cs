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
    // 
    public class UsersController : ApiController
    {
        private TPN_CRMEntities db = new TPN_CRMEntities();

        public HttpResponseMessage Post([FromBody]AppUser user)
        {
            try
            {
                var retValue = db.UpsertAppUser(user.UserCode, user.UserName,
                    user.UserType,
                    user.UserFname,
                    user.UserLname,
                    user.Password,
                    user.Agency,
                    user.DeptCode,
                    user.Branch,
                    user.DateFormat,
                    user.DefComp,
                    user.LstComp,
                    user.Email,
                    user.Role,
                    user.Status,
                    user.BranchPer,
                    user.CompanyName,
                    user.Compagen,
                    user.UserId,
                    user.PwExpDays,
                    user.IP,
                    user.Mac,
                    user.PreDns,
                    user.Type,
                    user.MobileNo,
                    user.ExecModuleCode,
                    user.MutiComp,
                    user.ExecCode,
                    user.Extra1,
                    user.Extra2,
                    user.Extra3
                    );

                return Request.CreateResponse(new ResponseData(retValue) { Message = "Success" });
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(new ResponseData(ex) { R = "N", Message = ex.Message });
            }
        }
    }
}
