using System;

namespace TruckBuilder
{
    //interface

    public interface IBuilder
    {
        void BuildBody();

        void BuildWheels();

        Truck GetProduct();        
    }

    //concreteBuilder

    public class BuildTruck:IBuilder
    {
        Truck _truck = new Truck();
        public void BuildBody()
        {
           _truck.Body = "building the body"; 
        }

        public void BuildWheels()
        {
            _truck.Wheels = "Building the weels";
        }

        public Truck GetProduct()
        {
            return _truck;
        }

    }

    //product

    public class Truck
    {
        public string Body { get; set; }
        public string  Wheels { get; set; }

        public void ShowInfo()
        {
            System.Console.WriteLine("Truck {0}",Body);
            System.Console.WriteLine("Wheels {0}",Wheels);

        }

    }


    // director

    public class Director
    {
        private readonly IBuilder _truckBuilder;

        public Director(IBuilder truckBuilder)
        {
            this._truckBuilder = truckBuilder;
        }

        public void CreateTruck()
        {
            _truckBuilder.BuildBody();
            _truckBuilder.BuildWheels();
        }

        public Truck GetProduct()
        {
            return _truckBuilder.GetProduct();
        }
    }

    // client

    public class  TruckClient
    {
        public TruckClient()
        {
            var director = new Director(new BuildTruck());
            director.CreateTruck();
            var truck =  director.GetProduct();
            truck.ShowInfo();
        }
    }
}

