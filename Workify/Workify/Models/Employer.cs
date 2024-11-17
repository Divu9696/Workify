using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace Workify.Models
{
    public class Employer
    {
        public int EmployerId { get; set; }
        public int UserId { get; set; }
        public int CompanyId { get; set; }

        // Navigation Properties
        public User User { get; set; }
        public ICollection<Company> Companies { get; set; } = new List<Company>();
        // public Company Company { get; set; }
    }

}
