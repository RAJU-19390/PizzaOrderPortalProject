using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaManager
{
    public class PizzaDAL
    {
        public List<PizzaMaster> plist;
        public PizzaDAL()
        {
            plist = new List<PizzaMaster>();
        }
        public List<PizzaMaster> PizzaDetails()
        {
            PizzaMaster p1 = new PizzaMaster() { Id = 1, Type = "Greek Pizza", Price = 299.89f };
            PizzaMaster p2 = new PizzaMaster() { Id = 2, Type = "Sicilian Pizza", Price = 199.99f };
            PizzaMaster p3 = new PizzaMaster() { Id = 3, Type = "Detroit Pizza", Price = 159.49f };
            PizzaMaster p4 = new PizzaMaster() { Id = 4, Type = "Neapolitan Pizza", Price = 99.49f };
            PizzaMaster p5 = new PizzaMaster() { Id = 5, Type = "Pizzetta", Price = 199.49f };
            PizzaMaster p6 = new PizzaMaster() { Id = 6, Type = "Bagel Pizza", Price = 239.69f };
            PizzaMaster p7 = new PizzaMaster() { Id = 7, Type = "Pepperoni", Price = 299.49f };
            PizzaMaster p8 = new PizzaMaster() { Id = 8, Type = "Chicken Pizza", Price = 249.99f };
            PizzaMaster p9 = new PizzaMaster() { Id = 9, Type = "Masala Pizza", Price = 249.99f };
            PizzaMaster p10 = new PizzaMaster() { Id = 10, Type = "Hawaiian Pizza", Price = 249.99f };

            plist.Add(p1);
            plist.Add(p2);
            plist.Add(p3);
            plist.Add(p4);
            plist.Add(p5);
            plist.Add(p6);
            plist.Add(p7);
            plist.Add(p8);
            plist.Add(p9);
            plist.Add(p10);
            return plist;

        }
        public PizzaMaster GetPizzaById(int id)
        {
            PizzaMaster pizza =plist.FirstOrDefault(p=>p.Id == id);   
            return pizza;
        }

    }
}
