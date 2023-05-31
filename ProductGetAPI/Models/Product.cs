using ProductGetAPI.Models.Abstractions;

namespace ProductGetAPI.Models
{
    public class Product : Entity
    {
        public Product(string name)
        {
            Id = Guid.NewGuid();
            Name = name;
        }

        public string Name { get; set; }
    }
}
