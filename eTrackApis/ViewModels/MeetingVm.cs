using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace eTrackApis.ViewModels
{
    public class MeetingGetVm
    {
        public string CompCode { get; set; }
        public string CentCode { get; set; }
        public string TypeCode { get; set; }
        public string CityCode { get; set; }
        public string DistributerCode { get; set; }

        public string Extra { get; set; }
        public string Extra1 { get; set; }
        public string Extra2 { get; set; }

        public string StateCode { get; set; }
        public string ScmCode { get; set; }
        public string LocationCode { get; set; }

        public string UserId { get; set; }
        public DateTime? FromDate { get; set; }
        public DateTime? ToDate { get; set; }
        public string ReportType { get; set; }
    }
    public class MeetingVm
    {
        #region prop
        public string CompCode { get; set; }
        public string CentCode { get; set; }
        public string TypeCode { get; set; }
        public string CityCode { get; set; }
        public string ClientCode { get; set; }
        public string ClientName { get; set; }
        public string Mobile { get; set; }
        public string VisitStatus { get; set; }
        public string Addr1 { get; set; }
        public string Addr2 { get; set; }
        public DateTime? NextDate { get; set; }
        public string PayMode { get; set; }
        public string ChequeNo { get; set; }
        public DateTime? ChequeDate { get; set; }
        #endregion
        public string BankCode { get; set; }
        public string BankName { get; set; }
        public decimal? Amount { get; set; }
        public string ClientProduct { get; set; }
        public string PhotoPath { get; set; }
        public string Remarks { get; set; }
        public string EMI { get; set; }
        public string CreatedBy { get; set; }

        public string Extra { get; set; }
        public string Extra1 { get; set; }
        public string Extra2 { get; set; }

        public string StateCode { get; set; }
        public string ScmCode { get; set; }
        public string LocationCode { get; set; }
        public string DistributerCode { get; set; }
        public string DistProduct { get; set; }
        public string DistRemarks { get; set; }
        public string OrderYN { get; set; }
    }
}