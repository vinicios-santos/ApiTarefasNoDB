using System;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using TreinamentoApi.Aplicacao.Todos;
using TreinamentoApi.Aplicacao.Todos.DTOs;

namespace TreinamentoApi.Controllers.Todos
{
    [ApiController]
    [Route("Todo")]
    public class TodoController : ControllerBase
    {
        private readonly IAplicTodo _aplicTodo;
        public TodoController(IAplicTodo aplicTodo)
        {
            _aplicTodo = aplicTodo;
        }

        [HttpGet]
        [Route("/Todo")]
        public IActionResult Recuperar()
        {
            try
            {
                var todos = _aplicTodo.Listar();
                return Ok(todos);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        [Route("/Todo/{id:guid}")]
        public IActionResult RecuperarPorId([FromRoute] Guid id)
        {
            try
            {
                var todo = _aplicTodo.ListarPorId(id);
                return Ok(todo);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        [Route("/Todo")]
        public IActionResult Inserir([FromBody] TodoDto dto)
        {
            try
            {
                var todo = _aplicTodo.Inserir(dto);
                return Ok(todo);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut]
        [Route("/Todo/{id:guid}")]
        public IActionResult Alterar([FromRoute] Guid id, [FromBody] TodoDto dto)
        {
            try
            {
                var todo = _aplicTodo.Alterar(id, dto);
                return Ok(todo);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut]
        [Route("/Todo/{id:guid}/Completar")]
        public IActionResult CompletarTarefa([FromRoute] Guid id)
        {
            try
            {
                var todo = _aplicTodo.CompletarTarefa(id);
                return Ok(todo);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut]
        [Route("/Todo/{id:guid}/FazendoTarefa")]
        public IActionResult FazendoTarefa([FromRoute] Guid id)
        {
            try
            {
                var todo = _aplicTodo.CompletarTarefa(id);
                return Ok(todo);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete]
        [Route("/Todo/{id:guid}")]
        public IActionResult Deletar([FromRoute] Guid id)
        {
            try
            {
                _aplicTodo.Deletar(id);
                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
