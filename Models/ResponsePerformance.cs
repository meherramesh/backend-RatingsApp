namespace RatingsApp.Models
{
    public class ResponsePerformance
    {
        public int Id { get; set; }
        public int SupplierId { get; set; }

        public string ResponseRating { get; set; }
        public int Score { get; set; }
    }
}
