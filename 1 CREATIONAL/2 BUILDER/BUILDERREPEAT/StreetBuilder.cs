using System;
using System.Collections.Generic;

namespace StreetBuilder
{
    //Ibuilder
    public interface IStreetBuilder
    {
         void Equalize();
         void MakeConcrete();

         void PourConcrete();
         Street GetStreet();
    }
    //concreteBuilder
    public class ConcreetStreetBuilder:IStreetBuilder
    {
        Street street = new Street();

        public void Equalize()
        {
            street.Terrain += "equalizing the terrain";
        }

        public void MakeConcrete()
        {
            street.Concrete += "concrete is being made";
        }

        public void PourConcrete()
        {
            street.ConcreteMachine += "concrete is being poured";
        }

        public Street GetStreet()
        {

            return street;
        }


    }

    // product
    public class Street
    {
        public string Terrain  { get; set; }
        public string Concrete { get; set; }
        public string  ConcreteMachine { get; set; }

        public void ShowInfo()
        {
            System.Console.WriteLine($"terrain:{Terrain}");
            System.Console.WriteLine($"Concrete:{Concrete}");
            System.Console.WriteLine($"Concrete pouring:{ConcreteMachine}");
            

        }
     
    }

    //director 

    public class Director
    {
        ConcreetStreetBuilder _concreetStreetBuilder ;
        public Director(ConcreetStreetBuilder concreetStreetBuilder)
        {
            this._concreetStreetBuilder = concreetStreetBuilder;
        }

        public void CreateStreet()
        {
            _concreetStreetBuilder.Equalize();
            _concreetStreetBuilder.MakeConcrete();
            _concreetStreetBuilder.PourConcrete();
        }

        public Street GetStreet()
        {
            return _concreetStreetBuilder.GetStreet();
        }
    }


    //client class
    public class Client
    {
         public Client()
         {
              Director d = new Director(new ConcreetStreetBuilder());
              d.CreateStreet();
              var street = d.GetStreet();
              street.ShowInfo();
         
         }
    }
}