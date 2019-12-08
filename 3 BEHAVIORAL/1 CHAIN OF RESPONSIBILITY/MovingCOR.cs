using System;
using System.Collections.Generic;

namespace MovingCOR
{
    //handle
    public interface IHandle
    {
         IHandle SetNext (IHandle handler);
         object Handle (object request);
    }
    //abstract handel

    public abstract class AbstractHandle:IHandle
    {
       private IHandle _handle ;

       public IHandle SetNext(IHandle handle)
       {
           this._handle = handle;
           return _handle;
       }   
        
       public virtual object Handle(object request)
       {
           if(this._handle != null)
           {
               return request.ToString();
           }else
           {
               return null;
           }
       } 
    }

    // concrete handle
     public class Pack:AbstractHandle
    {     
        public override object Handle(object request)
        {
            if((request as string) == "pack")
            {
                return request.ToString();
            }else
            {
                return base.Handle(request);
            }
        }
     
    }

    public class Transport:AbstractHandle
    {
        public override object Handle(object request)
        {
            if((request as string)== "transport")
            {
                return request.ToString();
            }else
            {
                return base.Handle(request);
            }
        }
    }

    public  class UnPack:AbstractHandle
    {
        public override object Handle(object request)
        {
            if((request as string) == "unpack")
            {
                return request.ToString();
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
             var pack = new Pack();
             var transport = new Transport();
             var unpack = new UnPack();

             pack.SetNext(transport).SetNext(unpack);

             ClientCode(pack);
         
         }

         public void ClientCode(AbstractHandle handler)
         {

             foreach(var item in new List<string>{"pack","transport", "unpack"} )
             {
                 System.Console.WriteLine("TEXING = " + item);
                 var result = handler.Handle(item);
                 if(result != null)
                 {
                     System.Console.WriteLine(result);
                 }else
                 {
                     System.Console.WriteLine($"{item}  not found");
                 }
             }


         }
    }
}