using System;
using System.Collections.Generic;

namespace TemplateMethod2
{
    //abstract class
    public abstract class AbstractClass
     {
         public void TemplateMethode()
         {
             this.BaseOperation1();
             this.RequiredOperation1();
             this.BaseOperation2();
             this.RequiredOperation2();
             this.Hook1();
             this.Hook1();

         }
         public void BaseOperation1()
         {
             System.Console.WriteLine("abstract class: I am doing the buld of work");
         }
         public void BaseOperation2()
         {
             System.Console.WriteLine("abstract class: i am doing the buld of work");
         }

         public void BaseOpeartion3()
         {
             System.Console.WriteLine("abstract class: I am doing the buld of work");
         }

         protected abstract void RequiredOperation1();
         protected abstract void RequiredOperation2();

         protected virtual void Hook1(){}

         protected virtual void Hook2(){}

     }


    //concrete class 1
    public class ConcreteClass1:AbstractClass
    {
        protected override void RequiredOperation1()
        {
           
            System.Console.WriteLine($"requiredoperation 1: {this.GetType().Name}");

        }
        protected override void RequiredOperation2()
        {
            System.Console.WriteLine($"requiredoperation 2: {this.GetType().Name}");
        }
    }

    public class ConcreteClass2:AbstractClass
    {
        protected override void RequiredOperation1()
        {
            System.Console.WriteLine($"requiredoperation 1: {this.GetType().Name}");

        }

        protected override void RequiredOperation2()
        {
            System.Console.WriteLine($"requiredoperation 2: {this.GetType().Name}");
        }

        protected override void Hook1()
        {
            System.Console.WriteLine("this is hook1 ");

        }
    }


    public class Client
    {
         public Client()
         {
             ClientCode(new ConcreteClass1());

             System.Console.WriteLine("******");
             ClientCode(new ConcreteClass2());
         
         }

         public void ClientCode(AbstractClass abstractClass)
         {
             abstractClass.TemplateMethode();
             

         }
    }
}