namespace Lab13.Models
{
    public class Product
    {
        public int IdProducts { get; set; }
        public string Name { get; set; }
        public float Price { get; set; }
        public bool IsDeleted { get; set; }  
        public ICollection<Detail> Details { get; set; }
    }

}
