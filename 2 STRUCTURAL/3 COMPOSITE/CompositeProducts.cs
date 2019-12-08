using System;
using System.Collections.Generic;

namespace CompositeProducts
{
    //component
    public abstract class Product
    {
        public int price;
        public string name;
        public Product(string name,int price)
        {
            this.name = name;
            this.price = price;
            
        }

        public abstract int CalculateProductPrice();
    }

    public interface IProductOperations
    {
        void Add(Product product);
        void Remove(Product product);
    }


    //composite

    public class CompositeProduct:Product,IProductOperations
    {
        private List<Product> _products;

        public CompositeProduct(string name,int price):base(name,price)
        {        
            _products = new List<Product>();    
        }

        public void Add(Product product)
        {
            _products.Add(product);

        }
        
        public void Remove(Product product)
        {
            _products.Remove(product);

        }

        public override int CalculateProductPrice()
        {
            int total = 0;

             Console.WriteLine($"{name} contains the following products with prices:");


            foreach(var item in _products)
            {
                total += item.CalculateProductPrice();
                
            }
            return total;
        }
    }
    //leaf

    public class SingelProduct:Product
    {
        public SingelProduct(string name,int price):base(name,price)
        {            
        }

        public override int CalculateProductPrice()
        {
            System.Console.WriteLine($" the price {price } of {name}");
            return price;
        }
    }

    //client 

    public class Client
    {
        public Client()
        {
            var sp = new SingelProduct("brood",15);
            System.Console.WriteLine(sp.CalculateProductPrice());

            var cp = new CompositeProduct("box",0);
            var koek1 = new SingelProduct("koek1",3);
            var koek2 = new SingelProduct("koek2",3);
            var koek3 = new SingelProduct("koek3",3);
            var koek4 = new SingelProduct("koek4",3);

            cp.Add(koek1);
            cp.Add(koek2);
            cp.Add(koek3);
            cp.Add(koek4);
            cp.Add(sp);

            System.Console.WriteLine($"the price is {cp.CalculateProductPrice()}   ");


            
        }
    }
}
