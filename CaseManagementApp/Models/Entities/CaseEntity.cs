namespace CaseManagementApp.Models.Entities
{
    public class CaseEntity
    {
        public int Id { get; set; }
        public string CustomerFirstName { get; set; } = null!;
        public string CustomerLastName { get; set; } = null!;
        public string CustomerEmail { get; set; } = null!;
        public string CustomerPhoneNumber { get; set; } = null!;
        public string Description { get; set; } = null!;
        public DateTime CreatedDate { get; set; }
        public CaseStatus Status { get; set; }
        public ICollection<CommentEntity>? Comments { get; set; }
    }
}