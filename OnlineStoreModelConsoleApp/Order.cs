using System.Collections.Generic;

namespace OnlineStoreModelConsoleApp
{
    public class Order
    {
        public List<Product> Products;
        public decimal FullPrice = 0;

        public Order(List<Product> products)
        {
            Products = products;
            foreach(var product in products)
            {
                FullPrice += product.Price;
            }
        }
    }
}
