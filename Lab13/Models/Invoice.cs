namespace Lab13.Models
{
    public class Invoice
    {
        public int IdInvoices { get; set; }
        public int IdCustomers { get; set; }
        public DateTime Date { get; set; }
        public string InvoiceNumber { get; set; }
        public float Total { get; set; }
        public Customer Customer { get; set; }
        public ICollection<Detail> Details { get; set; }
    }
}
