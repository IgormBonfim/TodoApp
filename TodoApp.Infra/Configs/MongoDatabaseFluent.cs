using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TodoApp.Infra.Configs
{
    public class MongoDatabaseFluent
    {
        public static MongoDatabaseConfiguration Configure()
        {
            return new MongoDatabaseConfiguration();
        }
    }
}
