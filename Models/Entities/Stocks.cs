namespace Web.Models.Entites
{
    public class Stocks : EntityBase
    {
        public int StoreId { get; set; }
        public int ProductId { get; set; }
        public int? Quantity { get; set; }
    }
}
