using CQRS.Infrastructure.Model;
using CQRS_WriteService_.EventSourcing.EventResponse;

namespace CQRS_WriteService_.EventSourcing
{
    public interface IEvent
    {
        bool Created(ProductEvent productEvent, string topic);
        bool Deleted(ProductEvent productEvent, string topic);
        bool Updated(ProductEvent productEvent, string topic);
    }
}
