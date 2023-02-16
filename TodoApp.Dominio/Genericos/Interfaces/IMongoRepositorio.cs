using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TodoApp.Dominio.Genericos.Entidades;
using TodoApp.Dominio.Tarefas.Entidades;

namespace TodoApp.Dominio.Genericos.Interfaces
{
    public interface IMongoRepositorio<T> where T : Entidade
    {
        T Adicionar(T entidade);
        T Atualizar(string id, T entidade);
        IList<T> Listar();
        T Recuperar(string id);
        void Excluir(string id);
    }
}
