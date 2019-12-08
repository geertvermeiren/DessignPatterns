using System;
using System.Collections.Generic;

namespace BreadTemplateMethod
{
    //abstract
    public abstract class AbstractClass
    {
        public void TemplateMethod()
        {
            this.Wheat();
            this.Flour();
            this.Water();
            this.Mix();
            this.Granes();
            this.Raisins();
            this.BakingTime();
        }

        protected void Wheat()
        {
            System.Console.WriteLine("Wheat");
        }
        protected void Flour()
        {
            System.Console.WriteLine("flour");
        }
        protected void Water()
        {
            System.Console.WriteLine("water added");
        }
        protected void Mix()
        {
            System.Console.WriteLine("all is mixed");
        }

        protected abstract void BakingTime();

        protected virtual void Granes()
        {
            System.Console.WriteLine("add granes");
        }
        protected virtual void Raisins()
        {
            System.Console.WriteLine("add raisins");
        }
    }


    //concrete bread1
    public class NormalBread:AbstractClass
    {
        protected override void BakingTime()
        {
            System.Console.WriteLine("a normal baking time");
        }
        protected override void Raisins(){}
    }

    //concrete bread 2 
     public class RaisinsBread:AbstractClass
    {
        protected override void BakingTime()
        {
            System.Console.WriteLine("a slightly elevated baking time");
        }    
     
     
    }
    //client class
    public class Client
    {
         public Client()
         {
             ClientCode(new NormalBread());
             System.Console.WriteLine("**********");
             ClientCode(new RaisinsBread());
         
         }

         public void ClientCode(AbstractClass abstractClass)
         {
             abstractClass.TemplateMethod();
         }
    }
}