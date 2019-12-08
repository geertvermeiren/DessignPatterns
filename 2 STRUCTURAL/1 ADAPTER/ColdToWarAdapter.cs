using System;
using System.Collections.Generic;

namespace ColdToWarAdapter
{
    //adaptee = base class to convert    
     public class ColdWater
    {
        public List<string> GetWater()
        {
            List<string> coldWater = new List<string>();
            coldWater.Add("cold");
            coldWater.Add("cold");
            coldWater.Add("cold");
            coldWater.Add("cold");
            coldWater.Add("cold");
            return coldWater;
        }    
    }

    //itarget = interface which define functionality

     public interface ITarget
     {
          List<string> GetColdWater();
     }
    //Adapter = implements interfacre
    public class WarmWater:ITarget
    {
        public List<string> GetColdWater()
        {
             ColdWater cw = new ColdWater();     
           

              List<string> ml = new List<string>();
              
             foreach(var item in cw.GetWater())
             {
                ml.Add(item.Replace("cold","warm"));
             }
             return ml;

        }
    }
    //client 
    //client class
    public class Client
    {
         public Client()
         { WarmWater ww = new WarmWater();
         foreach(var item in ww.GetColdWater())
         {
             System.Console.WriteLine(item);
         }
         
         }
    }
}