//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace SmartQA1._1._2.DB.PermissionDb
{
    using System;
    using System.Collections.Generic;
    
    public partial class Employee
    {
        public System.Guid Employee_ID { get; set; }
        public string Employee_Code { get; set; }
        public System.Guid Person_Id { get; set; }
        public System.Guid Position_Id { get; set; }
        public Nullable<System.Guid> AppUser_Id { get; set; }
        public Nullable<System.Guid> Contragent_ID { get; set; }
    
        public virtual Person Person { get; set; }
        public virtual Contragent Contragent { get; set; }
        public virtual Position Position { get; set; }
    }
}
