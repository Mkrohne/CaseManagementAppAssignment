using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CaseManagementApp.Models.Entities
{
    [Index(nameof(Email), IsUnique = true)]
    public class UserEntity
    {
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();

        [Required]
        [StringLength(50)]
        public string FirstName { get; set; } = null!;

        [Required]
        [StringLength(50)]
        public string LastName { get; set; } = null!;

        [Required]
        [EmailAddress]
        [StringLength(100)]
        public string Email { get; set; } = null!;

        [Phone]
        [Column(TypeName = "char(13)")]
        public string? PhoneNumber { get; set; }

        //[Required]
        //[Column(TypeName = "datetime")]
        //public DateTime CreatedAt { get; set; } = DateTime.Now;

        //[Column(TypeName = "datetime")]
        //public DateTime? UpdatedAt { get; set; }

        public ICollection<CaseEntity> CasesEntity { get; set; } = new HashSet<CaseEntity>();
    }
}