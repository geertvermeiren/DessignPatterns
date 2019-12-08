using System;
using System.Linq;
using System.Collections.Generic;

//add aditional dynamic behavior to objects by placing an object inside a special wrapper

namespace CarDecorator
{
    public class Parts
    {        public int Id { get; set; }
    }
    //components
    public abstract class Car
    {
        public List<Parts> parts = new List<Parts>
        {
         new Parts{Id = 1},
         new Parts{Id = 2},
         new Parts{Id = 3},
         new Parts{Id = 4},
         new Parts{Id = 5}
        };
        public abstract int CountParts();
    }

    //concrete component
     public class BasicCar: Car
     {
         public override int CountParts()
         {
             return parts.Count();
         }


     }


    //decorator

    public class SportsCarDecorator:Car
    {
        Car _car;
        public SportsCarDecorator(Car car)
        {
            this._car = car;
        }

        public override int CountParts()
        {
            return _car.CountParts();
        }
    }

    //concrete decorator

    public class SportsCar: SportsCarDecorator
    {
        public SportsCar(Car car):base(car){}

        public override int CountParts()
        {
            return base.CountParts() + 3;
        }
    }

    public class Client
    {
        public Client()
        {
            var bc = new BasicCar();
            System.Console.WriteLine(bc.CountParts());
            System.Console.WriteLine("*****");
            var sc = new SportsCar(bc);
            System.Console.WriteLine(sc.CountParts());
            
        }

    }

}

