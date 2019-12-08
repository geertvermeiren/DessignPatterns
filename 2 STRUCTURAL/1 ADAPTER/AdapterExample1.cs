using System;
using System.Collections.Generic;

namespace GOF3
{

    interface ITarget
    {
        List<string> GetProducts();
    }

    public class VendorAdaptee
    {
         public List<string> GetListOfProducts()
         {
             List<string> products = new List<string>();
             products.Add("product 1");
             products.Add("product 2");
             products.Add("product 3");
             products.Add("product 4");
             products.Add("product 5");
             return products;
         }

    }

    public class VendorAdapter:ITarget
    {
       public List<string> GetProducts()
        {
            var va = new VendorAdaptee();
            return va.GetListOfProducts();
        }
    }

    public class Client
    {
         public Client()
         {
             VendorAdapter va = new VendorAdapter();
             var myproducts =  va.GetProducts();
             foreach(var item in myproducts)
             System.Console.WriteLine(item);

             
         }
    }

}