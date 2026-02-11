namespace RatingsApp.Models
{
    public class PaymentTerms
    {
        public int Id { get; set; }
        public int SupplierId { get; set; }

        public int CreditDays { get; set; }
        public int Score { get; set; }
    }
}
