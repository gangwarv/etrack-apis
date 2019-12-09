using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace eTrackApis.ViewModels
{
    public class ResponseData
    {
        public ResponseData() { }
        public ResponseData(object data)
        {
            this.data = data;
            this.R = "Y";
        }
        public string R { get; set; }
        public object data { get; set; }
        public string Message { get; set; }
    }
}