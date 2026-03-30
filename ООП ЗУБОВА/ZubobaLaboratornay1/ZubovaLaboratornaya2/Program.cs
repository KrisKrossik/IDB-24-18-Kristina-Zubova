using System;

namespace AbstractFactoryLab
{
    // создаем интерфейсы для виджетов
    public interface IButton
    {
        void Render();
    }

    public interface ICheckbox
    {
        void Render();
    }

    // теперь классы для светлой темы
    public class LightButton : IButton
    {
        public void Render()
        {
            // выводим цвет кнопки
            Console.WriteLine("отрисовка кнопки, цвет: светло-серый");
        }
    }

    public class LightCheckbox : ICheckbox
    {
        public void Render()
        {
            Console.WriteLine("отрисовка светлого чекбокса");
        }
    }

    // класс для темной темы
    public class DarkButton : IButton
    {
        public void Render()
        {
           
            Console.WriteLine("отрисовка кнопки, цвет: темно-серый");
        }
    }

    public class DarkCheckbox : ICheckbox
    {
        public void Render()
        {
            Console.WriteLine("отрисовка темного чекбокса");
        }
    }

    // интерфейс абстрактной фабрики
    public interface IGUIFactory
    {
        IButton CreateButton();
        ICheckbox CreateCheckbox();
    }

    // конкретные фабрики
    public class LightFactory : IGUIFactory
    {
        public IButton CreateButton()
        {
            return new LightButton();
        }

        public ICheckbox CreateCheckbox()
        {
            return new LightCheckbox();
        }
    }

    public class DarkFactory : IGUIFactory
    {
        public IButton CreateButton()
        {
            return new DarkButton();
        }

        public ICheckbox CreateCheckbox()
        {
            return new DarkCheckbox();
        }
    }

    // клиентский класс
    public class Application
    {
        private IGUIFactory factory;
        private IButton button;
        private ICheckbox checkbox;

        public Application(IGUIFactory factory)
        {
            this.factory = factory;
        }

        public void CreateUI()
        {
            button = factory.CreateButton();
            checkbox = factory.CreateCheckbox();
        }

        public void Paint()
        {
            button.Render();
            checkbox.Render();
        }
    }

    // тестирование и запуск
    class Program
    {
        static void Main()
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;

            // тестируем светлую темуу
            Console.WriteLine("приложение со светлой темой:");
            IGUIFactory lightFactory = new LightFactory();
            Application app1 = new Application(lightFactory);

            app1.CreateUI(); // создаем элементы
            app1.Paint();    // отрисовываем их

            Console.WriteLine(); 

            // теперь тестируем темную тему
            Console.WriteLine("приложение с тёмной темой:");
            IGUIFactory darkFactory = new DarkFactory();
            Application app2 = new Application(darkFactory);

            app2.CreateUI(); 
            app2.Paint();    

            Console.ReadKey();
        }
    }
}