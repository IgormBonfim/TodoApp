using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TodoApp.Infra.Configs
{
    public static class ConnectionHelper
    {
        public static string GetConnectionString()
        {
            return Environment.GetEnvironmentVariable("ConnectionString");
        }
    }
}
