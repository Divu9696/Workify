using static System.Net.Mime.MediaTypeNames;

namespace Workify.Models
{
    public class JobSeeker
    {
        public int SeekerId { get; set; }
        public int UserId { get; set; }
        public string ProfileSummary { get; set; } = string.Empty;
        public string Experience { get; set; } = string.Empty;
        public string Skills { get; set; } = string.Empty;  

        // Navigation Properties
        public User User { get; set; }
        public ICollection<Resume> Resumes { get; set; }
        public ICollection<Application> Applications { get; set; }
        public ICollection<SearchHistory> SearchHistories { get; set; }
    }

}
