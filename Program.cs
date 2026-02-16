using System;
using System.Collections.Generic;

namespace HomeWork
{
    internal class Program
    {
        private class ListTask
        {
            private readonly List<string> _listOfStrings;

            public ListTask()
            {
                _listOfStrings = new List<string> { "apple", "banana", "cherry" };
            }

            public void TaskLoop()
            {
                Console.WriteLine("\n=== Задание 1: Работа со списком строк ===");
                Console.WriteLine($"Начальный список: {string.Join(", ", _listOfStrings)}");

                // Добавить новую строку
                Console.Write("Введите новую строку для добавления в конец: ");
                string newString = Console.ReadLine();
                if (!string.IsNullOrEmpty(newString))
                {
                    _listOfStrings.Add(newString);
                    Console.WriteLine($"Список после добавления: {string.Join(", ", _listOfStrings)}");
                }

                // Добавить строку в середину
                Console.Write("Введите строку для добавления в середину: ");
                string middleString = Console.ReadLine();
                if (!string.IsNullOrEmpty(middleString))
                {
                    int middleIndex = _listOfStrings.Count / 2;
                    _listOfStrings.Insert(middleIndex, middleString);
                    Console.WriteLine($"Список после добавления в позицию {middleIndex}: {string.Join(", ", _listOfStrings)}");
                }

                // Цикл для повторного использования или выхода
                while (true)
                {
                    Console.WriteLine($"\nТекущий список: {string.Join(", ", _listOfStrings)}");
                    Console.Write("Введите 'exit' для выхода, или новую строку для добавления: ");
                    string input = Console.ReadLine();

                    if (string.IsNullOrEmpty(input) || input.ToLower() == "exit")
                    {
                        Console.WriteLine("Выход из Задания 1");
                        break;
                    }

                    if (!string.IsNullOrEmpty(input))
                    {
                        _listOfStrings.Add(input);
                    }
                }
            }
        }

        private class DictionaryTask
        {
            private readonly Dictionary<string, double> _studentGrades;

            public DictionaryTask()
            {
                _studentGrades = new Dictionary<string, double>();
            }

            public void TaskLoop()
            {
                Console.WriteLine("\n=== Задание 2: Словарь оценок студентов ===");

                while (true)
                {
                    Console.WriteLine("\nВыберите операцию:");
                    Console.WriteLine("1 - Добавить студента");
                    Console.WriteLine("2 - Поиск студента");
                    Console.WriteLine("3 - Показать всех студентов");
                    Console.WriteLine("exit - Выход");
                    Console.Write("Ваш выбор: ");

                    string choice = Console.ReadLine();

                    if (string.IsNullOrEmpty(choice) || choice.ToLower() == "exit")
                    {
                        Console.WriteLine("Выход из Задания 2");
                        break;
                    }

                    switch (choice)
                    {
                        case "1":
                            AddStudent();
                            break;
                        case "2":
                            SearchStudent();
                            break;
                        case "3":
                            ShowAllStudents();
                            break;
                        default:
                            Console.WriteLine("Неверный выбор. Попробуйте снова.");
                            break;
                    }
                }
            }

            private void AddStudent()
            {
                Console.Write("Введите имя студента: ");
                string name = Console.ReadLine();

                if (string.IsNullOrEmpty(name))
                {
                    Console.WriteLine("Имя не может быть пустым.");
                    return;
                }

                Console.Write("Введите оценку (от 2 до 5): ");
                if (!double.TryParse(Console.ReadLine(), out double grade))
                {
                    Console.WriteLine("Ошибка: оценка должна быть числом.");
                    return;
                }

                if (grade < 2 || grade > 5)
                {
                    Console.WriteLine("Ошибка: оценка должна быть в диапазоне от 2 до 5.");
                    return;
                }

                if (_studentGrades.ContainsKey(name))
                {
                    _studentGrades[name] = grade;
                    Console.WriteLine($"Оценка студента {name} обновлена на {grade}");
                }
                else
                {
                    _studentGrades.Add(name, grade);
                    Console.WriteLine($"Студент {name} с оценкой {grade} добавлен.");
                }
            }

            private void SearchStudent()
            {
                Console.Write("Введите имя студента для поиска: ");
                string name = Console.ReadLine();

                if (string.IsNullOrEmpty(name))
                {
                    Console.WriteLine("Имя не может быть пустым.");
                    return;
                }

                if (_studentGrades.ContainsKey(name))
                {
                    Console.WriteLine($"Оценка студента {name}: {_studentGrades[name]}");
                }
                else
                {
                    Console.WriteLine($"Студента с именем {name} не существует в словаре.");
                }
            }

            private void ShowAllStudents()
            {
                if (_studentGrades.Count == 0)
                {
                    Console.WriteLine("Словарь пуст.");
                    return;
                }

                Console.WriteLine("\nСписок всех студентов:");
                foreach (var kvp in _studentGrades)
                {
                    Console.WriteLine($"  {kvp.Key}: {kvp.Value}");
                }
            }
        }

