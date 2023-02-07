using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TodoApp.Aplicacao.Tarefas.Profiles;
using TodoApp.Aplicacao.Tarefas.Servicos;
using TodoApp.Aplicacao.Tarefas.Servicos.Interfaces;
using TodoApp.Dominio.Tarefas.Repositorios;
using TodoApp.Dominio.Tarefas.Servicos;
using TodoApp.Dominio.Tarefas.Servicos.Interfaces;
using TodoApp.Infra.Configs;
using TodoApp.Infra.Configs.Interfaces;
using TodoApp.Infra.Tarefas;

namespace TodoApp.Ioc
{
    public static class NativeInjectorBootStrapper
    {
        public static void RegistrarServicos(this IServiceCollection services, IConfiguration configuration)
        {
            services.Configure<DatabaseConfig>(configuration.GetSection(nameof(DatabaseConfig)));
            services.AddSingleton<IDatabaseConfig>(x => x.GetRequiredService<IOptions<DatabaseConfig>>().Value);

            services.AddScoped<ITarefasAppServico, TarefasAppServico>();
            services.AddScoped<ITarefasServico, TarefasServico>();
            services.AddScoped<ITarefasRepositorio, TarefasRepositorio>();

            services.AddAutoMapper(typeof(TarefasProfile));
        }
    }
}
