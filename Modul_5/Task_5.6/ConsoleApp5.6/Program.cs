using System;

using System.Text.RegularExpressions; // Используем регулярные выражения для проверки корректности ввода имени и фамилии

namespace ConsoleApp5._6
{
    class Program
    {
        static void Main(string[] args)
        {
            var user = NewUser();
            ShowUser(user);
        }
        static (string Name, string LastName, int Age, string[] PetsName, string[] FavColors) NewUser()
        {
            (string Name, string LastName, int Age, string[] PetsName, string[] FavColors) User;

            string wrong = "[0-9!@#$%^&*()_+-={}:;<>?/|,.~`]";
            var reg = new Regex(wrong);

            string name;

            do
            {
                Console.WriteLine("Введите ваше имя:");
                name = Console.ReadLine();
                if (name.Length > 2)
                    if (!reg.IsMatch(name))
                    {
                        break;
                    }
                Console.WriteLine("Ввведите ваше имя корректно!");
            } while (true);

            User.Name = name;

            string lastname;

            do
            {
                Console.WriteLine("Введите вашу фамилию:");
                lastname = Console.ReadLine();
                if (lastname.Length > 2)
                    if (!reg.IsMatch(lastname))
                    {
                        break;
                    }
                Console.WriteLine("Ввведите вашу фамилию корректно!");
            } while (true);

            User.LastName = lastname;

            string age;
            int intage;

            do
            {
                Console.WriteLine("Введите ваш возраст");
                age = Console.ReadLine();
            } while (CheckNum(age, out intage));

            User.Age = intage;

            string havepets;
            string pets;
            int intpets;

            while (true)
            {
                Console.WriteLine("У вас есть домашние питомцы? Введите Да или Нет:");
                havepets = Console.ReadLine();

                if (havepets.ToLower() == "да")
                {
                    do
                    {
                        Console.WriteLine("Сколько у вас домашних питомцев?");
                        pets = Console.ReadLine();
                    } while (CheckNum(pets, out intpets));

                    User.PetsName = PetsName(intpets);
                    break;
                }
                else if (havepets.ToLower() == "нет")
                {
                    User.PetsName = new string[0];
                    break;
                }
            }

            string colors;
            int intcolors;

            do
            {
                Console.WriteLine("Сколько у вас любимых цветов?");
                colors = Console.ReadLine();
            } while (CheckNum(colors, out intcolors));

            User.FavColors = Colors(intcolors);

            return User;
        }

        static void ShowUser((string Name, string LastName, int Age, string[] PetsName, string[] Favcolors) user)
        {
            Console.WriteLine("\nВы ввели следующую информацию:");
            Console.WriteLine("\nВаше имя и фамилия: {0} {1} \nВаш возраст: {2}", user.Name, user.LastName, user.Age);

                if (user.PetsName.Length > 0)
                    {
                        Console.WriteLine("Имя вашего питомца:");
                        for (int i = 0; i < user.PetsName.Length; i++)
                    {
                        Console.WriteLine(user.PetsName[i]);
                    }
                    }
                else Console.WriteLine("У вас нет домашних питомцев");

            Console.WriteLine("Ваш любимый цвет:");
            for (int i = 0; i < user.Favcolors.Length; i++)
            {
                Console.WriteLine(user.Favcolors[i]);
            }
        }

        static bool CheckNum(string num, out int corrnumber)
        {
            if (int.TryParse(num, out int intnum))
            {
                if (intnum > 0)
                {
                    corrnumber = intnum;
                    return false;
                }
            }
            Console.WriteLine("Введите больше 0!");
            corrnumber = 0;
            return true;
        }

        static string[] PetsName(int num)
        {
            string[] names = new string[num];

            for (int i = 0; i < names.Length; i++)
            {
                Console.WriteLine("Введите имя для {0} питомца: ", i + 1);
                names[i] = Console.ReadLine();
            }

            return names;
        }

        static string[] Colors(int num)
        {
            string[] colors = new string[num];

            for (int i = 0; i < colors.Length; i++)
            {
                Console.WriteLine("Введите название {0} цвета: ", i + 1);
                colors[i] = Console.ReadLine();
            }

            return colors;
        }
    }
}
