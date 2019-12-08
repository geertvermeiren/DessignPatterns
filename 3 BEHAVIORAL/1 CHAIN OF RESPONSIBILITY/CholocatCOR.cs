using System;
using System.Collections.Generic;

namespace CholocatCOR
{
    //handler
    public interface IHandler
    {
         IHandler SetNext (IHandler handler);

         object Handle(object request);
    }

    //abstract handler

    public abstract class AbstractHandler:IHandler
    {
        private IHandler _handler;
        public IHandler SetNext(IHandler handler)
        {
            this._handler = handler;
            return _handler;

        }

        public virtual object Handle(object request)
        {
            if(this._handler != null)
            {
                return this._handler.Handle(request);
            }else
            {
                return null;
            }

        }
    }


    //concrete handler 

    public class Cacao:AbstractHandler
    {
        public override object Handle(object request)
        {
            if((request as string) == this.GetType().Name)
            {
                return request.ToString();

            }else
            {
                return null;
            }
        }
       
    }

     public class Sugar:AbstractHandler
    {
      public override object Handle(object request)
      {
          if((request as string)== this.GetType().Name)
          {
              return request.ToString();
          }else
          {
              return null;
          }
      }    
     
    }

    public class Mix:AbstractHandler
    {
        public override object Handle(object request)
        {
            if((request as string) == this.GetType().Name)
            {
                return request.ToString();
            }else
            {
                return null;
            }
        }
    }
    //client class
    public class Client
    {
         public Client()
         {
             var cacao = new Cacao();
             var sugar  = new Sugar();
             var mix = new Mix();

             System.Console.WriteLine("PRODUCTION");
             ClientCode(cacao);
         
         }
         public static void ClientCode(AbstractHandler handler)
         {
             foreach(var item in new List<string>{"Cacao","Sugar","Mix"})
             {
                 System.Console.WriteLine($"PRODUCING {item}");
                 var result = handler.Handle(item);

                 if(result != null)
                 {
                     System.Console.WriteLine(result);
                 }else
                 {
                     System.Console.WriteLine($"{item} was not produced");
                 }
             }
         }



    }
}