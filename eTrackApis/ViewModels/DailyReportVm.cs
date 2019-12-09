using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace eTrackApis.ViewModels
{
    public class DailyReportVm
    {
        public string CompCode { get; set; }
        public string CentCode { get; set; }
        public string StateCode { get; set; }
        public string CityCode { get; set; }
        public string TypeCode { get; set; }
        public string SSCode { get; set; }
        public string DistributerCode { get; set; }
        //public DateTime? FromDate { get; set; }
        //public DateTime? ToDate { get; set; }
        public string FromDate { get; set; }
        public string ToDate { get; set; }
        public string Type { get; set; }
        public string UserId { get; set; }
        public string Extra { get; set; }
        public string Extra1 { get; set; }
        public string Extra2 { get; set; }
    }
}