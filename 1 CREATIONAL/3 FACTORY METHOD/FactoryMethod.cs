using System;
using System.Collections.Generic;

namespace FactoryMethod
{
    public abstract class Creator
    {
        public abstract IProduct FactoryMethod();
        public string SomeOperation()
        {
            var product = FactoryMethod();
          var result = " Creator: the same code has just worked with :" + product.Operation();
          return result;
        }
    }

    class ConcreteCreator1: Creator
    {

            public override IProduct FactoryMethod()
            {
                return new ConcreteProduct1();
            }
        
    }

    class ConcreteCreator2: Creator
    {
            public override IProduct FactoryMethod()
            {
                return new ConcreteProduct2();
            }

    }

    public interface IProduct
    {
        string Operation();
    }

    public class  ConcreteProduct1:IProduct
    {
        public string Operation()
        {
            return "{result of concrete product}";
        }
    } 

    public class ConcreteProduct2: IProduct
    {
        public string Operation()
        {
            return "{result of concrete product}";
        }
    }

   public class Client
   {
       public void Main()
       {
        
       }

       public void ClientCode(Creator creator)
       {
           System.Console.WriteLine("client: I am not aware of the creator class but is stil works " + creator.SomeOperation()  );


       }
   }

}