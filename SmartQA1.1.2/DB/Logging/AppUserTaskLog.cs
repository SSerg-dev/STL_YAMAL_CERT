//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace SmartQA1._1._2.DB.Logging
{
    using System;
    using System.Collections.Generic;
    
    public partial class AppUserTaskLog
    {
        public System.Guid AppUserTaskLog_ID { get; set; }
        public string AppUserTaskLog_Code { get; set; }
        public System.Guid AppUser_ID { get; set; }
        public System.Guid AppUserTask_ID { get; set; }
        public Nullable<System.Guid> AppUserTaskMessage_ID { get; set; }
        public string FilePath { get; set; }
        public string FileName { get; set; }
        public string Description_Eng { get; set; }
        public string Description_Rus { get; set; }
        public string StackTrace { get; set; }
    }
}
