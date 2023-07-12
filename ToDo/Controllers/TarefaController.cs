using System.Collections.Generic;
using System.Linq;
using ToDo.Models;

namespace ToDo.Controllers
{
    public class TarefaController
    {
        private List<Tarefa> tasks;

        public TarefaController()
        {
            tasks = new List<Tarefa>();
        }

        public List<Tarefa> GetAllTasks()
        {
            return tasks;
        }

        public Tarefa GetTaskById(int id)
        {
            return tasks.FirstOrDefault(t => t.Id == id);
        }

        public void AddTask(Tarefa task)
        {
            tasks.Add(task);
        }

        public void UpdateTask(Tarefa updatedTask)
        {
            var task = tasks.FirstOrDefault(t => t.Id == updatedTask.Id);
            if (task != null)
            {
                task.Descricao = updatedTask.Descricao;
                task.Completo = updatedTask.Completo;
            }
        }

        public void DeleteTask(int id)
        {
            var task = tasks.FirstOrDefault(t => t.Id == id);
            if (task != null)
            {
                tasks.Remove(task);
            }
        }
    }
}
