using System;
using System.Collections.Generic;

namespace ComputerFactory
{
    //creator

    public abstract class Creator
    {
        public abstract IComputer Create();     

    }

    //concrete creator

    public class DesktopCreator:Creator
    {
        public override IComputer Create()
        {
            return new Desktop();
        }
    }



    //product interface
    public interface IComputer
    {
         string Operate ();
    }

    //concrete product
     public class Desktop:IComputer    
     {
          public string Operate()
          {
              return "this is a desktop";
          }    
     
    }
    //client class
    public class Client
    {
         public Client()
         {
          ClientMethod(new DesktopCreator());
         }

         public void ClientMethod(Creator creator)
         {
             System.Console.WriteLine($"{ creator.Create().Operate()}");         

         }
    }
}