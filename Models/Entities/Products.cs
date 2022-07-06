namespace Web.Models.Entities
{
    public class Products : EntityBase
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public int BrandId { get; set; }
        public int CategoryId { get; set; }
        public int ModelYear { get; set; }
        public decimal? ListPrice { get; set; }
        public Brands Brands { get; } = new Brands();
        public Categories Categories { get; } = new Categories();
    }
}
