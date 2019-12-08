using System;
using System.Collections.Generic;

namespace ComputerAbstractFactory
{
    //abstract factory

     public interface AbstractComputerFactory
    {
        IAbstractDesktop CreateDesktop();

        IAbstractLaptop CreateLaptop();
     
     
    }

    //concrete factory

    public class AppleFactory:AbstractComputerFactory
    {
        public IAbstractDesktop CreateDesktop()
        {
            return new AppleDesktop();
        }

        public IAbstractLaptop CreateLaptop()
        {
            return new AppleLaptop();
        }
    }

    public class SamsungFactory:AbstractComputerFactory
    {
        public IAbstractDesktop CreateDesktop()
        {
            return new SamsungDesktop();
        }
        public IAbstractLaptop CreateLaptop()
        {
            return new SamsungLaptop();
        }
    }

    //abstract product
    public interface IAbstractDesktop
    {
         string Usefull();
    }

    public class AppleDesktop:IAbstractDesktop
    {
        public string Usefull()
        {
            return $"{this.GetType().Name} being created"; 
        }
    }

    public class SamsungDesktop:IAbstractDesktop
    {
        public string Usefull()
        {
            return $"{this.GetType().Name} being created"; 
        }

    }

    public interface IAbstractLaptop
    {
        string Usefull();   
    }

    public class AppleLaptop:IAbstractLaptop
    {
        public string Usefull()
        {
            return $"{this.GetType().Name} being created"; 
        }

    }

    public class SamsungLaptop:IAbstractLaptop
    {
        public string Usefull()
        {
            return $"{this.GetType().Name} being created"; 
        }

    }

    //concrete product

    //client class
    public class Client
    {
         public Client()
         {
          ClientMethod(new AppleFactory());
         }

         public void ClientMethod(AbstractComputerFactory abstractComputerFactory)
         {
             var desktop = abstractComputerFactory.CreateDesktop();
             var laptop = abstractComputerFactory.CreateLaptop();

             System.Console.WriteLine(desktop.Usefull());
             System.Console.WriteLine(laptop.Usefull());

         }
    }
}