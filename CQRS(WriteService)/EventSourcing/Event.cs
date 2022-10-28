using Confluent.Kafka;
using CQRS.Infrastructure.Model;
using System.Net;
using Newtonsoft;
using CQRS_WriteService_.EventSourcing.EventResponse;

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

     

        public bool Created(ProductEvent productEvent, string topic)
        {
            using (var producer = new ProducerBuilder<string, string>(_producerConfig).Build())
            {
                producer.Produce(topic, new Message<string, string>() { Key = "Add", Value = Newtonsoft.Json.JsonConvert.SerializeObject(productEvent) });
            }
            return true;
        }

        public bool Deleted(ProductEvent productEvent, string topic)
        {
            using (var producer = new ProducerBuilder<string, string>(_producerConfig).Build())  
            {
                producer.Produce(topic, new Message<string, string>() { Key = "Delete", Value = Newtonsoft.Json.JsonConvert.SerializeObject(productEvent) });
            }
            return true;
        }

        public bool Updated(ProductEvent productEvent, string topic)
        {
            using (var producer = new ProducerBuilder<string, string>(_producerConfig).Build())
            {
                producer.Produce(topic, new Message<string, string>() { Key = "Update", Value = Newtonsoft.Json.JsonConvert.SerializeObject(productEvent) });
            }
            return true;
        }
    }
}
