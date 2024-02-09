using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using apiTasks.Context;
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
           if(task.Date == DateTime.MinValue)
            return BadRequest(new{Erro = "Date can't be null"});

            _context.TaskToMades.Add(task);
            _context.SaveChanges();

    
          return CreatedAtAction(nameof(ObterPorId), new { id = task.Id }, task);
        }

        [HttpDelete]
        public IActionResult DeleteTask(int id)
        {
            var idTask = _context.TaskToMades.Find(id);

            if(idTask == null)
            return BadRequest(new{Error = "This Id doesn't exist in our database." });

            _context.TaskToMades.Remove(idTask);
            _context.SaveChanges();

            return Ok(idTask);
        }


        [HttpGet("{id}")]
        public IActionResult ObterPorId(int id)
        {
            var idTask = _context.TaskToMades.Find(id);
            
            if(idTask == null)
                return NotFound();

            return Ok(idTask);
        }

        [HttpPut("{id}")]
        public IActionResult AtualizarTarefa(int id, TaskToMade task)
        {
            var idTask = _context.TaskToMades.Find(id);

            if(idTask == null)
                return  NotFound();

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

        
    }
}