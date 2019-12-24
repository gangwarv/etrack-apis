using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data;
using System.Linq;
using System.Data.SqlClient;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
using eTrackApis.ViewModels;
using eTrackModels.Models;
using SqlToJsonConvertor;


namespace eTrackApis.Controllers
{
    public class DailyReportsController : ApiController
    {
        private TPN_CRMEntities db = new TPN_CRMEntities();

        public HttpResponseMessage Get([FromUri]DailyReportVm param)
        {
            try
            {
                var conn = db.Database.Connection;
                var parameters = new List<SqlParameter>();
                parameters.Add(new SqlParameter("@P_COMP_CODE", param.CompCode));
                parameters.Add(new SqlParameter("@P_CENT_CODE", param.CentCode ?? ""));
                parameters.Add(new SqlParameter("@P_STATE_CODE", param.StateCode ?? ""));
                parameters.Add(new SqlParameter("@P_CITY_CODE", param.CityCode ?? ""));
                parameters.Add(new SqlParameter("@P_TYPE_CODE", param.TypeCode ?? ""));
                parameters.Add(new SqlParameter("@P_SS_CODE", param.SSCode ?? ""));
                parameters.Add(new SqlParameter("@P_DISTRIBUTOR_CODE", param.DistributerCode ?? ""));
                parameters.Add(new SqlParameter("@PFROM_DATE", param.FromDate ?? ""));
                parameters.Add(new SqlParameter("@PTO_DATE", param.ToDate ?? ""));
                parameters.Add(new SqlParameter("@PTYPE", param.Type));
                parameters.Add(new SqlParameter("@PUSER_ID", param.UserId ?? ""));
                parameters.Add(new SqlParameter("@P_EXTRA", param.Extra ?? ""));
                parameters.Add(new SqlParameter("@P_EXTRA1", param.Extra1 ?? ""));
                parameters.Add(new SqlParameter("@P_EXTRA2", param.Extra2 ?? ""));

                JsonConvertor convertor = new JsonConvertor(conn);

                var result = convertor.ToJson("scm_daily_report", CommandType.StoredProcedure, parameters.ToArray());
                
                return Request.CreateResponse(new ResponseData(result) { Message = "SCM_DAILY_REPORT" });
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex.InnerException == null ? ex.Message : ex.InnerException.Message);
            }
        }
    }
}
