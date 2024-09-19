namespace FeedbackApplication.Models
{
    public class Opinion
    {
        public int Id { get; set; }
        public string Message { get; set; }
        public DateTime Time { get; set; } = DateTime.UtcNow;
        public bool IsDeleted { get; set; }=false;
    }
}
