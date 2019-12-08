using System;
using System.Collections.Generic;

namespace DecisionsCOR
{
    //handle
    public interface IHandle
    {
         IHandle SetNext (IHandle handle);
         object Handle(object request);
    }

    //abstract handle
    public abstract class AbstractHandle:IHandle
    {
        IHandle _handle;
        public IHandle SetNext(IHandle handle)
        {
            this._handle= handle;
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


    //concrete handle
    public class Information:AbstractHandle
    {
        public override object Handle(object request)
        {
            if((request as string) == "information")
            {
                return request.ToString();
            }else
            {
                return base.Handle(request);
            }
        }  
         
    }
    public class Order:AbstractHandle
    {
        public override object Handle(object request)
        {
            if((request as string)== "order")
            {
                return request.ToString();
            }else
            {
                return base.Handle(request);
            }
        }
    }
    public class Analize:AbstractHandle
    {
        public override object Handle(object request)
        {
            if((request as string)=="analize")
            {
                return request.ToString();
            }else
            {
                return base.Handle(request);
            }
        }
    }

    public class Decide:AbstractHandle
    {
        public override object Handle(object request)
        {
            if((request as string)=="decide")
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
          var info = new Information();
          var order = new Order();
          var analize = new Analize();
          var deciscion = new Decide();
          info.SetNext(order).SetNext(analize).SetNext(deciscion);

          ClientCode(info);


         }

         public void ClientCode(AbstractHandle handle)
         {
             foreach(var item in new List<string>{"information","order","analize","decide"})
             {
                 System.Console.WriteLine($"testing {item}");
                 var result = handle.Handle(item);

                 if(result != null)
                 {
                     System.Console.WriteLine(result);
                 }else
                 {
                     System.Console.WriteLine($" this is not working: {item}");
                 }
             }
         }
    }
}