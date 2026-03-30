using System;

namespace ComplexLab
{
    // создали ласс комплексного числа
    public class ComplexNumber
    {
        public double Real { get; }
        public double Imagine { get; }

        public ComplexNumber(double real, double imagine)
        {
            Real = real;
            Imagine = imagine;
        }

        // сделали перегруженный метод ToString
        public override string ToString()
        {
            if (Imagine == 0)
            {
                return $"{Real}";
            }

            if (Real == 0)
            {
                return $"{Imagine}i";
            }

            if (Imagine > 0)
            {
                return $"{Real} + {Imagine}i";
            }
            else
            {
                return $"{Real} - {Math.Abs(Imagine)}i";
            }
        }

        // перегружаем операторы

        // сложение
        public static ComplexNumber operator +(ComplexNumber a, ComplexNumber b)
        {
            return new ComplexNumber(a.Real + b.Real, a.Imagine + b.Imagine);
        }

        // вычитание
        public static ComplexNumber operator -(ComplexNumber a, ComplexNumber b)
        {
            return new ComplexNumber(a.Real - b.Real, a.Imagine - b.Imagine);
        }

        // умножение
        public static ComplexNumber operator *(ComplexNumber a, ComplexNumber b)
        {
            double newReal = a.Real * b.Real - a.Imagine * b.Imagine;
            double newImagine = a.Real * b.Imagine + a.Imagine * b.Real;
            return new ComplexNumber(newReal, newImagine);
        }

        // деление
        public static ComplexNumber operator /(ComplexNumber a, ComplexNumber b)
        {
            double denominator = b.Real * b.Real + b.Imagine * b.Imagine;

            double newReal = (a.Real * b.Real + a.Imagine * b.Imagine) / denominator;
            double newImagine = (a.Imagine * b.Real - a.Real * b.Imagine) / denominator;

            return new ComplexNumber(newReal, newImagine);
        }

        // унарный плюс это модуль числа: корень из суммы квадратов
        public static double operator +(ComplexNumber a)
        {
            return Math.Sqrt(a.Real * a.Real + a.Imagine * a.Imagine);
        }

        // Унарный минус это сопряженное число: меняем знак у мнимой части
        public static ComplexNumber operator -(ComplexNumber a)
        {
            return new ComplexNumber(a.Real, -a.Imagine);
        }

        // операторы сравнения
        public static bool operator ==(ComplexNumber a, ComplexNumber b)
        {
            return a.Real == b.Real && a.Imagine == b.Imagine;
        }

        public static bool operator !=(ComplexNumber a, ComplexNumber b)
        {
            return !(a == b);
        }

        // обязательные методы Equals и GetHashCode для правильной работы == и !=
        public override bool Equals(object obj)
        {
            if (obj is ComplexNumber c)
            {
                return this == c;
            }
            return false;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Real, Imagine);
        }
    }

    // Unit тесты в  консоле
    class Program
    {
        static void Main()
        {
            Console.WriteLine("Тестируем математические операци:");

            ComplexNumber n1 = new ComplexNumber(1, 2);
            ComplexNumber n2 = new ComplexNumber(3, 4);

            Console.WriteLine($"Число 1: ({n1})");
            Console.WriteLine($"Число 2: ({n2})\n");

            // тест сложения
            ComplexNumber sum = n1 + n2;
            Console.WriteLine($"Сложение: ({n1}) + ({n2}) = {sum}");

            // тест вычитания
            ComplexNumber diff = n1 - n2;
            Console.WriteLine($"Вычитание: ({n1}) - ({n2}) = {diff}");

            // тест умножения
            ComplexNumber mult = n1 * n2;
            Console.WriteLine($"Сложение: ({n1}) *({n2}) = {mult}");

            // тест сопряженного числа
            ComplexNumber conj = -n1;
            Console.WriteLine($"Сопряженное для ({n1}) = {conj}");

            // тест модуля
            double mod = +n2;
            Console.WriteLine($"Модуль ({n2}) = {mod}\n");

            Console.WriteLine("Тестируем сравнение комплексных чисел:");

            ComplexNumber eq1 = new ComplexNumber(5, -3);
            ComplexNumber eq2 = new ComplexNumber(5, -3);
            ComplexNumber neq = new ComplexNumber(2, 7);

            // тест одинаковых чисел
            Console.WriteLine($"Сравниваем: ({eq1}) и ({eq2})");
            bool areEqual = (eq1 == eq2);
            Console.WriteLine($"Результат (==): {areEqual}");

            Console.WriteLine();

            // тест разных чисел
            Console.WriteLine($"Сравниваем: ({eq1}) и ({neq})");
            bool areNotEqual = (eq1 != neq);
            Console.WriteLine($"Результат (!=): {areNotEqual}");

            Console.WriteLine("\nВсе проверки  теперь закончены, нажми любую клавишу для выхода!!");
            Console.ReadKey();
        }
    }
}
