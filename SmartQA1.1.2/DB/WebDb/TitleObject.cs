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
    
    public partial class TitleObject
    {
        public System.Guid TitleObject_ID { get; set; }
        public string TitleObject_Code { get; set; }
        public Nullable<System.Guid> Parent_Id { get; set; }
        public int Structure { get; set; }
        public string Description_Eng { get; set; }
        public string Description_Rus { get; set; }
        public string Phase_Name { get; set; }
        public string ReportColor { get; set; }
        public Nullable<int> ReportOrder { get; set; }
        public Nullable<double> GLB_Weight { get; set; }
        public Nullable<int> Row_Status { get; set; }
        public Nullable<double> Book1_Pct { get; set; }
        public Nullable<double> Book1_Weight { get; set; }
        public Nullable<double> Book2_Pct { get; set; }
        public Nullable<double> Book2_Weight { get; set; }
        public Nullable<double> Book3_Pct { get; set; }
        public Nullable<double> Book3_Weight { get; set; }
        public Nullable<double> Book4_Weight { get; set; }
        public string TitleObject_for_ABDFinalSet { get; set; }
        public Nullable<double> Book1_Documents_Total { get; set; }
        public Nullable<double> Book1_Documents_received { get; set; }
        public Nullable<double> Book1_Progress { get; set; }
        public Nullable<double> Book1_Documents_transmitted_to_CPY { get; set; }
        public string StageOfConstr { get; set; }
    }
}
