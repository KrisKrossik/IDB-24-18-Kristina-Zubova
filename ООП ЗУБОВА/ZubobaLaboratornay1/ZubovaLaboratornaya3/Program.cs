using System;
using System.Collections.Generic;

namespace TreeLab
{
    // класс узла дерева
    public class TreeNode
    {
        // значение узла
        public string Value { get; set; }

        // список с потомками -детьми
        public List<TreeNode> Children { get; set; }

     
        public TreeNode(string value)
        {
            Value = value;
            Children = new List<TreeNode>(); 
        }

 
        public void Print()
        {
            // пишем значение узла
            Console.WriteLine(Value);

            // проверяем наличие детей
            if (Children.Count == 0)
            {
                // если детей нет, функция завершает свое выполнение
                return;
            }

            // если дети есть, то функция  начинает в цикле вызывать свой аналог в объектах из списка
            foreach (TreeNode child in Children)
            {
                child.Print(); // рекурсивный вызов
            }
        }
    }

    class Program
    {
        static void Main()
        {
      
            Console.OutputEncoding = System.Text.Encoding.UTF8;

            Console.WriteLine("вывод структуры дерева:\n");

            // создаем узлы
            TreeNode root = new TreeNode("Корень (Генеральный директор)");

            TreeNode branch1 = new TreeNode("  Ветка 1 (Бухгалтерия)");
            TreeNode branch2 = new TreeNode("  Ветка 2 (IT-отдел)");

            TreeNode leaf1 = new TreeNode("    Лист 1 (Главный бухгалтер)");
            TreeNode leaf2 = new TreeNode("    Лист 2 (Кассир)");
            TreeNode leaf3 = new TreeNode("    Лист 3 (Программист)");
            TreeNode leaf4 = new TreeNode("    Лист 4 (Системный администратор)");

            // связываем узлы между собой (пополнение детей)

            // добавляем сотрудников в отделы
            branch1.Children.Add(leaf1);
            branch1.Children.Add(leaf2);

            branch2.Children.Add(leaf3);
            branch2.Children.Add(leaf4);

            // добавляем отделы директору
            root.Children.Add(branch1);
            root.Children.Add(branch2);

            // запускаем функцию вывода от самого главного  узла
            root.Print();

            Console.WriteLine("\nвсе элементы дерева  выведены");
            Console.WriteLine("нажмите любую кнопку для выхода");
            Console.ReadKey();
        }
    }
}