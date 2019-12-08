using System;
using System.Collections.Generic;

namespace BagAbstractFactory
{
    //iabstract factory

    public interface IAbstractBagFactory
    {
         IAbstractBackPack CreateBackPack();
         IAbstractNormalBag CreateNormalBag();
    }
    //concrete factory
    public class PatagoniaFactory:IAbstractBagFactory
    {
        public IAbstractBackPack CreateBackPack()
        {
            return new PatagoniaBackPack();
        }
         public IAbstractNormalBag CreateNormalBag()
         {
             return new PatagoniaNormalBag();
         }

    }

    public class NorthfaceFactory:IAbstractBagFactory
    {
        public IAbstractBackPack CreateBackPack()
        {
            return new NorthFaceBackPack();
        }
         public IAbstractNormalBag CreateNormalBag()
         {
             return new NorthFaceNormalBag();
         }


    }

    //abstract product

    public interface IAbstractBackPack
    {
         string Usefull();
    }

    public class PatagoniaBackPack:IAbstractBackPack
    {
        public string Usefull()
        {
            return $"this is a {this.GetType().Name}";
        }
    }

    public class NorthFaceBackPack:IAbstractBackPack
    {
        public string Usefull()
        {
            return $"this is a {this.GetType().Name}";
        }

    }
    

    public interface IAbstractNormalBag
    {       
         string Usefull ();
    }

    public class PatagoniaNormalBag:IAbstractNormalBag
    {
        public string Usefull()
        {
            return $"this is a {this.GetType().Name}";
        }
    }

    //concrete product
     public class NorthFaceNormalBag:IAbstractNormalBag
     {
     public string Usefull()
        {
            return $"this is a {this.GetType().Name}";
        }
 
     
    }
    //client class
    public class Client
    {
         public Client()
         {
             System.Console.WriteLine("patagonia");
               ClientMethod(new PatagoniaFactory());
               System.Console.WriteLine("northface");
               ClientMethod(new NorthfaceFactory());
         }

         public void ClientMethod(IAbstractBagFactory abstractBagFactory)
         {
             var backpack = abstractBagFactory.CreateBackPack();
             var normalbag = abstractBagFactory.CreateNormalBag();

            System.Console.WriteLine(backpack.Usefull());
            System.Console.WriteLine(normalbag.Usefull());
         }
    }
}