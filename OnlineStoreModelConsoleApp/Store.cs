using System;
using System.Collections.Generic;

namespace OnlineStoreModelConsoleApp
{
    public class Store
    {
        public List<Product> Products;
        public List<Product> Basket;
        public List<Order> Orders;

        public Store()
        {
            Products = new List<Product>
            {
                new Product("Хлеб", 25),
                new Product("Молоко", 80),
                new Product("Печенье", 50),
                new Product("Масло", 200),
                new Product("Йогурт", 60),
                new Product("Сок", 90),
                new Product("Шоколад", 50)
            };

            Basket = new List<Product>();
            Orders = new List<Order>();
        }

        public void AddNewProduct(string name, int price)
        {
            var product = new Product(name, price);
            Products.Add(product);
            Console.WriteLine($"{product.Name} успешно добавлен в каталог продуктов");
        }

        public void ShowCatalog()
        {
            Console.WriteLine("Каталог продуктов");
            ShowProducts(Products);
        }

        public void ShowBasket()
        {
            if (Basket.Count == 0)
            {
                Console.WriteLine("Здесь ничего нет(");
                return;
            }

            Console.WriteLine("Содержимое корзины");
            ShowProducts(Basket);
        }

        public void CreateOrder(User user)
        {
            if (Basket.Count != 0)
            {
                var order = new Order(Basket);
                Orders.Add(order);
                user.AddOrder(order);
                Basket.Clear();
                Console.WriteLine($"Ваш заказ принят на обработку. Общая сумма заказа {order.FullPrice} рублей");
            }
            else
            {
                Console.WriteLine("Мы не можем создать ваш заказ, потому что вы ничего не выбрали");
            }
        }

        public void AddToBasket(int productNumber)
        {
            Basket.Add(Products[productNumber - 1]);
            Console.WriteLine($"{Products[productNumber - 1].Name} успешно добавлен(о) в корзину");
        }

        private void ShowProducts(List<Product> products)
        {
            var number = 1;
            foreach(var product in products)
            {
                Console.Write(number + ". ");
                product.Print();
                number++;
            }
        }
    }
}
