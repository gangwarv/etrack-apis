using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using eTrackApis.ViewModels;
using eTrackModels.Models;
using SqlToJsonConvertor;

namespace eTrackApis.Controllers
{
    public class ShopkeepersController : ApiController
    {
        private TPN_CRMEntities db = new TPN_CRMEntities();

        public HttpResponseMessage Get([FromUri]ShopPostVm param)
        {
            if (param.RequestType != null && param.RequestType.ToLower() == "slim")
            {
                var shops = db.GetShopkeepers(param.CompCode, param.CityCode, param.LocationCode, param.ShopType, param.DistShopName, param.Extra1, param.Extra2, param.Extra3, param.Extra4).ToList();

                return Request.CreateResponse(new ResponseData(shops) { Message = "Data from SCM_BIND_SHOP_P, Use it for binding customer/shopkeeper control" });
            }
            else
            {
                JsonConvertor con = new JsonConvertor(db.Database.Connection);
                var query = @"EXEC SCM_SHOPKEEPER_MAST_INSUPDDEL @PCOMP_CODE='"
                + param.CompCode + "'," + @"@PSHOP_KEEP_CODE='',@PSHOP_TYPE='',@PDISTSHOP_NAME='',@PSALES_C_CODE='" + param.SalesCCode
                + "',@PSHOP_KEEP_NAME='" + param.ShopKeepName + "',@PSHOP_KEEP_NICK=''," +
                @"@PADD1='',@PCITY_CODE='" + param.CityCode + "', @PADD2='',@PLOCATION_CODE='"
                + param.LocationCode + "',@PEMAIL_ID='',@PPHONE='',@PMOBILE='',@PREMARKS='',@PSTATUS='',@PSTATUS_DATE=NULL," +
                @"@PEXTRA1='',@PEXTRA2='',@PEXTRA3='',@PEXTRA4='',@PEXTRA5='',@IP='', @PUSERID='',@PTYPE='E' ";

                var data = con.ToJson(query, System.Data.CommandType.Text);
                
                return Request.CreateResponse(new ResponseData(data) { Message = "Data from SCM_SHOPKEEPER_MAST_INSUPDDEL, Use it for searching old customer/shopkeeper." });
            }
        }

        public HttpResponseMessage Post([FromBody]ShopPostVm param)
        {
            var data = db.UpsertShopkeeper(param.CompCode, param.ShopType, param.DistShopName,
                  param.SalesCCode, param.ShopKeepCode, param.ShopKeepName,
                  param.ShopKeepNick, param.Add1, param.CityCode, param.Add2,
                  param.LocationCode, param.Email, param.Phone, param.Mobile,
                  param.Remarks, param.Status, param.StatusDate,
                  param.Extra1, param.Extra2, param.Extra3, param.Extra4, param.Extra5,
                  param.IP, param.UserId, param.Type);


            return Request.CreateResponse(HttpStatusCode.Created, new ResponseData(data) { R = data > -1 ? "Y" : "N", Message = data.ToString() });
        }
    }
}
