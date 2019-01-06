using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using SmartQA.DB.Models.Shared;

namespace SmartQA.DB.Models.Documents
{
    [Table("p_PID")]
    public class PID : CommonEntity
    {
        [Required]
        [StringLength(255)]
        public string PID_Code { get; set; }
        
        [StringLength(255)]
        public string Description_Eng { get; set; }

        // ---- m2m relations -------------

        public virtual ICollection<GOST_to_PID> GOST_to_PIDSet { get; set; }

        [NotMapped]
        public ICollection<GOST> GOSTSet => this.GetM2MObjects<GOST>();
        [NotMapped]
        public ICollection<Guid> GOST_IDs
        {
            get => this.GetM2MKeys<GOST>();
            set => this.SetM2MKeys<GOST>(value);                
        }        

        
    }
}