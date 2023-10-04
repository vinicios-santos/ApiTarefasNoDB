using System;
using TreinamentoApi.Dominio.Todos;

namespace TreinamentoApi.Aplicacao.Todos.Views
{
    public class TodoView
    {
        public Guid Id { get; set; }
        public DateTime DataHoraCadastro { get; set; }
        public string Nome { get; set; }
        public EnumStatusTarefa Status { get; private set; }
        public bool Completa { get; set; }

        public TodoView Novo(Todo todo)
        {
            Id = todo.Id;
            DataHoraCadastro = todo.DataHoraCadastro;
            Nome = todo.Nome;
            Status = todo.Status;

            return this;
        }
    }
}
