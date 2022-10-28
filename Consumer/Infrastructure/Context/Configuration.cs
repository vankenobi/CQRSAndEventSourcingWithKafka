using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Consumer.Infrastructure.Context
{
    static class Configuration
    {
        static public string ConnectionString
        {
            get 
            {
                return "Host=localhost; Port=5433; Database=cqrsreaddb; Username=postgres; Password=123456;";
            }
        }
        
    }
}
