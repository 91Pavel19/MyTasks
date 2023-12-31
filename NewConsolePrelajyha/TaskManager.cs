﻿using Microsoft.EntityFrameworkCore;

namespace NewConsolePrelajyha;

public class TaskManager
{
    public static void CreateNewTask()
    {
        Console.WriteLine("Введите название новой задачи");
        var name = Console.ReadLine();
        if (string.IsNullOrWhiteSpace(name))
        {
            Console.WriteLine("Некорректный ввод");
            
            return;
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
    }

    public static void UpdateTask()
    {
        Console.WriteLine("Введите номер задачи");

        var id = ConvertId(Console.ReadLine()!);
        if (id <= 0)
        {
            Console.WriteLine("Такой задачи не существует");

            return;
        }

        Console.WriteLine("Введите новое изменение");

        var newchange = Console.ReadLine();
        using var context = new DatabaseContext();
        {
            var task = GetTask(id);
            if (task == null)
            {
                Console.WriteLine("Такой задачи не существует");

                return;
            }

            task.Name = newchange;
            context.SaveChanges();

            Console.WriteLine("Задача успешно изменена");
        }
    }

    public static void DeleteTask()
    {
        Console.WriteLine("Введите номер задачи");

        var id = ConvertId(Console.ReadLine()!);
        if (id <= 0)
        {
            Console.WriteLine("Такой задачи не существует");

            return;
        }

        using var context = new DatabaseContext();
        {
            var task = GetTask(id);
            if (task == null)
            {
                Console.WriteLine("Такой задачи не существует");

                return;
            }

            context.Remove(task);
            context.SaveChanges();

            Console.WriteLine("Удаление успешно");
        }
    }

    public static void ViewTasks()
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
    }

    public static void UpdateTaskStatus()
    {
        Console.WriteLine("Введите номер задачи");

        var id = ConvertId(Console.ReadLine()!);
        if (id <= 0)
        {
            Console.WriteLine("Такой задачи не существует");

            return;
        }

        using var context = new DatabaseContext();
        {
            var task = GetTask(id);
            if (task == null)
            {
                Console.WriteLine("Такой задачи не существует");

                return;
            }

            task.IsCompleted = !task.IsCompleted;
            context.SaveChanges();

            Console.WriteLine("Изменение успешно");
        }
    }

    private static Task? GetTask(int id)
    {
        using var context = new DatabaseContext();
        {
            return context.Tasks.FirstOrDefault(t => t.Id == id);
        }
    }

    private static int ConvertId(string input)
    {
        try
        {
            var id = Convert.ToInt32(Console.ReadLine());
            
            return id;
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return 0;
        }
    }
}