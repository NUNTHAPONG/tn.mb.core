using Web.Models.Entities;

namespace Web.Models.Entities
{
    public class Brands : EntityBase
    {
        public int BrandId { get; set; }
        public string BrandName { get; set; }
    }
}
