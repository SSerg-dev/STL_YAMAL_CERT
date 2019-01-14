using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.OData.Edm;
using SmartQA.DB.Models.People;
using SmartQA.DB.Models.PermissionDocuments;

namespace SmartQA.Models
{

    public class NaksUI
    {
        [Key]
        public Guid ID { get; set; }
        public Guid DocumentNaks_ID { get; set; }
        public Guid? DocumentNaksAttest_ID { get; set; }
        public Guid? ParentDocumentNaks_ID { get; set; }
        
        public string Number { get; set; }
        public string Schifr { get; set; }
        
        [DataType(DataType.Date)]
        public DateTime? IssueDate { get; set; }
        [DataType(DataType.Date)]
        public DateTime? ValidUntil { get; set; }     
        
        public string WeldType { get; set; }
        public IEnumerable<string> HIFGroup { get; set; }       

        public NaksPersonUI Person { get; set; }
        public IEnumerable<string> DetailsType { get; set; }
        public string DetailWidth { get; set; }
        public IEnumerable JointKind { get; set; }
        public IEnumerable JointType { get; set; }
        public IEnumerable OuterDiameter { get; set; }
        public IEnumerable SeamsType { get; set; }
        public string SDR { get; set; }
        public IEnumerable ShieldingGasFlux { get; set; }
        public string WeldingWire { get; set; }
        public IEnumerable WeldMaterial { get; set; }
        public IEnumerable WeldPosition { get; set; }
        public IEnumerable WeldMaterialGroup { get; set; }
        public string WeldPositionCustom { get; set; }
        public string WeldingEquipmentAutomationLevel { get; set; }
        public IEnumerable WeldGOST14098 { get; set; }
        public bool IsValid { get; set; }
        
    }
    
    public class NaksPersonUI
    {
        [Key]
        public Guid ID { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public string SecondName { get; set; }
        public string FullName { get; set; }
        public DateTime? BirthDate { get; set; }
        
        public string Organization { get; set; }
        public string Position { get; set; }
        public string Organization_Description { get; set; }
    }
}