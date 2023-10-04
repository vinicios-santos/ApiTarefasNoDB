using System;
using System.Collections.Generic;
using System.Linq;
using TreinamentoApi.Aplicacao.Auxiliares;
using TreinamentoApi.Aplicacao.Todos.DTOs;
using TreinamentoApi.Aplicacao.Todos.Views;
using TreinamentoApi.Dominio.Todos;

namespace TreinamentoApi.Aplicacao.Todos
{
    public class AplicTodo : IAplicTodo
    {
        public AplicTodo() {
            AuxiliarTodo.TodosDb ??= new List<Todo>();
        }
        public List<TodoView> Listar()
        {
            return AuxiliarTodo.TodosDb.Select(t => new TodoView().Novo(t)).ToList();
        }

        public TodoView ListarPorId(Guid id)
        {
            var todo = RetornarRegistroValido(id);

            return new TodoView().Novo(todo);
        }

        public TodoView Inserir(TodoDto dto)
        {
            if(string.IsNullOrEmpty(dto.Nome))
                throw new Exception("Insira o nome");

            var todo = new Todo(dto.Nome);

            AuxiliarTodo.TodosDb.Add(todo);

            return new TodoView().Novo(todo);
        }

        public TodoView Alterar(Guid id, TodoDto dto)
        {
            var todo = RetornarRegistroValido(id);

            if (string.IsNullOrEmpty(dto.Nome))
                throw new Exception("Não foi possivel alterar o registro");


            todo.Alterar(dto.Nome);

            return new TodoView().Novo(todo);
        }

        public void Deletar(Guid id)
        {
            var todo = RetornarRegistroValido(id);

            AuxiliarTodo.TodosDb.Remove(todo);
        }

        public TodoView CompletarTarefa(Guid id)
        {
            var todo = RetornarRegistroValido(id);

            todo.IsCompleta();

            return new TodoView().Novo(todo);  

        }

        public TodoView FazendoTarefa(Guid id)
        {
            var todo = RetornarRegistroValido(id);

            todo.IsFazendo();

            return new TodoView().Novo(todo);

        }

        private Todo RetornarRegistroValido(Guid id)
        {
            var todo = AuxiliarTodo.TodosDb.SingleOrDefault(t => t.Id == id);

            if (todo == null)
                throw new Exception("Não encontrado registro com esse id: " + id);

            return todo;
        }
    }
}
