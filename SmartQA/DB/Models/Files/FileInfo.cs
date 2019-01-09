using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;
using SmartQA.DB.Models.Documents;
using SmartQA.DB.Models.Shared;

namespace SmartQA.DB.Models.Files
{
    [Table("p_FileDesc")]
    public class FileDesc : CommonEntity
    {
        [Required]
        [StringLength(1000)]
        public string UploadName { get; set; }
        
        [Required]
        [StringLength(1000)]
        public string FileName { get; set; }
        
        [StringLength(1000)]
        public string Description { get; set; }
        
        public long Length { get; set; }
        
        [StringLength(255)]
        public string ContentType { get; set; }

        [RunAtModelSetup]
        public static void SetupRelations(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<FileDesc>()
                .HasAlternateKey(f => f.FileName);            
        }
    }    
}