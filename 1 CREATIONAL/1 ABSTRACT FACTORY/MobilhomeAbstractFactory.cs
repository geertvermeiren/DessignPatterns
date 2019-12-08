using System;
using System.Collections.Generic;

namespace MobilhomeAbstractFactory
{
     //abstracgt factory interface

   public interface IMobilHomeAbstractFactory
   {
        IAbstractAlcove CreateAlcove ();
        IAbstractIntegral CreateIntegral ();
   }
     //concrete factory interface 
     public class IniteoFactory:IMobilHomeAbstractFactory
     {
         public IAbstractAlcove CreateAlcove()
         {
             return new ItineoAlcove();
         }
         public IAbstractIntegral CreateIntegral()
         {
             return new ItineoIntegral();
         }   
    }

     public class MrLouisFactory:IMobilHomeAbstractFactory
     {
           public IAbstractAlcove CreateAlcove()
         {
             return new McLouisAlcove();
         }
         public IAbstractIntegral CreateIntegral()
         {
             return new McLoiusIntegral();
         }   


     }

     //abstract product
     public interface IAbstractAlcove
     {
          string Usefull();
     }

     //concrete product
     public class ItineoAlcove:IAbstractAlcove
     {
         public string Usefull()
         {
             return $"this is a {this.GetType().Name}";
         }
     }

     public class McLouisAlcove:IAbstractAlcove
     {
         public string Usefull()
         {
             return $"this is a {this.GetType().Name}";
         }

     }

     public interface IAbstractIntegral
     {
          string Usefull();
     }

     public class ItineoIntegral:IAbstractIntegral
     {

         public string Usefull()
         {
             return $"this is a {this.GetType().Name}";
         }
     }

     public class McLoiusIntegral:IAbstractIntegral
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
             System.Console.WriteLine("intineo:");
             ClientMethod(new IniteoFactory());
             System.Console.WriteLine("McLouis");
             ClientMethod(new MrLouisFactory());
         }
         public void ClientMethod(IMobilHomeAbstractFactory mobilhomeAbstractFactory)
         {
             var alcove = mobilhomeAbstractFactory.CreateAlcove();
             var integral = mobilhomeAbstractFactory.CreateIntegral();

             System.Console.WriteLine(alcove.Usefull());
             System.Console.WriteLine(integral.Usefull());


         }
    }
}