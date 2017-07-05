
using System;
using System.Collections.Generic;

namespace gLog_FrontEnd.Models
{
    public partial class CNYD_B_PROJECT
    {
        public string ID_ { get; set; }
        public string PJ_NUMBER_ { get; set; }
        public string PJ_NAME_YE_ { get; set; }
        public string PJ_NAME_CN_ { get; set; }
        public string PJ_COMMENTS_ { get; set; }
        public string PJ_MAINCONTRACTOR_ { get; set; }
        public string PJ_ARCHITECT_ { get; set; }
        public string PJ_COUNTRY_ { get; set; }
        public Nullable<int> PJ_TYPE_ { get; set; }
        public Nullable<int> PJ_STATUS_ { get; set; }
        public Nullable<int> RECAUTONR_ { get; set; }
        public Nullable<DateTime> RECCREATED_ { get; set; }
        public string RECCREATEDBY_ { get; set; }
        public string RECCREATEDBYUSRID_ { get; set; }
        public Nullable<DateTime> RECLASTMODIFIED_ { get; set; }
        public string RECLASTMODIFIEDBY_ { get; set; }
        public string RECLASTMODIFIEDBYUSRID_ { get; set; }
        public string RECOWNER_ { get; set; }
        public bool RECLOCK_ { get; set; }
        public string RECCHANGES_ { get; set; }
        public bool RECDELETED_ { get; set; }
        public string PJ_BACKENDFILE_ { get; set; }
        public string PJ_PROJECTPATH_ { get; set; }
        public string SAP_COMPANY_ { get; set; }
        public string SAP_DEPARTMENT_ { get; set; }
        public string SAP_PRCTR_ { get; set; }
        public string SAP_PSPNR_ { get; set; }
        public Nullable<DateTime> SSDATE_ { get; set; }
        public Nullable<DateTime> FFDATE_ { get; set; }
        public Nullable<int> COMPANYID_ { get; set; }
    }
}
