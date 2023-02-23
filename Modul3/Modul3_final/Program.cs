using System;

namespace Modul3_final
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Введите ваше имя: ");
            string name = Console.ReadLine();

            Console.Write("Введите ваш возраст: ");
            int age = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine($"Вас зовут {name} и вам {age}");

            Console.Write("Введите вашу дату рождения: ");
            string birthday = Console.ReadLine();
            Console.WriteLine($"Ваша дата рождения {birthday}");
        }
    }
}
