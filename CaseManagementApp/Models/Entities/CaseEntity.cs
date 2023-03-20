using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CaseManagementApp.Models.Entities
{
    public class CaseEntity
    {
        [Key]
        public int CaseId { get; set; }

        [Required]
        [Column(TypeName = "nvarchar(50)")]
        public string Title { get; set; }

        [Required]
        [Column(TypeName = "nvarchar(500)")]
        public string Description { get; set; }

        [Required]
        public DateTime CreationDate { get; set; }

        [Required]
        [Column(TypeName = "nvarchar(50)")]
        public string Status { get; set; } = null!;

        [Column(TypeName = "nvarchar(50)")]
        public string CreatedBy { get; set; } = null!;

        [Column(TypeName = "datetime")]
        public DateTime? UpdatedAt { get; set; }

        public ICollection<UserEntity> Users { get; set; } = new HashSet<UserEntity>();
    }
}