using FizzWare.NBuilder;
using FluentAssertions;
using NSubstitute;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TodoApp.Dominio.Tarefas.Entidades;
using TodoApp.Dominio.Tarefas.Enumeradores;
using TodoApp.Dominio.Tarefas.Repositorios;
using TodoApp.Dominio.Tarefas.Servicos;
using TodoApp.Dominio.Tarefas.Servicos.Comandos;
using Xunit;

namespace TodoApp.Dominio.Testes.Tarefas.Servicos
{
    public class TarefasServicoTestes
    {
        private readonly TarefasServico sut;
        private readonly ITarefasRepositorio tarefasRepositorio;

        private readonly Tarefa tarefaValida;

        public TarefasServicoTestes()
        {
            tarefaValida = Builder<Tarefa>.CreateNew().Build();

            tarefasRepositorio = Substitute.For<ITarefasRepositorio>();

            sut = new TarefasServico(tarefasRepositorio);
        }

        public class ValidarMetodo : TarefasServicoTestes
        {
            [Fact]
            public void Quando_TarefaNaoForEncontrada_Espero_Exception()
            {
                tarefasRepositorio.Recuperar(Arg.Any<string>()).Returns(x => null);

                sut.Invoking(x => x.Validar("string")).Should().Throw<Exception>();
            }

            [Fact]
            public void Quando_TarefaForEncontrada_Espero_TarefaValida()
            {
                tarefasRepositorio.Recuperar(Arg.Any<string>()).Returns(tarefaValida);
                sut.Validar("string").Should().BeSameAs(tarefaValida);
            }
        }

        public class InstanciarMetodo : TarefasServicoTestes
        {
            [Fact]
            public void Dado_ParametrosValidos_Espero_TarefaInstanciada()
            {
                var tarefa = sut.Instanciar("Nome da Tarefa", "Detalhes da Tarefa");
                tarefa.Should().NotBeNull();
            }
        }

        public class AtualizarMetodo : TarefasServicoTestes
        {
            [Fact]
            public void Dado_ParametroValidos_Espero_TarefaAtualizada()
            {
                tarefaValida.SetDataConclusao(null);

                tarefasRepositorio.Recuperar(Arg.Any<string>()).Returns(tarefaValida);

                var tarefaComando = new TarefaAtualizarComando();

                tarefaComando.Id = "Id da tarefa";
                tarefaComando.Nome = "Tarefa Atualizada";
                tarefaComando.Detalhes = "Detalhes atualizado";
                tarefaComando.Status = StatusTarefaEnum.Andamento;

                var tarefa = sut.Atualizar(tarefaComando);

                tarefa.Id.Should().Be(tarefa.Id);
                tarefa.Nome.Should().Be(tarefaComando.Nome);
                tarefa.Detalhes.Should().Be(tarefaComando.Detalhes);
                tarefa.Status.Should().Be(tarefaComando.Status);
                tarefa.DataAtualizacao.Should().HaveValue();
                tarefa.DataConclusao.Should().BeNull();
            }

            [Fact]
            public void Dado_TarefaJaConcluida_Espero_Exception()
            {
                tarefaValida.SetStatus(StatusTarefaEnum.Concluida);
                tarefasRepositorio.Recuperar(Arg.Any<string>()).Returns(tarefaValida);

                var tarefaComando = new TarefaAtualizarComando();

                tarefaComando.Id = "Id da tarefa";
                tarefaComando.Detalhes = "Detalhes atualizado";

                sut.Invoking(x => x.Atualizar(tarefaComando)).Should().Throw<Exception>();
            }

            [Fact]
            public void Dado_StatusConcluido_Espero_DataConclusaoPreenchida()
            {
                tarefasRepositorio.Recuperar(Arg.Any<string>()).Returns(tarefaValida);

                var tarefaComando = new TarefaAtualizarComando();

                tarefaComando.Status = StatusTarefaEnum.Concluida;

                var tarefa = sut.Atualizar(tarefaComando);

                tarefa.DataConclusao.Should().HaveValue();
            }
        }

        public class InserirMetodo : TarefasServicoTestes
        {
            [Fact]
            public void Dado_TarefaValida_Espero_TarefaInserida()
            {
                sut.Inserir(tarefaValida);
                tarefasRepositorio.Received(1).Adicionar(tarefaValida);
            }
        }

        public class ExcluirMetodo : TarefasServicoTestes
        {
            [Fact]
            public void Dado_IdValido_EsperoTarefaExcluida()
            {
                tarefasRepositorio.Recuperar(Arg.Any<String>()).Returns(tarefaValida);

                string id = "Id da tarefa";

                sut.Excluir(id);

                tarefasRepositorio.Received(1).Excluir(id);
            }
        }
    }
}