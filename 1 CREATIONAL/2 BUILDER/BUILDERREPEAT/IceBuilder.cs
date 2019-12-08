using System;
using System.Collections.Generic;

namespace IceBuilder
{
    //ibuilder
    public interface IIceBuilder
    {
         void PourWater ();
         void FreezeWater ();
         Ice GetIce();       

        
    }

    //concrete builder
    public class ConcreteIceMaker:IIceBuilder
    {
        Ice _ice = new Ice();

        public void PourWater()
        {
            _ice.Water = "pour water "; 
        }
        public void FreezeWater()
        {
            _ice.Freezer = "freeze water";
        }
        public Ice GetIce()
        {
            return _ice;
        }
    }
    

    //product
    

     public class Ice
    {
        public string Water { get; set; }
        public string Freezer { get; set; }
     
        public void ShowInfo()
        {
            System.Console.WriteLine($"water {Water}");
            System.Console.WriteLine($"freezer {Freezer}");
        }
     
     
    }
    //director
    public class Director
    {
        IIceBuilder _iceBuilder;
        public Director(IIceBuilder iceBuilder)
        {
            this._iceBuilder = iceBuilder;
        }

        public void MakeIce()
        {
            _iceBuilder.PourWater();
            _iceBuilder.FreezeWater();
        }

        public Ice GetIce()
        {
            return _iceBuilder.GetIce();
        }
    }

    //client class
    public class Client
    {
         public Client()
         {
             Director d = new Director(new ConcreteIceMaker());
             d.MakeIce();
             Ice ice = d.GetIce();
             ice.ShowInfo();
         
         }
    }
}