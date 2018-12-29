using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using SmartQA.DB.Models.Shared;

namespace SmartQA.DB.Models.Documents
{
    [Table("p_GOST")]
    public class GOST : CommonEntity
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("GOST_ID")]
        public Guid ID { get; set; }
        
        [Required]
        [StringLength(255)]
        public string GOST_Code { get; set; }
        
        [StringLength(255)]
        public string Description_Rus { get; set; }
        
        public Guid? Marka_ID { get; set; }
        
        [ForeignKey("Marka_ID")]
        public virtual Marka Marka { get; set; }

        [NotMapped]
        public ICollection<PID> PIDSet => this.GetM2MObjects<PID>();
        [NotMapped]
        public ICollection<Guid> PID_IDs
        {
            get => this.GetM2MKeys<PID>();
            set => this.SetM2MKeys<PID>(value);                
        }        
        
        [NotMapped]
        public ICollection<TitleObject> TitleObjectSet => this.GetM2MObjects<TitleObject>();
        [NotMapped]
        public ICollection<Guid> TitleObject_IDs
        {
            get => this.GetM2MKeys<TitleObject>();
            set => this.SetM2MKeys<TitleObject>(value);                
        }
        
    }
}