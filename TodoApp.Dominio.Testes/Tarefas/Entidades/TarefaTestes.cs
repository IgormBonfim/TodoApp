using FizzWare.NBuilder;
using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TodoApp.Dominio.Tarefas.Entidades;
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

                DateTime agora = DateTime.Now;

                var tarefa = new Tarefa(nome, detalhes);

                tarefa.Nome.Should().Be(nome);
                tarefa.Detalhes.Should().Be(detalhes);
                tarefa.DataCadastro.Should().BeAfter(agora);
                tarefa.Concluido.Should().BeFalse();
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
    }
}
