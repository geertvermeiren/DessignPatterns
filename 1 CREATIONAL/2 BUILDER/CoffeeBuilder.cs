using System;
using System.Collections.Generic;

namespace CoffeeBuilder
{

    //IBuilder
    public interface ICoffeeBuilder
    {
        void SetCoffeePowder();
        void PourWater();
        void PourCoffee();

        Coffee GetCoffee();
        
    }

    //ConcreteBuilder

    public class CoffeeMaker:ICoffeeBuilder
    {
        Coffee _coffee = new Coffee();

        public void SetCoffeePowder()
        {
            _coffee.CoffeePowder = "pure black powder";
        }

        public void PourWater()
        {

            _coffee.Water = "pouring hot water";
        }

        public void PourCoffee()
        {
            _coffee.CupOfCoffee = 4;
        }

        public Coffee GetCoffee()
        {
            return _coffee;
        }
    }


    //Product

    public class Coffee
    {
        public string Water { get; set; }
        public string CoffeePowder { get; set; }

        public int CupOfCoffee { get; set; }

        public void ShowInfo()
        {
            System.Console.WriteLine("Water {0}", Water);
            System.Console.WriteLine("CoffeePowder {0}", CoffeePowder);
            System.Console.WriteLine("Cups of Coffee {0}",CupOfCoffee);            
        }


    }

    //Director

    public class CoffeeLady
    {
        private readonly ICoffeeBuilder _coffeeBuilder;

        public CoffeeLady(ICoffeeBuilder CoffeeBuilder)
        {
            this._coffeeBuilder = CoffeeBuilder;            
        }

        public void CreateCoffee()
        {
            _coffeeBuilder.SetCoffeePowder();
            _coffeeBuilder.PourWater();
            _coffeeBuilder.PourCoffee();
        }

        public Coffee GetCoffee()
        {
            return _coffeeBuilder.GetCoffee();
        }


    }
    //Client

    public class CoffeeClient
    {
        public CoffeeClient()
        {
            var director = new CoffeeLady(new CoffeeMaker());
            director.CreateCoffee();
            var coffee = director.GetCoffee();
            coffee.ShowInfo();
        }
    }




}
