using System;
using System.Collections.Generic;

namespace TemplateMethod3
{
    //abstract class
    public abstract class AbstractClass
    {
        public void TemplateMethod()
        {
            this.BaseOperation1();
            this.RequiredOperation1();
            this.Hook1();
            this.BaseOperation2();
            this.RequiredOperation2();
            this.Hook2();
        }

        protected void BaseOperation1()
        {
            System.Console.WriteLine("this is work done in abstract class");
        }
        protected void BaseOperation2()
        {
            System.Console.WriteLine("this is work done in abstract class");
        }

        protected abstract void RequiredOperation1();
        protected abstract void RequiredOperation2();

        protected virtual void Hook1(){}

        protected virtual void Hook2(){}


    }

    //concrete class1

    public class ConcreteClass1:AbstractClass
    {
        protected override void RequiredOperation1()
        {
            System.Console.WriteLine($" required 1:  {this.GetType().MemberType.GetType().Name}");
        }
        protected override void RequiredOperation2()
        {
            System.Console.WriteLine($" required 1:  {this.GetType().MemberType.GetType().Name}");

        }
        protected override void Hook1()
        {
            System.Console.WriteLine("this is hook 1");
        }
    }

    //concrete class2
    public class ConcreteClass2:AbstractClass
    {
        protected override void RequiredOperation1()
        {
            System.Console.WriteLine($" this is : {this.GetType().Name}");
        }
        protected override void RequiredOperation2()
        {
            System.Console.WriteLine($" this is : {this.GetType().Name}");
            
        }
    }
    
    //client class
    public class Client
    {
         public Client()
         {
             ClientCode(new ConcreteClass1());
         System.Console.WriteLine("-----");
            ClientCode(new ConcreteClass2());
         }
         public void ClientCode(AbstractClass abstractClass)
         {
             abstractClass.TemplateMethod();
         }
    }
}