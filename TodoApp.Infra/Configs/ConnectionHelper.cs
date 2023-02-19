using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TodoApp.Infra.Configs
{
    public static class ConnectionHelper
    {
        public static DatabaseConfig GetConnectionString()
        {
            return new DatabaseConfig
            {
                ConnectionString = "mongodb://mongo:yNnx8uHYWq7F9rj6x6zT@containers-us-west-66.railway.app:6983/admin",
                DatabaseName = "TodoAppManager",
            };
        }
    }
}
