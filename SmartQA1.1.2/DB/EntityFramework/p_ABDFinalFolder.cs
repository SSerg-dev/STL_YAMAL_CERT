//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace SmartQA1._1._2.DB.EntityFramework
{
    using System;
    using System.Collections.Generic;
    
    public partial class p_ABDFinalFolder
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public p_ABDFinalFolder()
        {
            this.p_ABDFinalFolder_to_Contragent = new HashSet<p_ABDFinalFolder_to_Contragent>();
        }
    
        public System.Guid ABDFinalFolder_ID { get; set; }
        public string ABDFinalFolder_Name { get; set; }
        public Nullable<int> Row_status { get; set; }
        public Nullable<System.DateTime> Insert_DTS { get; set; }
        public Nullable<System.DateTime> Update_DTS { get; set; }
        public Nullable<System.DateTime> Final_Compilation_Target_Date { get; set; }
        public Nullable<System.DateTime> Final_Compilation_Start_Date { get; set; }
        public string CTR_RESP { get; set; }
        public Nullable<int> ListCount { get; set; }
        public string Modified_By { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<p_ABDFinalFolder_to_Contragent> p_ABDFinalFolder_to_Contragent { get; set; }
    }
}
