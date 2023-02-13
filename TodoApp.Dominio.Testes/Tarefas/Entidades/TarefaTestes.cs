using FizzWare.NBuilder;
using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TodoApp.Dominio.Tarefas.Entidades;
using TodoApp.Dominio.Tarefas.Enumeradores;
using Xunit;

namespace TodoApp.Dominio.Testes.Tarefas.Entidades
{
    public class TarefaTestes
    {
        private readonly Tarefa sut;

        public TarefaTestes()
        {
            sut = Builder<Tarefa>.CreateNew().Build();
        }

        public class Construtor
        {
            [Fact]
            public void Quando_ParametrosForemValidos_Espero_ObjetoIntegro()
            {
                string nome = "Nome da tarefa";
                string detalhes = "Detalhes da tarefa";
                StatusTarefaEnum status = StatusTarefaEnum.Aguardando;

                DateTime agora = DateTime.Now;

                var tarefa = new Tarefa(nome, detalhes, status);

                tarefa.Nome.Should().Be(nome);
                tarefa.Detalhes.Should().Be(detalhes);
                tarefa.Status.Should().Be(status);
                tarefa.DataCadastro.Should().BeAfter(agora);
                tarefa.DataAtualizacao.Should().BeNull();
                tarefa.DataConclusao.Should().BeNull();
            }
        }

        public class SetNomeMetodo : TarefaTestes
        {
            [Theory]
            [InlineData(null)]
            [InlineData(" ")]
            [InlineData("")]
            public void Quando_AtributoForNuloOuEspacoEmBranco_Espero_Excecao(string nome)
            {
                sut.Invoking(x => x.SetNome(nome)).Should().Throw<Exception>();
            }

            [Fact]
            public void Dado_NomeComMenosDeQuatroCaracteres_Espero_Exception()
            {
                sut.Invoking(x => x.SetNome("ee")).Should().Throw<Exception>();
            }

            [Fact]
            public void Quando_NomeForValido_Espero_PropriedadePreenchida()
            {
                string nome = "Nome de Tarefa";

                sut.SetNome(nome);
                sut.Nome.Should().Be(nome);
            }
        }

        public class SetDetalhesMetodo : TarefaTestes
        {
            [Theory]
            [InlineData(null)]
            [InlineData(" ")]
            [InlineData("")]
            public void Quando_AtributoForNuloOuEspacoEmBranco_Espero_Excecao(string nome)
            {
                sut.Invoking(x => x.SetDetalhes(nome)).Should().Throw<Exception>();
            }

            [Fact]
            public void Dado_DetalhesComMenosDeSeisCaracteres_Espero_Exception()
            {
                sut.Invoking(x => x.SetDetalhes("eeee")).Should().Throw<Exception>();
            }

            [Fact]
            public void Quando_DetalhesForValido_Espero_PropriedadePreenchida()
            {
                string detalhes = "Detalhes da Tarefa";

                sut.SetDetalhes(detalhes);
                sut.Detalhes.Should().Be(detalhes);
            }
        }

        public class SetStatusMetodo : TarefaTestes
        {
            [Fact]
            public void Quando_ParametroForValido_Espero_PropriedadePreenchida()
            {
                StatusTarefaEnum status = StatusTarefaEnum.Andamento;

                sut.SetStatus(status);

                sut.Status.Should().Be(status);
            }
        }

        public class SetDataConclusao : TarefaTestes
        {
            [Fact]
            public void Quando_ParametroForValido_Espero_PropriedadePreenchida()
            {
                DateTime data = DateTime.Now;

                sut.SetDataConclusao(data);

                sut.DataConclusao.Should().Be(data);
            }
        }
    }
}