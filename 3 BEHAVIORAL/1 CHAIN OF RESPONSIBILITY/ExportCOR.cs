using System;
using System.Collections.Generic;

namespace ExportCOR
{
    //handler
    public interface IHandler
    {
         IHandler SetNext (IHandler handler);

         object Handle(object handle);
    }

    //abstract handler

    public abstract class AbstractHandler:IHandler
    {
        private IHandler _handler;

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
     public class  InvoiceNumber:AbstractHandler
    {
        
        public override object Handle(object request)
        {
            if((request as string) == "inv")
            {
                return $"test  :{request.ToString()}";
            }else
            {
                 return base.Handle(request);
            }
        }     
     
    }

     public class TaxesPaid:AbstractHandler
    {
        public override object Handle(object request)
        {
           if((request as string)== "tax")
            {
                return $"test  :{request.ToString()}";
            }else
            {
                return base.Handle(request);
            }
        }
    }


    
    public class License:AbstractHandler
    {
        public override object Handle(object request)
        {
            if((request as string) == "lic")
            {
                return $"test  :{request.ToString()}";
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
          var invoice = new InvoiceNumber();
          var tax = new TaxesPaid();
          var license = new License();
          invoice.SetNext(tax).SetNext(license);

          ClientCode(invoice);
         }

         public static void ClientCode(AbstractHandler handler)
         {

             
             foreach(var item in new List<string>{"inv","tax", "lic"})
             {
                 System.Console.WriteLine($" testing: {item}");

                 var result = handler.Handle(item);

                 if(result != null)
                 {
                     System.Console.WriteLine(result);
                 }else
                 {
                     System.Console.WriteLine($"{item} has not passed the test ");
                 }
             }
            
         }
    }
}