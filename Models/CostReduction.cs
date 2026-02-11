namespace RatingsApp.Models
{
    public class CostReduction
    {
        public int Id { get; set; }
        public int SupplierId { get; set; }

        public decimal CostReductionPercentage { get; set; }
        public int Score { get; set; }
    }
}
