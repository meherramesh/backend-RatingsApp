namespace RatingsApp.Models
{
    public class DeliveryPerformance
    {
        public int Id { get; set; }
        public int SupplierId { get; set; }

        public int OnTimeDeliveryScore { get; set; }
        public int PremiumFreightScore { get; set; }

        public int TotalScore { get; set; }
    }
}
