using System;
using System.Collections.Generic;

namespace AirPlaneAbstractFactory
{
     //abstract factory interface
     public interface IAirPlaneAbstractFactory
     {
          IAbstractJet CreateJet ();

          IAbstractPassenger CreatePassenger();
     }

     //concrete factory 

     public class BoeingFactory:IAirPlaneAbstractFactory
     {
         public IAbstractJet CreateJet()
         {
             return new BoeingJet();
         }

         public IAbstractPassenger CreatePassenger()
         {
             return new BoeingPassenger();
         }
     }

     

     //abstract product
    public interface IAbstractJet
    {
        string Usefull();
    }
     //concrete product
     public class BoeingJet:IAbstractJet
     {
         public string Usefull()
         {
             return $"this is a {this.GetType().Name}";
         }
     }

     public interface IAbstractPassenger
     {
          string Usefull();
     }

     public class BoeingPassenger:IAbstractPassenger
     {
         public string Usefull()
         {
             return $"this is a {this.GetType().Name}";
          
         }
     }

    //client class
    public class Client
    {
         public Client()
         {
             System.Console.WriteLine("boeing:");
             ClientMethod(new BoeingFactory());
         }

         public void ClientMethod(IAirPlaneAbstractFactory airPlaneAbstractFactory)
         {
            var jet =airPlaneAbstractFactory.CreateJet();
            var pass = airPlaneAbstractFactory.CreatePassenger();
            System.Console.WriteLine(jet.Usefull());
            System.Console.WriteLine(pass.Usefull());
         }
    }
}