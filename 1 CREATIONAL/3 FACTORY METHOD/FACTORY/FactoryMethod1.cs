using System;
using System.Collections.Generic;

namespace FactoryMethod1
{
    //creator
    public abstract class Creator
    {
        public abstract IProduct Create();
    }

    //concrete creator

    public class ConcreteCreator1:Creator
    {
        public override IProduct Create()
        {
            return new ConcreteProduct1();
        }
    }

    public class ConcreteCreator2:Creator
    {
        public override IProduct Create()
        {
            return new ConcreteProduct2();
        }

    }

    //product interface
    public interface IProduct
    {
        void Operate();
    }

    //concrete product  

    public class ConcreteProduct1:IProduct
    {
        public void Operate()
        {
            System.Console.WriteLine($" this is {this.GetType().Name}");
        }
    }

    public class ConcreteProduct2:IProduct
    {
        public void Operate()
        {
            System.Console.WriteLine($"this is {this.GetType().Name}");
        }
    }



    //client class
    public class Client
    {
         public Client()
         {
             ClientCode(new ConcreteCreator1());
         
         }

         public void ClientCode(Creator creator)
         {
             System.Console.WriteLine($"this is {creator.Create()}");
         }
    }
}