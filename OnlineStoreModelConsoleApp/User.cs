using System.Collections.Generic;

namespace OnlineStoreModelConsoleApp
{
    public class User
    {
        public string Name;
        public string Password;
        public List<Order> Orders; 

        public User(string name, string password)
        {
            Name = name;
            Password = password;
            Orders = new List<Order>();
        }

        public void AddOrder(Order order)
        {
            Orders.Add(order);
        }

        public bool CheckPassword(string name, string password)
        {
            if(Name == name && Password == password)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
