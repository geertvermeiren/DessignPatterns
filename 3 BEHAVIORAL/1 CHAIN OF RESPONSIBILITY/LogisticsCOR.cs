using System;
using System.Collections.Generic;

namespace LogisticsCOR
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
        IHandler _handler;
        public IHandler SetNext(IHandler handler)
        {
            this._handler = handler;
            return handler;          
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
     public class Pick:AbstractHandler
    {

        
        public override object Handle(object request)
        {
            if((request as string)== "pick")
            {
                return $" {request.ToString()}";
            }else
            {
                return base.Handle(request);
            }

        }      
     
    }

    public class Pack:AbstractHandler
    {
        
        public override object Handle(object request)
        {
            if((request as string) == "pack")
            {
                return  $" {request.ToString()}";
            }else
            {
                return base.Handle(request);
            }
        }
    }

    public class Transport:AbstractHandler
    {
       public override object Handle(object request)
        {
            if((request as string) == "transport")
            {
                return $" {request.ToString()}";
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
             var pick = new Pick();
             var pack = new Pack();
             var transport = new Transport();

             pick.SetNext(pack).SetNext(transport);

             System.Console.WriteLine("logistics:");
            ClientCode(pick);
         }

         public static void ClientCode(AbstractHandler handler)
         {
             foreach(var item in new List<string>{"pick", "pack", "transport"})
             {
                 System.Console.WriteLine($"test: {item}");
                 var result = handler.Handle(item);
                    if(result != null)
                    {
                        System.Console.WriteLine(result);
                    }else
                    {
                        System.Console.WriteLine($"we could not : {item}");
                    }

             }


         }
    }
}