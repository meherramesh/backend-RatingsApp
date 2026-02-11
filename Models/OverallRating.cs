namespace RatingsApp.Models
{
    public class OverallRating
    {
        public int Id { get; set; }
        public int SupplierId { get; set; }

        public int OverallScore { get; set; }
        public string Category { get; set; }
    }
}
