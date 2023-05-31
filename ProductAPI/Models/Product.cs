using ProductAPI.Models.Abstractions;

namespace ProductAPI.Models
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