        private class DoublyLinkedListTask
        {
            private class Node
            {
                public int Data { get; set; }
                public Node Next { get; set; }
                public Node Prev { get; set; }

                public Node(int data)
                {
                    Data = data;
                    Next = null;
                    Prev = null;
                }
            }

            private Node _head;
            private Node _tail;

            public DoublyLinkedListTask()
            {
                _head = null;
                _tail = null;
            }

            public void TaskLoop()
            {
                Console.WriteLine("\n=== Задание 3: Двусвязный список ===");
                Console.WriteLine("Введите от 3 до 6 элементов. После каждого элемента нажимайте Enter.");

                int count = 0;
                while (count < 3 || (count < 6 && AskContinue()))
                {
                    Console.Write($"Введите элемент {count + 1}: ");
                    if (int.TryParse(Console.ReadLine(), out int value))
                    {
                        AddToEnd(value);
                        count++;
                    }
                    else
                    {
                        Console.WriteLine("Ошибка: введите целое число.");
                    }
                }

                while (true)
                {
                    Console.WriteLine("\nВыберите операцию:");
                    Console.WriteLine("1 - Показать список в прямом порядке");
                    Console.WriteLine("2 - Показать список в обратном порядке");
                    Console.WriteLine("exit - Выход");
                    Console.Write("Ваш выбор: ");

                    string choice = Console.ReadLine();

                    if (string.IsNullOrEmpty(choice) || choice.ToLower() == "exit")
                    {
                        Console.WriteLine("Выход из Задания 3");
                        break;
                    }

                    switch (choice)
                    {
                        case "1":
                            PrintForward();
                            break;
                        case "2":
                            PrintBackward();
                            break;
                        default:
                            Console.WriteLine("Неверный выбор. Попробуйте снова.");
                            break;
                    }
                }
            }

            private bool AskContinue()
            {
                Console.Write("Добавить еще элемент? (y/n): ");
                string input = Console.ReadLine();
                return !string.IsNullOrEmpty(input) && input.ToLower() == "y";
            }

            private void AddToEnd(int data)
            {
                Node newNode = new Node(data);

                if (_head == null)
                {
                    _head = newNode;
                    _tail = newNode;
                }
                else
                {
                    _tail.Next = newNode;
                    newNode.Prev = _tail;
                    _tail = newNode;
                }
            }

            private void PrintForward()
            {
                if (_head == null)
                {
                    Console.WriteLine("Список пуст.");
                    return;
                }

                Console.Write("Список в прямом порядке: ");
                Node current = _head;
                while (current != null)
                {
                    Console.Write(current.Data);
                    if (current.Next != null)
                        Console.Write(" <-> ");
                    current = current.Next;
                }
                Console.WriteLine();
            }

            private void PrintBackward()
            {
                if (_tail == null)
                {
                    Console.WriteLine("Список пуст.");
                    return;
                }

                Console.Write("Список в обратном порядке: ");
                Node current = _tail;
                while (current != null)
                {
                    Console.Write(current.Data);
                    if (current.Prev != null)
                        Console.Write(" <-> ");
                    current = current.Prev;
                }
                Console.WriteLine();
            }
        }

        static void Main(string[] args)
        {
            while (true)
            {
                Console.WriteLine("\n╔════════════════════════════════════════╗");
                Console.WriteLine("║  Домашнее задание: Коллекции в C#     ║");
                Console.WriteLine("╠════════════════════════════════════════╣");
                Console.WriteLine("║ Выберите задание для выполнения:       ║");
                Console.WriteLine("║ 1 - Работа со списком (List)           ║");
                Console.WriteLine("║ 2 - Словарь оценок (Dictionary)        ║");
                Console.WriteLine("║ 3 - Двусвязный список (LinkedList)     ║");
                Console.WriteLine("║ exit - Выход из программы              ║");
                Console.WriteLine("╚════════════════════════════════════════╝");
                Console.Write("Ваш выбор: ");

                string input = Console.ReadLine();

                if (string.IsNullOrEmpty(input) || input.ToLower() == "exit")
                {
                    Console.WriteLine("Программа завершена. До свидания!");
                    break;
                }

                if (!int.TryParse(input, out int taskNumber))
                {
                    Console.WriteLine("Ошибка: введите числовое значение или 'exit'.");
                    continue;
                }

                switch (taskNumber)
                {
                    case 1:
                        CheckTaskFirst();
                        break;
                    case 2:
                        CheckTaskSecond();
                        break;
                    case 3:
                        CheckTaskThird();
                        break;
                    default:
                        Console.WriteLine("Ошибка: выберите задание 1, 2 или 3.");
                        break;
                }
            }
        }

        private static void CheckTaskFirst()
        {
            var listTask = new ListTask();
            listTask.TaskLoop();
        }

        private static void CheckTaskSecond()
        {
            var dictionaryTask = new DictionaryTask();
            dictionaryTask.TaskLoop();
        }

        private static void CheckTaskThird()
        {
            var linkedListTask = new DoublyLinkedListTask();
            linkedListTask.TaskLoop();
        }
    }
}
