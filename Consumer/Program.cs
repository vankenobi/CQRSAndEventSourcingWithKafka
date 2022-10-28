using Confluent.Kafka;
using System;
using Newtonsoft;
using Consumer.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace Consumer 
{
    public class Program
    {
        
        static void Main(string[] args)
        {
            
            var config = new ConsumerConfig()
            {
                BootstrapServers = "localhost:9092",
                GroupId = "messageConsumer",
                EnableAutoCommit = false,
            };

            using (var consumer = new ConsumerBuilder<string, string>(config).Build())
            {
                var context = new PsqlContext();
                consumer.Subscribe("product");
                CancellationTokenSource cancelationToken = new();

                while (true)
                {
                    var consumeResult = consumer.Consume();
                    var productEvent = Newtonsoft.Json.JsonConvert.DeserializeObject<ProductEvent>(consumeResult.Message.Value);
                    if (productEvent.CrudType == "Add")
                    {
                        context.Products.Add(productEvent.Product);
                        context.SaveChanges();
                    }
                    else if (productEvent.CrudType == "Delete")
                    {
                        context.Products.Remove(productEvent.Product);
                        context.SaveChanges();
                    }
                    else if (productEvent.CrudType == "Update")
                    {
                        context.Products.Update(productEvent.Product);
                        context.SaveChanges();
                    }
                    Console.WriteLine(consumeResult.Value);
                    consumer.Commit();
                }
                consumer.Close();
            }
        }
    }
}