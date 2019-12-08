using System;
using System.Collections.Generic;
using System.Linq;


namespace OrderDecorator
{
    public class Product
    {
        public string Name { get; set; }
        public int Price { get; set; }
    }
    // COMPONENT
    public abstract class Order
    {
        protected List<Product> products = new List<Product>
        {
            new Product{Name="Phone",Price=587},
            new Product{Name="Tablet",Price=800},
            new Product{Name="Pc",Price=1200},

        };
        public abstract double CalculateTotalOrderPrice();
    }

// CONCRETE COMPONENT

     public class RegularOrder:Order
     {
         public override double CalculateTotalOrderPrice()
         {
             return products.Sum(x => x.Price);
         }
     }

     public class Preorder:Order
     {
         public override double CalculateTotalOrderPrice()
         {
             return products.Sum(x => x.Price) * 0.9;
         }
     } 


//DECORATOR

public class OrderDecorator: Order 
{
    Order _order;
    public  OrderDecorator(Order order)
    {
        this._order = order;

    } 

     public override double CalculateTotalOrderPrice()
     {
        System.Console.WriteLine($"calculating the total price in a decotrator class");
         return _order.CalculateTotalOrderPrice();

     }

}


//CONCRETE DECORATORA: DECORATOR

public class PremiumOrder:OrderDecorator
{
    public PremiumOrder(Order order):
    base(order)
    {

    }

    public override double CalculateTotalOrderPrice()
    {
        System.Console.WriteLine($"Calculating the total price in the {nameof(PremiumOrder)}");
        var PremiumOrderPrice= base.CalculateTotalOrderPrice();
        System.Console.WriteLine("adding aditional discount to order price");
        return PremiumOrderPrice * 0.9;
    }
}


//CONCRETE DECORATORB: DECORATOR

//CLIENT

public class Client
{
    public Client()
    {
        var ro = new RegularOrder();
        System.Console.WriteLine(ro.CalculateTotalOrderPrice());
        var po = new Preorder();
        System.Console.WriteLine(po.CalculateTotalOrderPrice());
        var prem = new PremiumOrder(po);
        System.Console.WriteLine(prem.CalculateTotalOrderPrice());
    }
}





}