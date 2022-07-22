using System;

namespace OnlineStoreModelConsoleApp
{
    public class Product
    {
        public string Name;
        public decimal Price;

        public Product(string name, decimal price)
        {
            Name = name;
            Price = price;
        }

        public void Print()
        {
            Console.WriteLine($"{Name} - {Price}");
        }
    }
}
