using System;
using System.Linq;
using ToDo.Controllers;
using ToDo.Models;

namespace ToDo.Views
{
    public class ListaTarefaView
    {
        private TarefaController controller;

        public ListaTarefaView(TarefaController taskController)
        {
            controller = taskController;
        }

        public void DisplayTasks()
        {
            Console.WriteLine("Lista de Tarefas:");
            Console.WriteLine("------------------");
            var tasks = controller.GetAllTasks();
            foreach (var task in tasks)
            {
                Console.WriteLine($"ID: {task.Id}, Descrição: {task.Descricao}, Concluída: {task.Completo}");
            }
            Console.WriteLine();
        }

        public void AddTask()
        {
            Console.WriteLine("Adicionar uma nova tarefa:");
            Console.Write("Descrição: ");
            string description = Console.ReadLine();
            Tarefa newTask = new Tarefa
            {
                Id = GenerateTaskId(),
                Descricao = description,
                Completo = false
            };
            controller.AddTask(newTask);
            Console.WriteLine("Tarefa adicionada com sucesso!");
            Console.WriteLine();
        }

        public void UpdateTask()
        {
            Console.WriteLine("Atualizar uma tarefa:");
            Console.Write("ID da tarefa: ");
            int id = int.Parse(Console.ReadLine());
            Tarefa existingTask = controller.GetTaskById(id);
            if (existingTask != null)
            {
                Console.WriteLine($"Tarefa encontrada. Descrição atual: {existingTask.Descricao}");
                Console.Write("Nova descrição: ");
                string newDescription = Console.ReadLine();
                Console.Write("Concluída (S/N): ");
                bool completed = Console.ReadLine().ToUpper() == "S";
                Tarefa updatedTask = new Tarefa
                {
                    Id = existingTask.Id,
                    Descricao = newDescription,
                    Completo = completed
                };
                controller.UpdateTask(updatedTask);
                Console.WriteLine("Tarefa atualizada com sucesso!");
            }
            else
            {
                Console.WriteLine("Tarefa não encontrada.");
            }
            Console.WriteLine();
        }

        public void DeleteTask()
        {
            Console.WriteLine("Excluir uma tarefa:");
            Console.Write("ID da tarefa: ");
            int id = int.Parse(Console.ReadLine());
            Tarefa existingTask = controller.GetTaskById(id);
            if (existingTask != null)
            {
                controller.DeleteTask(id);
                Console.WriteLine("Tarefa excluída com sucesso!");
            }
            else
            {
                Console.WriteLine("Tarefa não encontrada.");
            }
            Console.WriteLine();
        }

        private int GenerateTaskId()
        {
            var tasks = controller.GetAllTasks();
            return tasks.Count > 0 ? tasks.Max(t => t.Id) + 1 : 1;
        }
    }
}
