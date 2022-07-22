using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineStoreModelConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            var onlineStore = new Store();
            
            Console.WriteLine("Приветсвтуем вас в онлайн магазине продуктов! " +
                               "Введите Имя пользователя");
            var userName = Console.ReadLine();

            Console.WriteLine("Введите пароль, чтобы зарегистрироваться в программе");
            var userPassword = GetCorrectStringInput();

            var user = new User(userName, userPassword);
            Console.WriteLine($"{user.Name}, вы успешно зарегистрировались в программе");
            Console.WriteLine();

            Console.WriteLine("Выберите номер действия которое хотите совершить:");
            Console.WriteLine("1. Показать каталог продуктов");
            Console.WriteLine("2. Добавить новый продукт в каталог (Для администратора)");

            var userAnswer = GetCorrectDigitInput(1, 2);

            if (userAnswer == 1)
            {
                onlineStore.ShowCatalog();

                Console.WriteLine("Хотите добавить продукт в корзину? Введите да или нет");
                if (IsYes())
                {
                    Console.WriteLine("Введите номер продукта, который хотите добавить в корзину. " +
                                      "После того как продукты будут выбраны введите 0");
                    while (true)
                    {
                        var productNumber = GetCorrectDigitInput(0, onlineStore.Products.Count);

                        if (productNumber == 0)
                        {
                            break;
                        }

                        onlineStore.AddToBasket(productNumber);
                    }
                }

                Console.WriteLine("Хотите посмотреть содержимое корзины? Введите да или нет");
                if (IsYes())
                {
                    onlineStore.ShowBasket();
                }

                Console.WriteLine("Хотите оформить заказ? Введите да или нет");
                if (IsYes())
                {
                    onlineStore.CreateOrder(user);
                }
            }
            else
            {
                Console.WriteLine("Для того, чтобы добавить позицию в каталог продуктов нужно авторизоваться.");
                Console.WriteLine("Введите Имя пользователя");
                userName = GetCorrectStringInput();
                Console.WriteLine("Введите пароль");
                userPassword = GetCorrectStringInput();

                bool authorized = user.CheckPassword(userName, userPassword);
                while (true)
                {
                    if (authorized)
                    {
                        Console.WriteLine("Вы вошли в режим администратора");
                        Console.WriteLine("Введите имя позиции, которую хотите добавить");
                        var productName = GetCorrectStringInput();

                        Console.WriteLine("Введите цену");
                        var productPrice = GetCorrectDigitInput();

                        onlineStore.AddNewProduct(productName, productPrice);
                        Console.WriteLine();
                        onlineStore.ShowCatalog();

                        break;
                    }
                    else
                    {
                        Console.WriteLine("Неправильно введет логин или пароль. Повторите попытку авторизации");
                        Console.WriteLine("Введите Имя пользователя");
                        userName = GetCorrectStringInput();
                        Console.WriteLine("Введите пароль");
                        userPassword = GetCorrectStringInput();

                        authorized = user.CheckPassword(userName, userPassword);
                    }
                }

            }
        }

        static int GetCorrectDigitInput(int minNumber, int maxNumber)
        {
            while (true)
            {
                try
                {
                    var userAnswer = Convert.ToInt32(Console.ReadLine());
                    if (userAnswer < minNumber || userAnswer > maxNumber)
                    {
                        Console.WriteLine("Выберите номер из перечисленных пунктов!");
                    }
                    else
                    {
                        return userAnswer;
                    }
                }
                catch (FormatException)
                {
                    Console.WriteLine("Введите число!");
                }
                catch (OverflowException)
                {
                    Console.WriteLine("Слишком большое число! Выберите номер из перечисленных пунктов");
                }
            }
        }

        static int GetCorrectDigitInput()
        {
            while (true)
            {
                try
                {
                    var userAnswer = Convert.ToInt32(Console.ReadLine());
                    return userAnswer;
                }
                catch (FormatException)
                {
                    Console.WriteLine("Введите число!");
                }
                catch (OverflowException)
                {
                    Console.WriteLine("Слишком большое число! Выберите номер из перечисленных пунктов");
                }
            }
        }

        static string GetCorrectStringInput()
        {
            var userPassword = Console.ReadLine();

            while (userPassword == "")
            {
                Console.WriteLine("Вы ничего не ввели! Повторите попытку");
                userPassword = Console.ReadLine();
            }

            return userPassword;
        }

        static bool IsYes()
        {
            var userAnswer = Console.ReadLine().ToLower();

            while (true)
            {
                if (userAnswer == "да")
                {
                    return true;
                }
                else if(userAnswer == "нет")
                {
                    return false;
                }
                else
                {
                    Console.WriteLine("Введите да или нет!");
                    userAnswer = Console.ReadLine().ToLower();
                }
            }

        }
    }
}
