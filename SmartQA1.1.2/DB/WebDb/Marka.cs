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
    
    public partial class Marka
    {
        public System.Guid Marka_ID { get; set; }
        public string Marka_Code { get; set; }
        public string Marka_Code_Eng { get; set; }
        public string Description_Eng { get; set; }
        public string Description_Rus { get; set; }
        public string Engineering_Drawing_Type_Eng { get; set; }
        public string Engineering_Drawing_Type_Rus { get; set; }
        public Nullable<bool> IsUsedInMatrix { get; set; }
        public Nullable<bool> IsPriority { get; set; }
        public string ReportColor { get; set; }
        public Nullable<int> ReportOrder { get; set; }
    }
}
