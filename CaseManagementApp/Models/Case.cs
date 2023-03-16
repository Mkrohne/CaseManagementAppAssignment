namespace CaseManagementApp.Models
{
    internal class Case
    {
        public int Id { get; set; }
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string PhoneNumber { get; set; } = null!;
        public string Description { get; set; } = null!;
        public DateTime CreatedAt { get; set; }
        public CaseStatus Status { get; set; }
        public List<Comment>? Comments { get; set; } 
    }

    public enum CaseStatus
    {
        Unstarted,
        Ongoing,
        Completed
    }

    public class Comment
    {
        public int Id { get; set; }
        public string Text { get; set; } = null!;           
        public DateTime CreatedAt { get; set; }
    }
}

