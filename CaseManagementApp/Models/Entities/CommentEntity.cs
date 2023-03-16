namespace CaseManagementApp.Models.Entities
{
    public class CommentEntity
    {
        public int Id { get; set; }
        public string Comment { get; set; } = null!;
        public DateTime Timestamp { get; set; }

        public int CaseId { get; set; }
        public virtual CaseEntity? Case { get; set; }
    }
}