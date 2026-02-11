namespace RatingsApp.Models
{
    public class Supplier
    {
        public int Id { get; set; }
        public string SupplierName { get; set; }
        public string VendorCode { get; set; }
        public string ReportPeriod { get; set; }


        public QualityPerformance QualityPerformance { get; set; }
        public DeliveryPerformance DeliveryPerformance { get; set; }
        public CostReduction CostReduction { get; set; }
        public PaymentTerms PaymentTerms { get; set; }
        public ResponsePerformance ResponsePerformance { get; set; }
        public OverallRating OverallRating { get; set; }
    }
}
