using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TodoApp.Dominio.Genericos.Entidades
{
    public class Entidade
    {
        public string Id { get; protected set; }

        public Entidade()
        {
            SetId();
        }

        public void SetId()
        {
            Id = Guid.NewGuid().ToString();
        }
    }
}
