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
    
    public partial class T_Document_List
    {
        public System.Guid Document_ID { get; set; }
        public string Document_Code { get; set; }
        public string Document_Number { get; set; }
        public System.Guid DocumentType_ID { get; set; }
        public Nullable<System.DateTime> Document_Date { get; set; }
        public System.DateTime Issue_Date { get; set; }
        public Nullable<int> TotalSheets { get; set; }
        public string Document_Name { get; set; }
        public Nullable<System.Guid> Parent_ID { get; set; }
        public Nullable<int> VersionNumber { get; set; }
        public Nullable<bool> IsActual { get; set; }
        public string DocumentType_Code { get; set; }
        public System.Guid Status_ID { get; set; }
        public string Status_Name { get; set; }
        public Nullable<System.Guid> Document_to_Status_ID { get; set; }
        public int FilesQTY { get; set; }
    }
}
