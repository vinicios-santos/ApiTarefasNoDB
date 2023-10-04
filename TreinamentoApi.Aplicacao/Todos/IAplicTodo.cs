using System;
using System.Collections.Generic;
using TreinamentoApi.Aplicacao.Todos.DTOs;
using TreinamentoApi.Aplicacao.Todos.Views;

namespace TreinamentoApi.Aplicacao.Todos
{
    public interface IAplicTodo
    {
        List<TodoView> Listar();
        TodoView ListarPorId(Guid id);
        TodoView Inserir(TodoDto dto);
        TodoView Alterar(Guid id, TodoDto dto);
        void Deletar(Guid id);

        TodoView CompletarTarefa(Guid id);

        TodoView FazendoTarefa(Guid id);
    }
}
