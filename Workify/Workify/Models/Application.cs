namespace Workify.Models
{
    public class Application
    {
        public int ApplicationId { get; set; }
        public int SeekerId { get; set; }
        public int JobId { get; set; }
        public byte[] Resume { get; set; } =  Array.Empty<byte>();
        public string Status { get; set; }
        public DateTime AppliedOn { get; set; }
        // Foreign Key for JobListing
        public int JobListingId { get; set; }

        // Navigation Properties
        public JobSeeker JobSeeker { get; set; }
        public JobListing JobListing { get; set; }
    }

}
