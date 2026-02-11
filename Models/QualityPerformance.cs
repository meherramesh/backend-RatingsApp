namespace RatingsApp.Models
{
    public class QualityPerformance
    {
        public int Id { get; set; }
        public int SupplierId { get; set; }
        public int RejectionPpmScore { get; set; }
        public int LineStoppageScore { get; set; }
        public int CorrectiveActionScore { get; set; }
        public int CertificationScore { get; set; }
        public int TotalScore { get; set; }
    }
}
