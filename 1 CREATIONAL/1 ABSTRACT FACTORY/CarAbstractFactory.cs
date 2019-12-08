using System;
using System.Collections.Generic;

namespace CarAbstractFactory
{
    //abstract factory = family of methodes wich create 
    public interface ICarAbstractFactory
    {
         IAbstractSportsCar CreateSportsCar ();
         IAbstractNormalCar CreateNormalCar ();
    }

    //concrete factory = method where concrete product is instaniated

    public class AudiFactory:ICarAbstractFactory
    {
        public IAbstractSportsCar CreateSportsCar()
        {
            return new Porsche();
        }
        public IAbstractNormalCar CreateNormalCar()
        {
            return new Audi();
        }

        
    }

    //
    public class FiatFacotry:ICarAbstractFactory
    {
       public  IAbstractSportsCar CreateSportsCar()
        {
            return new Ferrari();
        }
        public IAbstractNormalCar CreateNormalCar()
        {
            return new Fiat();
        }
    }

    public interface IAbstractSportsCar
    {
         string UsefullFunction();
    }

    public class Porsche:IAbstractSportsCar
    {
        public string UsefullFunction()
        {
            return $"this is a {this.GetType().Name}";
        }
    }

    public class Ferrari:IAbstractSportsCar
    {
        public string UsefullFunction()
        {
            return $"this is a {this.GetType().Name}";
        }
    }

    public interface IAbstractNormalCar
    {
        string UsefullFunction();
    }

    public class Fiat:IAbstractNormalCar
    {
        public string UsefullFunction()
        {
            return $"this is a {this.GetType().Name}";
        }
    }

    public class Audi:IAbstractNormalCar
    {
        public string UsefullFunction()
        {
            return $"this is a {this.GetType().Name}";
        }
    }




    //client class
    public class Client
    {
         public Client()
         {
             System.Console.WriteLine("The audi-group produces:");
             ClientMethod(new AudiFactory());
             System.Console.WriteLine("-----------");
             System.Console.WriteLine("The Fiat-group produces:");
             ClientMethod(new FiatFacotry());
         }
         
         

         public void ClientMethod(ICarAbstractFactory carAbstractFactory)
         {
             var normalcar = carAbstractFactory.CreateNormalCar();
             var sportscar = carAbstractFactory.CreateSportsCar();
            System.Console.WriteLine("this should be a normal car:");
             System.Console.WriteLine(normalcar.UsefullFunction());
             System.Console.WriteLine("this should be a sportscar:");
             System.Console.WriteLine(sportscar.UsefullFunction());

         }
    }
}