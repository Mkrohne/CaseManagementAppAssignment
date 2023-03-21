namespace CaseManagementApp.Models
{
    public class Case
    {
        public int Id { get; set; } 
        public string Title { get; set; } = null!;
        public string Description { get; set; } = null!;
        public DateTime CreationDate { get; set; }
        public DateTime UpdatedAt { get; set; } 
        public string Status { get; set; } = null!;
        public string CreatedBy { get; set; } = null!;
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string PhoneNumber { get; set; } = null!;

    }
}
