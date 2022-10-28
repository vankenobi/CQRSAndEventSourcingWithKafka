using CQRS.Infrastructure.Model;

namespace CQRS_WriteService_.EventSourcing.EventResponse
{
    public class ProductEvent
    {
        public Product Product { get; set; }
        public string  CrudType { get; set; }
    }
}
