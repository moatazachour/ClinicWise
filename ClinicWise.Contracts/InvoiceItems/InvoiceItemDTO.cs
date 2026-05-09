namespace ClinicWise.Contracts.InvoiceItems
{
    public class InvoiceItemDTO
    {
        public int ItemID { get; set; }
        public int InvoiceID { get; set; }
        public string Description { get; set; }
        public int Quantity { get; set; }
        public decimal UnitPrice { get; set; }
        public decimal TotalPrice { get; set; }
        public int? VisitFeeID { get; set; }
    }
}
