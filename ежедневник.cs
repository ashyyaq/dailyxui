using System;
using System.Collections.Generic;

class Program
{
    static List<Note> notes;
    static int currentIndex = 0; 

    static void Main(string[] args)
    {
        InitializeNotes();

        while (true)
        {
            Console.Clear();
            ShowMenu();

            ConsoleKeyInfo key = Console.ReadKey();

            switch (key.Key)
            {
                case ConsoleKey.LeftArrow:
                    SwitchToPreviousNote();
                    break;
                case ConsoleKey.RightArrow:
                    SwitchToNextNote();
                    break;
                case ConsoleKey.Enter:
                    ShowFullNote();
                    break;
                default:
                    Console.WriteLine("Нажмите стрелку влево, стрелку вправо или Enter.");
                    break;
            }
        }
    }

    static void InitializeNotes()
    {
        notes = new List<Note>
        {
            new Note("Заметка 1", "Описание 1", new DateTime(2022, 6, 6)),
            new Note("Заметка 2", "Описание 2", new DateTime(2022, 6, 8)),
            new Note("Заметка 3", "Описание 3", new DateTime(2022, 6, 13))
        };
    }

    static void ShowMenu()
    {
        Console.WriteLine("Ежедневник");
        Console.WriteLine("--------------------");
        Console.WriteLine();

        Note currentNote = notes[currentIndex];
        Console.WriteLine($"Название: {currentNote.Title}");

        Console.WriteLine();
        Console.WriteLine("Используйте стрелку влево, стрелку вправо или Enter.");
    }

    static void SwitchToPreviousNote()
    {
        currentIndex = (currentIndex - 1 + notes.Count) % notes.Count;
    }

    static void SwitchToNextNote()
    {
        currentIndex = (currentIndex + 1) % notes.Count;
    }

    static void ShowFullNote()
    {
        Note currentNote = notes[currentIndex];

        Console.Clear();
        Console.WriteLine("Полная информация по заметке");
        Console.WriteLine("----------------------------");
        Console.WriteLine();

        Console.WriteLine($"Название: {currentNote.Title}");
        Console.WriteLine($"Описание: {currentNote.Description}");
        Console.WriteLine($"Дата: {currentNote.Date.ToShortDateString()}");
        // Добавьте остальные поля заметки по желанию

        Console.WriteLine();
        Console.WriteLine("Нажмите Enter для возврата к меню.");
        Console.ReadLine();
    }
}

class Note
{
    public string Title { get; }
    public string Description { get; }
    public DateTime Date { get; }

    public Note(string title, string description, DateTime date)
    {
        Title = title;
        Description = description;
        Date = date;
    }
}
