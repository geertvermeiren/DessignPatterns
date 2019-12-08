using System;
using System.Collections.Generic;

namespace EggsTemplateMethod
{
    //abstract class
    public abstract class AbstractClass
    {
        public void TemplateMethod()
        {
            this.GetEggs();
            this.LightUpStove();
            this.Scramble();
            this.CookingTemp();
            this.AddTomato();
            this.AddOnion();
            this.AddBacon();

        }
        protected void GetEggs()
        {
            System.Console.WriteLine("getting eggs ");
        }

        protected void LightUpStove()
        {
            System.Console.WriteLine("light up the stove");
        }

        protected abstract void Scramble();
        protected abstract void CookingTemp();

        protected virtual void AddTomato()
        {
            System.Console.WriteLine("adding tomato");
        }

        protected virtual void AddOnion()
        {
            System.Console.WriteLine("adding onion");
        }

        protected virtual void AddBacon()
        {
            System.Console.WriteLine("adding bacon");
        }
    }


    //concrete class1

    public class ScrambledEggs:AbstractClass
    {
        protected override void Scramble()
        {
            System.Console.WriteLine("scrambling the eggs");
        }
        protected override void CookingTemp()
        {
            System.Console.WriteLine("normal temp");
        }
        protected override void AddBacon(){}
    }

    //concrete class2

     public class TomatoEggs:AbstractClass
    {
        protected override void AddTomato()
        {
            System.Console.WriteLine("adding tomato");
        }
        protected override void Scramble()
        {
            System.Console.WriteLine("scrambling");
        }

        protected override void CookingTemp()
        {
            System.Console.WriteLine("setting the cooking temp");
        }

        
     
     
     
    }
    //client class
    public class Client
    {
         public Client()
         {
             ClientCode(new ScrambledEggs());
             System.Console.WriteLine("*******");
             ClientCode(new TomatoEggs());
         }

         public void ClientCode(AbstractClass abstractClass)
         {
             abstractClass.TemplateMethod();
         }
    }
}