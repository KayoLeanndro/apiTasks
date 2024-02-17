using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using apiTasks.Context;
using apiTasks.Enums;
using apiTasks.Models;
using Microsoft.AspNetCore.Mvc;

namespace apiTasks.Controllers
{
    [ApiController]
    [Route("[Controller]")]
    public class TaskController : ControllerBase
    {
        private readonly ContextDB _context;

        public TaskController(ContextDB context)
        {
            _context = context;
        }

        [HttpPost]
        public IActionResult AddTask(TaskToMade task)
        {
            if (task.Date == DateTime.MinValue)
                return BadRequest(new { Erro = "Date can't be null" });

            _context.TaskToMades.Add(task);
            _context.SaveChanges();


            return CreatedAtAction(nameof(ObterPorId), new { id = task.Id }, task);
        }

        [HttpDelete]
        public IActionResult DeleteTask(int id)
        {
            var tarefaBanco = _context.TaskToMades.Find(id);

            if (tarefaBanco == null)
                return NotFound();

            _context.TaskToMades.Remove(tarefaBanco);
            _context.SaveChanges();
            return NoContent();
        }



        [HttpPut("{id}")]
        public IActionResult AtualizarTarefa(int id, TaskToMade task)
        {
            var idTask = _context.TaskToMades.Find(id);

            if (idTask == null)
                return NotFound();

            if (idTask.Date == DateTime.MinValue)
                return BadRequest(new { Erro = "A data da tarefa não pode ser vazia" });

            idTask.Title = task.Title;
            idTask.Description = task.Description;
            idTask.Date = task.Date;
            idTask.TaskStatus = task.TaskStatus;

            _context.TaskToMades.Add(idTask);
            _context.SaveChanges();
            return Ok();
        }

        [HttpGet("{id}")]
        public IActionResult ObterPorId(int id)
        {
            var idTask = _context.TaskToMades.Find(id);

            if (idTask == null)
                return NotFound();

            return Ok(idTask);
        }

        [HttpGet("ObterTodos")]

        public IActionResult ObterTodos()
        {
            var taskList = _context.TaskToMades.ToList();

            return Ok(taskList);
        }

        [HttpGet("ObterPorTitulo")]
        public IActionResult obterPorTitulo(string title)
        {
            var taskTittle = _context.TaskToMades.Where(t => t.Title.Contains(title)).ToList();

            return Ok(taskTittle);
        }

        [HttpGet("ObterPorData")]

        public IActionResult ObterPorData(DateTime date)
        {
            var tarefa = _context.TaskToMades.Where(t => t.Date.Date == date.Date);
            return Ok(tarefa);
        }

        [HttpGet("ObterPorStatus")]

        public IActionResult ObterPorStatus(TaskStatus status)
        {
        try
            {
                var tarefas = _context.TaskToMades.Where(x => x.TaskStatus == x.TaskStatus).ToList();

                if (tarefas == null || tarefas.Count == 0)
                {
                    return NotFound("Nenhuma tarefa encontrada com o status especificado.");
                }

                return Ok(tarefas);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Ocorreu um erro ao processar a solicitação: {ex.Message}");
            }
        }



    }
}