using Consumer.Infrastructure.Model;

namespace Consumer
{
    public class ProductEvent
    {
        public Product Product { get; set; }
        public string  CrudType { get; set; }
    }
}
