public class RatingAppForm
{
    public required string SupplierName { get; set; }
    public required string VendorCode { get; set; }
    public required string ReportPeriod { get; set; }

    public int RejectionPPM { get; set; }
    public int LineStoppage { get; set; }
}
