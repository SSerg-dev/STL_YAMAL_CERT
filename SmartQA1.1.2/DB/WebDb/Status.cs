//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace SmartQA1._1._2.DB.WebDb
{
    using System;
    using System.Collections.Generic;
    
    public partial class Status
    {
        public System.Guid Status_ID { get; set; }
        public string Status_Code { get; set; }
        public string StatusEntity { get; set; }
        public string Description_Eng { get; set; }
        public string Description_Rus { get; set; }
        public Nullable<bool> EntityLocked { get; set; }
        public string ReportColor { get; set; }
        public Nullable<int> ReportOrder { get; set; }
    }
}
