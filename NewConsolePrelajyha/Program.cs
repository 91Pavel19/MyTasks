using System.Text;
using Microsoft.EntityFrameworkCore;
using NewConsolePrelajyha;
using Task = NewConsolePrelajyha.Task;
Console.OutputEncoding = System.Text.Encoding.UTF8;


// var task = context.Tasks.FirstOrDefault(t => t.Id == 1);
// if (task == null)
// {
//     Console.WriteLine("Такой задачи не существует");
//     
//     return;
// }
//
// Console.WriteLine($"Найдена задача под номером {task.Id}. Её название \"{task.Name}\"");

bool stopped = false;

while (!stopped)
{
    Console.WriteLine($" Добавить задачу \"1\" " +
                      $"\n Отредактировать задачу \"2\" " +
                      $"\n Удалить задачу \"3\" " +
                      $"\n Просмотр задач \"4\" " +
                      $"\n Изменение статуса \"5\" " +
                      $"\n Выход из приложения \"6\"");

    string namber = Console.ReadLine();
    if (string.IsNullOrWhiteSpace(namber))
    {
        Console.WriteLine("Некорректный ввод");

        continue;
    }
    // if (namber == "1")
    // {
    //     Console.WriteLine("Введите название новой задачи");
    //     
    //     var name = Console.ReadLine();
    //     if (string.IsNullOrWhiteSpace(name))
    //     {
    //         Console.WriteLine("Некорректный ввод");
    //         
    //         continue;
    //     }
    //     
    //     var task = new Task
    //     {
    //         Name = name
    //     };
    //
    //     using var context = new DatabaseContext();
    //     {
    //         context.Tasks.Add(task);
    //
    //         context.SaveChanges();
    //     }
    // }

    switch (namber)
    {
        case "1":
        {
            Console.WriteLine("Введите название новой задачи");
            var name = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(name))
            {
                Console.WriteLine("Некорректный ввод");

                continue;
            }

            var task = new Task
            {
                Name = name
            };

            using var context = new DatabaseContext();
            {
                context.Tasks.Add(task);
                context.SaveChanges();
            }
            break;
        }
        case "2":
        {
            Console.WriteLine("Введите номер задачи");

            var id = Convert.ToInt32(Console.ReadLine());
            if (id <= 0)
            {
                Console.WriteLine("Такой задачи не существует");

                continue;
            }

            Console.WriteLine("Введите новое изменение");

            var newchange = Console.ReadLine();
            using var context = new DatabaseContext();
            {
                var task = context.Tasks.FirstOrDefault(t => t.Id == id);
                if (task == null)
                {
                    Console.WriteLine("Такой задачи не существует");

                    continue;
                }

                task.Name = newchange;
                context.SaveChanges();

                Console.WriteLine("Задача успешно изменена");
            }
            break;
        }
        case "3":
        {
            Console.WriteLine("Введите номер задачи");

            var id = Convert.ToInt32(Console.ReadLine());
            if (id <= 0)
            {
                Console.WriteLine("Такой задачи не существует");

                continue;
            }

            using var context = new DatabaseContext();
            {
                var task = context.Tasks.FirstOrDefault(t => t.Id == id);
                if (task == null)
                {
                    Console.WriteLine("Такой задачи не существует");

                    continue;
                }

                context.Remove(task);
                context.SaveChanges();

                Console.WriteLine("Удаление успешно");
                break;
            }
        }
        case "4":
        {
            Console.WriteLine("Список задач:");

            var tasks = new List<Task>();
            using var context = new DatabaseContext();
            {
                tasks = context.Tasks.AsNoTracking().ToList();
            }

            foreach (var task in tasks)
            {
                var isCompleted = task.IsCompleted ? " ✓ " : " ❌  ";

                Console.WriteLine($"{task.Id}. Название - {task.Name} [{isCompleted}]");
            }

            break;
        }
        case "5":
        {
            Console.WriteLine("Введите номер задачи");

            var id = Convert.ToInt32(Console.ReadLine());
            if (id <= 0)
            {
                Console.WriteLine("Такой задачи не существует");

                continue;
            }

            using var context = new DatabaseContext();
            {
                var task = context.Tasks.FirstOrDefault(t => t.Id == id);
                if (task == null)
                {
                    Console.WriteLine("Такой задачи не существует");

                    continue;
                }

                task.IsCompleted = !task.IsCompleted;
                context.SaveChanges();

                Console.WriteLine("Изменение успешно");
            }
            break;
        }
        case "6":
            Console.WriteLine("Доброго дня");

            return;
    }
}

// if (namber == "2")
    //  {
    //      Console.WriteLine("Введите номер задачи");
    // 
    //      var id = Convert.ToInt32(Console.ReadLine());
    //      if (id <= 0)
    //      {
    //          Console.WriteLine("Такой задачи не существует");
    //          
    //          continue;
    //      }
    //     
    //     Console.WriteLine("Введите новое изменение");
    //
    //     var newchange = Console.ReadLine();
    //     using var context = new DatabaseContext();
    //     {
    //         var task = context.Tasks.FirstOrDefault(t => t.Id == id);
    //         if (task == null) 
    //         { 
    //             Console.WriteLine("Такой задачи не существует"); 
    //             
    //             continue;
    //         }
    //
    //         task.Name = newchange;
    //         context.SaveChanges();
    //         
    //         Console.WriteLine("Задача успешно изменена");
    //         
    //     }
    // }
    
    // if (namber == "3")
    // {
    //     Console.WriteLine("Введите номер задачи");
    //     
    //     var id = Convert.ToInt32(Console.ReadLine());
    //     if (id <= 0)
    //     {
    //         Console.WriteLine("Такой задачи не существует");
    //         
    //         continue;
    //     }
    //     
    //     using var context = new DatabaseContext();
    //     {
    //         var task = context.Tasks.FirstOrDefault(t => t.Id == id);
    //         if (task == null) 
    //         { 
    //             Console.WriteLine("Такой задачи не существует"); 
    //             
    //             continue;
    //         }
    //
    //         context.Tasks.Remove(task);
    //         context.SaveChanges();
    //         
    //         Console.WriteLine("Удаление успешно");
    //     }
    // }
    
    // if (namber == "4")
    // {
    //     Console.WriteLine("Список задач:");
    //     
    //     var tasks = new List<Task>();
    //     using var context = new DatabaseContext();
    //     {
    //         tasks = context.Tasks.AsNoTracking().ToList();
    //     }
    //
    //     foreach (var task in tasks)
    //     {
    //         var isCompleted = task.IsCompleted ? " ✓ " : " ❌  ";
    //
    //         Console.WriteLine($"{task.Id}. Название - {task.Name} [{isCompleted}]");
    //     }
    // }
    
    // if (namber == "5")
    // {
    //     Console.WriteLine("Введите номер задачи");
    //     
    //     var id = Convert.ToInt32(Console.ReadLine());
    //     if (id <= 0)
    //     {
    //         Console.WriteLine("Такой задачи не существует");
    //         
    //         continue;
    //     }
    //     
    //     using var context = new DatabaseContext();
    //     {
    //         var task = context.Tasks.FirstOrDefault(t => t.Id == id);
    //         if (task == null) 
    //         { 
    //             Console.WriteLine("Такой задачи не существует"); 
    //             
    //             continue;
    //         }
    //
    //         task.IsCompleted = !task.IsCompleted;
    //         
    //         context.SaveChanges();
    //         
    //         Console.WriteLine("Изменение успешно");
    //     }
    // }

    // if (namber == "6")
    // {
    //     Console.WriteLine("Доброго дня");
    //     
    //     return;
    // }

