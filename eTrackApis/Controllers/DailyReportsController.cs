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


namespace eTrackApis.Controllers
{
    public class DailyReportsController : ApiController
    {
        private TPN_CRMEntities db = new TPN_CRMEntities();

        public HttpResponseMessage Get([FromUri]DailyReportVm param)
        {
            try
            {
                if (Restriction.Is)
                {
                    return Request.CreateResponse(new ResponseData(null) { Message = "SCM_DAILY_REPORT." });
                }
                var conn = db.Database.Connection;
                var dt = new DataTable();
                conn.Open();

                var cmd = conn.CreateCommand();

                cmd.CommandText = "scm_daily_report";

                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add(new SqlParameter("@P_COMP_CODE", param.CompCode));
                cmd.Parameters.Add(new SqlParameter("@P_CENT_CODE", param.CentCode ?? ""));
                cmd.Parameters.Add(new SqlParameter("@P_STATE_CODE", param.StateCode ?? ""));
                cmd.Parameters.Add(new SqlParameter("@P_CITY_CODE", param.CityCode ?? ""));
                cmd.Parameters.Add(new SqlParameter("@P_TYPE_CODE", param.TypeCode ?? ""));
                cmd.Parameters.Add(new SqlParameter("@P_SS_CODE", param.SSCode ?? ""));
                cmd.Parameters.Add(new SqlParameter("@P_DISTRIBUTOR_CODE", param.DistributerCode ?? ""));
                cmd.Parameters.Add(new SqlParameter("@PFROM_DATE", param.FromDate ?? ""));
                cmd.Parameters.Add(new SqlParameter("@PTO_DATE", param.ToDate ?? ""));
                cmd.Parameters.Add(new SqlParameter("@PTYPE", param.Type));
                cmd.Parameters.Add(new SqlParameter("@PUSER_ID", param.UserId ?? ""));
                cmd.Parameters.Add(new SqlParameter("@P_EXTRA", param.Extra ?? ""));
                cmd.Parameters.Add(new SqlParameter("@P_EXTRA1", param.Extra1 ?? ""));
                cmd.Parameters.Add(new SqlParameter("@P_EXTRA2", param.Extra2 ?? ""));

                using (var rdr = cmd.ExecuteReader())
                {
                    dt.Load(rdr);
                }
                conn.Close();
                
                return Request.CreateResponse(new ResponseData(dt) { Message = "SCM_DAILY_REPORT" });
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex.InnerException == null ? ex.Message : ex.InnerException.Message);
            }
        }
    }
}
