using System;
using System.Collections.Generic;

//https://www.dotnettricks.com/learn/designpatterns/builder-design-pattern-dotnet


namespace HondaBuilder
{
    //IBuilder

    public interface IVehicleBuilder
    {
        void SetEngine();
        void SetBody();
        void SetTransmission();

        void SetAccessories();

        Vehicle GetVehicle();
        
    }

    //ConcreteBuilder
    public class HondaBuilder:IVehicleBuilder
    {
        Vehicle vehicle = new Vehicle();
        
        public void SetEngine()
        {
            vehicle.Engine = "four stroke";
        }
        public   void SetBody()
        {
            vehicle.Body = "honda";
        }
        public void SetTransmission()
        {
            vehicle.Transmission = "automatic";
        }

        public void SetAccessories()
        {
            vehicle.Accessories.Add("radio");
            vehicle.Accessories.Add("open rooftop");
            vehicle.Accessories.Add("wifi loader");

        }

        public Vehicle GetVehicle()
        {
            return vehicle;
        }

        

    }

    //Product = honda
    public class Vehicle
    {
        public string Engine { get; set; }
        public string  Body { get; set; }
        public string Transmission { get; set; }
        public List<string> Accessories { get; set; }

        public Vehicle()
        {
            Accessories = new List<string>();
            
        }

        public void ShowInfo()
        {
            System.Console.WriteLine("Engine {0}", Engine );
            System.Console.WriteLine("Body {0}", Body );
            System.Console.WriteLine("Transmission {0}", Transmission );
            System.Console.WriteLine("Accessories ");
            foreach(var accessory in Accessories)
            {

                System.Console.WriteLine("\t{0}",accessory);
            }
        }
    }

    //Director

    public class HondaDirector
    {
        private readonly IVehicleBuilder _vehicleBuilder;

        public HondaDirector(IVehicleBuilder vehicleBuilder)
        {
            this._vehicleBuilder = vehicleBuilder;
        }
        public void CreateVehicle()
        {
            _vehicleBuilder.SetEngine();
            _vehicleBuilder.SetBody();
            _vehicleBuilder.SetTransmission();
            _vehicleBuilder.SetAccessories();

        }
        public Vehicle GetVehicle()
        {
            return _vehicleBuilder.GetVehicle();
        }

    }

    public class HondaClient
    {
        static HondaClient()
        {
          System.Console.WriteLine("****HONDABUILDER********");
            System.Console.WriteLine(DateTime.Now.ToLongTimeString());
        }


       public HondaClient()
      {
          var director = new HondaDirector(new HondaBuilder());
          director.CreateVehicle();
          var vehicle = director.GetVehicle();
          vehicle.ShowInfo();
      }

    }
}