using System;
using System.Collections.Generic;

namespace WatchAbstractFactory
{
    //abstract factory
    public interface IAbstractWatchFactory
    {
        IEWatch CreateEWatch2017();
        IEWatch CreateEWatch2019();
    }

    //concrete factory
    public class AppleFactory:IAbstractWatchFactory
    {
        public IEWatch CreateEWatch2017()
        {
            return new AppleWatch3();
        }
        public IEWatch CreateEWatch2019()
        {
            return new AppleWatch4();
        }
    }


    //abstract product
    public interface IEWatch
    {
         void Usefull();
    }

    //concrete product
    public class AppleWatch4:IEWatch
    {
        public void Usefull()
        {
            System.Console.WriteLine("building an apple watch 4");
        }
    }

     public class AppleWatch3:IEWatch
    {
        public void Usefull()
        {
            System.Console.WriteLine("building an apple watch 3");
        }
    }

    //client class
    public class Client
    {
         public Client()
         {
          ClientMethod(new AppleFactory());
         }

         public void ClientMethod(IAbstractWatchFactory abstractWatch)
         {
             var watch17 = abstractWatch.CreateEWatch2017();
             var watch19 = abstractWatch.CreateEWatch2019();
             watch17.Usefull();
             watch19.Usefull();

         }
    }
}