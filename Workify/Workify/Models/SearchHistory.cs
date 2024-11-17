namespace Workify.Models
{
    public class SearchHistory
    {
        public int SearchId { get; set; }
        public int SeekerId { get; set; }
        public string SearchCriteria { get; set; } = string.Empty;
        public DateTime SearchDate { get; set; }
        public DateTime Timestamp { get; set; }

        // Navigation Properties
        public JobSeeker JobSeeker { get; set; } 
    }

}
