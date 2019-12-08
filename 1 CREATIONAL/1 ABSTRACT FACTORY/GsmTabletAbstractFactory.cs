using System;
using System.Collections.Generic;

namespace GsmTabletAbstractFactory
{
     
     //acstract factory
     public interface IElectronicsAbstractFactory
     {
          IAbstractGsm CreateGSM();
          IAbstractTablet CreateTablet();
     }

     //concrete factory 
     public class SamsungFactory:IElectronicsAbstractFactory
     {
         public IAbstractGsm CreateGSM()
         {
             return new SamsungGSM();
         }

         public IAbstractTablet CreateTablet()
         {
             return new SamsungTablet();
         }
     }

     public class AppleFactory:IElectronicsAbstractFactory
     {
         public IAbstractGsm CreateGSM()
         {
             return new AppleGSM();
         }

         public IAbstractTablet CreateTablet()
         {
             return new AppleTablet();
         }
     }

     //iAbstractproduct 

     public interface IAbstractGsm
     {
          string UsefullFunction();
     }

    public class SamsungGSM:IAbstractGsm
    {
        public string UsefullFunction()
        {
            return $"creating a {this.GetType().Name}";
        }
    }

    public class AppleGSM:IAbstractGsm
    {
        public string UsefullFunction()
        {
            return $"creating a {this.GetType().Name}";
        }

    }

     public interface IAbstractTablet
     {
         string UsefullFunction();
     }

     //concrete product
     
     public class SamsungTablet:IAbstractTablet
     {
          public string UsefullFunction()
        {
            return $"creating a {this.GetType().Name}";
        }

     }

     public class AppleTablet:IAbstractTablet
     {
         public string UsefullFunction()
         {
             return $"creating a {this.GetType().Name}";
         }
     }
     
     
    
    //client class
    public class Client
    {
         public Client()
         {
             System.Console.WriteLine("apple:");
             ClientMethod(new AppleFactory());
             System.Console.WriteLine("samsung:");
             ClientMethod(new SamsungFactory());
         
         }

         public void ClientMethod(IElectronicsAbstractFactory electronicsAbstractFactory)
         {
             var gsm = electronicsAbstractFactory.CreateGSM();

             var tablet = electronicsAbstractFactory.CreateTablet();

             System.Console.WriteLine(gsm.UsefullFunction());
             System.Console.WriteLine(tablet.UsefullFunction());

         }
    }
}