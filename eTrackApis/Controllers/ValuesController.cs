using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
using eTrackApis.ViewModels.Helpers;
using eTrackModels.Models;

namespace eTrackApis.Controllers
{
    public class Restriction
    {
        public static bool Is = false;
    }
    public class ValuesController : ApiController
    {
        // GET api/values
        public IEnumerable<string> Get(int? length = 20, int? page = 1)
        {
            var d = new List<string>();
            d.Add("9 Dec 18:00");
            if (length != null)
            {
                d.Add(length.Value.ToString());
            }
            if (page != null)
            {
                d.Add(page.Value.ToString());
            }

            return d;
        }
        public string Get(int id)
        {
            Restriction.Is = id == 1;
            return "Id Is " + id;
        }
        // GET api/values/5
        //public string Get(int id)
        //{

        //TPN_CRMEntities db = new TPN_CRMEntities();
        //var conn = db.Database.Connection;
        //var dt = new DataTable();
        //conn.Open();

        //var cmd = conn.CreateCommand();
        //cmd.CommandText = @"EXEC scm_daily_report @P_COMP_CODE='1',@P_CENT_CODE='',@P_STATE_CODE ='',
        //                @P_CITY_CODE ='',@P_TYPE_CODE='',@P_SS_CODE  ='',@P_DISTRIBUTOR_CODE ='', @PFROM_DATE=NULL,@PTO_DATE =NULL,
        //                @PTYPE ='2'  ,
        //                @PUSER_ID   ='AD0',@P_EXTRA ='',@P_EXTRA1  ='',@P_EXTRA2  =''";
        ////cmd.CommandType = System.Data.CommandType.StoredProcedure;
        //using (var rdr = cmd.ExecuteReader())
        //{
        //    dt.Load(rdr);
        //}
        //conn.Close();
        //var re = db.Database.SqlQuery<Res>("SELECT 0 AS Id, 'Vish' AS [Full Name]").SingleOrDefault();
        //return re.Id + " & " + re.FullName;
        //}

        // POST api/values
        public HttpResponseMessage Post(string photo)
        {
            return Request.CreateResponse("Failed");
        }

        // PUT api/values/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        public void Delete(int id)
        {
        }
    }
}
