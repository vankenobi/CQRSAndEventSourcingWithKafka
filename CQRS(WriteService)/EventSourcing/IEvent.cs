using CQRS.Infrastructure.Model;

namespace CQRS_WriteService_.EventSourcing
{
    public interface IEvent
    {
        bool Created(Product product, string topic);
        bool Deleted(Guid id, string topic);
        bool Updated(Product product, string topic);
    }
}
