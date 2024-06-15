namespace Lab13.Models
{
    public class Customer
    {
        public int IdCustomers { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string DocumentNumber { get; set; }
        public bool IsDeleted { get; set; }  
        public ICollection<Invoice> Invoices { get; set; }
    }

}