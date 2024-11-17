namespace Workify.Models
{
    public class JobListing
    {
        public int JobId { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public string Qualifications { get; set; } = string.Empty;
        public decimal Salary { get; set; }
        public string JobType { get; set; } = string.Empty;
        public string ReqSkills { get; set; } = string.Empty;
        public string Location { get; set; } = string.Empty;
        public string Industry { get; set; } = string.Empty;
        public int EmployerId { get; set; }
        public int CompanyId { get; set; }

        // Navigation Properties
        public Employer Employer { get; set; }
        public Company Company { get; set; }
        public ICollection<Application> Applications { get; set; } = new List<Application>();
    }

}
