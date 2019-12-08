using System;
using System.Collections.Generic;

namespace SolidToLiquidAdapter
{
    //adaptee = class to transform
     public class Solid
    {
        public List<string> GetSolidSubstance()
        {
            List<string> _solid = new List<string>();
            _solid.Add("solid");
            _solid.Add("solid");
            _solid.Add("solid");
            _solid.Add("solid");
            _solid.Add("solid");
            return _solid;
        }
     
     
     
    }
    //itarget: inteface function to transform

    public interface ITarget
    {
         List<string> TransformToLiquid();
    }

    //adatper; iimplementation of the interfae
    public class Adapter:ITarget
    {
        public List<string> TransformToLiquid()
        {  
            Solid _solid = new Solid();
            List<string> _liquid = new List<string>();

            foreach(var item in _solid.GetSolidSubstance())
            {
                if(item == "solid")
                _liquid.Add("liquid");

            }
            
            return _liquid;
            
        }
    }
    //client class
    public class Client
    {
         public Client()
         {
             Adapter adapter = new Adapter();

             foreach(var item in adapter.TransformToLiquid())
             {
                 System.Console.WriteLine(item);
             
             }
         
         }
    }
}