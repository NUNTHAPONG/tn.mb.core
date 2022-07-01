namespace Web.Models.Entites
{
    public class Customers : EntityBase
    {
        public int CustomerId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string? Phone { get; set; }
        public string Email { get; set; }
        public string? Street { get; set; }
        public string? City { get; set; }
        public string? State { get; set; }
        public string? ZipCode { get; set; }

        public virtual ICollection<Orders> Orders { get; } = new List<Orders>();

    }
}
