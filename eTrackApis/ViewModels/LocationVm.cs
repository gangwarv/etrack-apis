using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace eTrackApis.ViewModels
{
    public class LocationVm
    {
        public string CompCode { get; set; }
        public string CentCode { get; set; }
        public string LocCode { get; set; }
        public string LocName { get; set; }
        public string Extra1 { get; set; }
        public string Extra2 { get; set; }
        public string Extra3 { get; set; }
    }

    public class LocationPostVm
    {
        public string CompCode { get; set; }
        public string LocCode { get; set; }
        public string LocName { get; set; }
        public string CityCode { get; set; }

        public string Remarks { get; set; }
        public string IP { get; set; }
        public string CreatedBy { get; set; }
        public string Type { get; set; }
        public string Status { get; internal set; }
    }
    public class LocationType
    {
        public string COMP_CODE { get; set; }
        public string LOC_CODE { get; set; }
        public string LOC_NAME { get; set; }
        public string REMARKS { get; set; }
        public string STATUS { get; set; }
        public string CITY_CODE { get; set; }
        public string CITY_NAME { get; set; }
    }
}