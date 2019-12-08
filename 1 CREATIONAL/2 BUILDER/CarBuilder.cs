using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace CarBuilder
{
    //IBuilder

    public interface ICarBuilder
    {
        void BuildCarcas();
        void BuildWheels();
        void BuildEngine();
        
    }

    //CONCRETE BUILDER

    public class BuildCar:ICarBuilder
    {
        private IEnumerable<Car> _car ; 

        private CarParts _carParts;

        public BuildCar(IEnumerable<Car> car)
        {
            this._car = car;
            this._carParts = new CarParts();
            
        }

        public void BuildCarcas()
        {
            _carParts.Part1 = "test"+_car.SingleOrDefault();
            
                     

        }

        public void BuildEngine()
        {

            System.Console.WriteLine("building the engine " );
        }

        public void BuildWheels()
        {
            System.Console.WriteLine("building the  " + _car.Select(c=> c.Wheels) );
        }



        public  CarParts GetCar()
        {
            var carParts = _carParts;
            Clear();
            return _carParts;

        }
        private void Clear()
        {
            var _carParts = new CarParts();
        }


    }

    //PRODUCT

    public class Car
    {
        public string Carcas { get; set; }
        public string  Wheels { get; set; }
        public string  Engine { get; set; }
    }

    public class CarParts
    {
        public string Part1 { get; set; }
        public string Part2 { get; set; }
        public string Part3 { get; set; }
         public override string ToString() =>
        new StringBuilder()
        .AppendLine(Part1)
        .AppendLine(Part2)
        .AppendLine(Part3)
        .ToString();
    }

    // DIRECTOR 

    public class CarDirector
    {
        private readonly ICarBuilder _carBuilder;

        public CarDirector(ICarBuilder CarBuilder)
        {
            this._carBuilder = CarBuilder;
            
        }

        public void BuildThatCar()
        {
            _carBuilder.BuildCarcas();
            _carBuilder.BuildEngine();
            _carBuilder.BuildWheels();
        }


    }

    public class ClientCarBuilder
    {
        public ClientCarBuilder()
        {
            
            System.Console.WriteLine("****CARBUILDER****");
            var cars = new List<Car>
            {
                new Car{Carcas = "blue",Engine = "8v",Wheels="duplon"},
                new Car{Carcas = "red",Engine = "2cv",Wheels="michelin"},
                new Car{Carcas = "yellow",Engine = "10v",Wheels="duplon"},
                new Car{Carcas = "green",Engine = "2000cc",Wheels="michelin"}
            };

            var builder2 = new BuildCar(cars);
            var director2 = new CarDirector(builder2);
            var buildThatCar = builder2.GetCar();
            System.Console.WriteLine(buildThatCar);

            
        }
    }





}