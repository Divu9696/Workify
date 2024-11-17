namespace Workify.Models
{
    public class Resume
    {
        public int ResumeId { get; set; }
        public int SeekerId { get; set; }

        public byte[] ResumeData { get; set; } = Array.Empty<byte>();
        public DateTime LastUpdated { get; set; }

        // Navigation Properties
        public JobSeeker JobSeeker { get; set; }
        public ICollection<Application> Applications { get; set; } = new List<Application>();
    }

}
