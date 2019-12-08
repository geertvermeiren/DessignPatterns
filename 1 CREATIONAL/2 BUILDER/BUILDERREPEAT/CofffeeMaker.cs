using System;
using System.Collections.Generic;

namespace CofffeeMaker
{
     //ibuilder
     public interface ICoffeeMaker
     {
           void HeatWater ();
           void SetCoffee ();
           void PourHotWater ();

           Coffee GetCoffee();
     }

     //concrete builder
      public class CoffeeBuilder:ICoffeeMaker
     {
          Coffee _coffee = new Coffee();
          

          public void HeatWater()
          {
               _coffee.Water += "Heating water";
          }
          public void SetCoffee()
          {
               _coffee.CoffeePowder += "set the coffee powder";
          }
          public void PourHotWater()
          {
               _coffee.HotWater += "hot water is begin poured";
          }

          public Coffee GetCoffee()
          {
               return _coffee;
          }
      
           
     }

     // Coffee
     public class Coffee
     {
          public string Water  { get; set; }
          public string HotWater { get; set; }
          public string CoffeePowder { get; set; }

        public void ShowInfo()
        {
     
            System.Console.WriteLine("Water {0}", Water);
            System.Console.WriteLine("CoffeePowder {0}", CoffeePowder);
            System.Console.WriteLine("Cups of Coffee {0}",HotWater);            
        }
        

     }


     //Director 
     public class Director
     {
          private readonly CoffeeBuilder _coffeeBuilder;

          public Director(CoffeeBuilder coffeeBuilder)
          {
               this._coffeeBuilder = coffeeBuilder;

          }

          public void CreateCoffee()
          {
               _coffeeBuilder.HeatWater();
               _coffeeBuilder.SetCoffee();
               _coffeeBuilder.PourHotWater();

          }

          public Coffee GetCoffee()
          {
               return GetCoffee();
          }
     }


     //client class
     public class Client
     {
           public Client()
           {
                Director d = new Director(new CoffeeBuilder());
                d.CreateCoffee();
                var coffee = d.GetCoffee();
                coffee.ShowInfo();
           
           }
     }
}