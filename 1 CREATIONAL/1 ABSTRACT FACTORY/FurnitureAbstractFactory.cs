using System;
using System.Collections.Generic;

namespace FurnitureAbstractFactory
{
    //abstract factory
    public interface IFurnitureFactory              
    {
          IAbstractSofa CreateSofa();
          IAbstractChair CreateChair();
    }


    //concrete factor
    public class DesignFactory:IFurnitureFactory
    {
        public IAbstractSofa CreateSofa()
        {
            return new ConcreteDesignSofa();
        }

        public IAbstractChair CreateChair()
        {
            return new ConcreteDesignChair();
        }
    }

    public class ClassicalFactory:IFurnitureFactory
    {
        public IAbstractSofa CreateSofa()
        {
            return new ConcreteClassicSofa();
        }

        public IAbstractChair CreateChair()
        {
            return new ConcreteClassicChair();
        }

    }
    


    // abstract product

    public interface IAbstractSofa
    {
         string UseFullFunction();
    }


    public class ConcreteDesignSofa:IAbstractSofa
    {
        public string UseFullFunction()
        {
            return $"this is a {this.GetType().Name} with {this.GetType().FullName}";
        }
    }

    public class ConcreteClassicSofa:IAbstractSofa
    {
         public string UseFullFunction()
        {
            return $"this is a {this.GetType().Name} with {this.GetType().FullName}";
        }
    }
    //
    //product interface

    public interface IAbstractChair
    {
        string UseFullFunction();
    }

    public class ConcreteDesignChair:IAbstractChair
    {
        public string UseFullFunction()
        {
            return $"this is a {this.GetType().Name} with {this.GetType().FullName}";
        }
    }

    public class ConcreteClassicChair:IAbstractChair
    {
         public string UseFullFunction()
        {
            return $"this is a {this.GetType().Name} with {this.GetType().FullName}";
        }
    }



    //concrete product


    
    //client class
    public class Client
    {
         public Client()
         {
             System.Console.WriteLine("testing with design factory:");
          ClientMethod(new DesignFactory());
         }

         public void ClientMethod(IFurnitureFactory furnitureFactory)
         {
             var productA = furnitureFactory.CreateChair();
             var productB = furnitureFactory.CreateSofa();

             System.Console.WriteLine(productA.UseFullFunction());
         }
    }
}