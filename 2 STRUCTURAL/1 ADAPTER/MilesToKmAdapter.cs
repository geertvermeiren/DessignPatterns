using System;
using System.Collections.Generic;

namespace MilesToKmAdapter
{
    //adaptee = miles

    public class AdapteeMiles
    {
       public List<int> GetListOfDistanceInKM()
       {
           List<int> _dinstance = new List<int>();
            _dinstance.Add(3);
            _dinstance.Add(5);
            _dinstance.Add(6);
            _dinstance.Add(8);
            return _dinstance;
       }
    }
    //itarget = interface used to specify the functionality

    public interface ITarget
    {
         List<int> GetDistances();
    }
    //adapter= class which implements itarget
    //client = uses functionality
     public class KmAdapter:ITarget
    {
      public List<int> GetDistances()
      { var am = new AdapteeMiles();
          return am.GetListOfDistanceInKM();
          
      }      
     
     
    }
    //client class
    public class Client
    {
         public Client()
         {
             KmAdapter ka = new KmAdapter();
             
             foreach(var item in ka.GetDistances())
             { 
                               
                  System.Console.WriteLine(item * 1.6);
             }

         
         }
    }
}