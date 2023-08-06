﻿using System.Text;
using Microsoft.EntityFrameworkCore;
using NewConsolePrelajyha;
using Task = NewConsolePrelajyha.Task;
Console.OutputEncoding = System.Text.Encoding.UTF8;

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

    switch (namber)
    {
        case "1":
        {
            TaskManager.CreateNewTask();
            break;
        }
        case "2":
        {
            TaskManager.UpdateTask();
            break;
        }
        case "3":
        {
            TaskManager.DeleteTask();
            break;
        }
        case "4":
        {
            TaskManager.CheckTask();
            break;
        }
        case "5":
        {
            TaskManager.СhangingTask();
            break;
        }
        case "6":
        {
            TaskManager.ExitProgram();
            break;
        }
    }
}



