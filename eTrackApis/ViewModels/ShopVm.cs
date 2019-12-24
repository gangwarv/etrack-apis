using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace eTrackApis.ViewModels
{
    public class ShopVm
    {
        public string CompCode { get; set; }
     
        public string Extra1 { get; set; }
        public string Extra2 { get; set; }
        public string Extra3 { get; set; }
        public string Extra4 { get; set; }
        public string City { get; set; }
        public string Location { get; set; }
        public string Type { get; set; }
        public string Name { get; set; }
    }

    public class ShopPostVm
    {
        public string RequestType { get; set; }


        public string CompCode { get; set; }
        public string ShopKeepCode { get; set; }
        public string ShopType { get; set; }
        public string DistShopName{ get; set; }
        public string SalesCCode{ get; set; }
        public string ShopKeepName{ get; set; }
        public string ShopKeepNick{ get; set; }
        public string Add1{ get; set; }
        public string CityCode{ get; set; }
        public string Add2{ get; set; }
        public string LocationCode{ get; set; }
        public string Email{ get; set; }
        public string Phone{ get; set; }
        public string Mobile{ get; set; }
        public string Status{ get; set; }
        public DateTime? StatusDate{ get; set; }
        public string IP{ get; set; }
        public string UserId{ get; set; }
        public string Type{ get; set; }

        public string Extra1 { get; set; }
        public string Extra2 { get; set; }
        public string Extra3 { get; set; }
        public string Extra4 { get; set; }
        public string Extra5 { get; set; }
        public string Remarks { get; set; }
    }

    //public class ShopkeeperType
    //{
    //    public string COMP_CODE { get; set; }
    //    public string SHOP_KEEP_CODE { get; set; }
    //    public string SHOP_TYPE { get; set; }
    //    public string DISTSHOP_NAME { get; set; }
    //    public string SALES_C_CODE { get; set; }
    //    public string SALES_PRSN_NAME { get; set; }
    //    public string SHOP_KEEP_NAME { get; set; }
    //    public string SHOP_KEEP_NICK { get; set; }
    //    public string ADD1 { get; set; }
    //    public string CITY_CODE { get; set; }
    //    public string CITY_NAME { get; set; }
    //    public string ADD2 { get; set; }
    //    public string LOCATION_CODE { get; set; }
    //    public string LOC_NAME { get; set; }
    //    public string EMAIL_ID { get; set; }
    //    public string PHONE { get; set; }
    //    public string MOBILE { get; set; }
    //    public string REMARKS { get; set; }
    //    public string STATUS { get; set; }
    //    public string STATUS_DATE { get; set; }
    //    public string CREATE_USER { get; set; }
    //    public string CREATE_DATE { get; set; }
    //    public string UPDATE_USER { get; set; }
    //    public string UPDATE_DATE { get; set; }
    //}
}