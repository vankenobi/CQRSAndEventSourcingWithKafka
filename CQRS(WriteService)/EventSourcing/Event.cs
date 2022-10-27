using Confluent.Kafka;
using CQRS.Infrastructure.Model;
using System.Net;
using Newtonsoft;

namespace CQRS_WriteService_.EventSourcing
{
    public class Event : IEvent
    {
        private readonly ProducerConfig _producerConfig;

        public Event() 
        {
            _producerConfig = new ProducerConfig()
            {
                BootstrapServers = "localhost:9092",
                ClientId = Dns.GetHostName()
            };
        }

     

        public bool Created(Product product, string topic)
        {
            using (var producer = new ProducerBuilder<string, string>(_producerConfig).Build())
            {
                producer.Produce(topic, new Message<string, string>() { Key = "Add", Value = Newtonsoft.Json.JsonConvert.SerializeObject(product) });
            }
            return true;
        }

        public bool Deleted(Guid id, string topic)
        {
            using (var producer = new ProducerBuilder<string, Guid>(_producerConfig).Build())
            {
                producer.Produce(topic, new Message<string, Guid>() { Key = "Delete", Value = id });
            }
            return true;
        }

        public bool Updated(Product product, string topic)
        {
            using (var producer = new ProducerBuilder<string, Product>(_producerConfig).Build())
            {
                producer.Produce(topic, new Message<string, Product>() { Key = "Update", Value = product });
            }
            return true;
        }
    }
}
