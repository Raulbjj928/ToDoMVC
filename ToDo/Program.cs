using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDo.Controllers;
using ToDo.Views;

namespace ToDo
{
    internal class Program
    {
        static void Main(string[] args)
        {
            TarefaController taskController = new TarefaController();
            ListaTarefaView taskListView = new ListaTarefaView(taskController);

            while (true)
            {
                Console.WriteLine("Escolha uma opção:");
                Console.WriteLine("1. Exibir tarefas");
                Console.WriteLine("2. Adicionar tarefa");
                Console.WriteLine("3. Atualizar tarefa");
                Console.WriteLine("4. Excluir tarefa");
                Console.WriteLine("0. Sair");
                Console.Write("Opção: ");
                int option = int.Parse(Console.ReadLine());
                Console.WriteLine();

                switch (option)
                {
                    case 1:
                        taskListView.DisplayTasks();
                        break;
                    case 2:
                        taskListView.AddTask();
                        break;
                    case 3:
                        taskListView.UpdateTask();
                        break;
                    case 4:
                        taskListView.DeleteTask();
                        break;
                    case 0:
                        Environment.Exit(0);
                        break;
                    default:
                        Console.WriteLine("Opção inválida. Tente novamente.");
                        Console.WriteLine();
                        break;
                }
            }
        }
    }
}
