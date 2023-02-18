using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TodoApp.Dominio.Genericos.Entidades
{
    public class Paginacao<T> where T : class
    {
        public int TotalItems { get; set; }
        public int Pagina { get; set; }
        public int Quantidade { get; set; }
        public IList<T> Lista { get; set; } = new List<T>();
    }
}
