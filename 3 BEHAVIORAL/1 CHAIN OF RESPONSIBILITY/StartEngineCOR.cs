using System;
using System.Collections.Generic;

namespace StartEngineCOR
{
    //handle
    public interface IHandle
    {
         IHandle SetNext (IHandle handle);
         object Handle(object request);
    }

    //abstract handle
    public abstract class AbstractHandler:IHandle
    {
        IHandle _handle;

        public IHandle SetNext(IHandle handle)
        {
            this._handle = handle;
            return _handle;          
        }

        public virtual object Handle(object request)
        {
            if(this._handle.Handle(request) != null)
            {
                return request;
            }else
            {
                return null;
            }
        }
    }
    //concrete handle
     public class SwitchKey:AbstractHandler
    {
        public override object Handle(object request)
        {
            if((request as string) == "key")
            {
                return request;
            }else
            {
                return base.Handle(request);
            }
        }
     
     
     
    }

    public class Battery:AbstractHandler
    {
        public override object Handle(object request)
        {
            if((request as string) == "battery")
            {
                return request;
            }else
            {
                return base.Handle(request);
            }
        }
    }
    public class Engine:AbstractHandler
    {
        public override object Handle(object request)
        {
            if((request as string)== "engine")
            {
                return request;
            }else
            {
                return base.Handle(request);
            }
        }
    }
    //client class
    public class Client
    {
         public Client()
         {
             var key = new SwitchKey();
             var battery = new Battery();
             var engine = new Engine();

             key.SetNext(battery).SetNext(engine);

             ClientCode(key);
         
         }

         public static void ClientCode(AbstractHandler handler)
         {
             foreach(var item in new List<string>{"key","battery","engine"})
             {
                 System.Console.WriteLine($"testing: {item}");

                 var result = handler.Handle(item);

                 if(result != null)
                 {
                     System.Console.WriteLine($"{result} - OK");
                 }else
                 {
                     System.Console.WriteLine("niet gevonden");
                 }
             }
         }
    }
}