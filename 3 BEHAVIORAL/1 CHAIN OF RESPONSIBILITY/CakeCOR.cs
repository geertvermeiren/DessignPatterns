using System;
using System.Collections.Generic;

namespace CakeCOR
{

    //handler
    public interface IHandler
    {
         IHandler SetNext (IHandler handler);
         object Handle(object request);
    }

    //abstract handler

    public abstract class AbstractHandler: IHandler
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
     public class Flour:AbstractHandler
    {
         public override object Handle(object request)
         {
              if((request as string) == "flour")
              {
                   return request.ToString();

              }else
              {
                   return base.Handle(request);
              }
         }
     }

     public class Milk:AbstractHandler
     {
          public override object Handle(object request)
          {
               if((request as string)== "milk")
               {
                    return request.ToString();
               }
               else
               {
                    return base.Handle(request);
               }
          }
     }

     public class Mixer:AbstractHandler
     {
          public override object Handle(object request)
          {
               if((request as string )== "mixer")
               {

                    return request.ToString();
               }else
               {
                    return base.Handle(request);
               }
          }
     }

     public class Bake:AbstractHandler
     {
          public override object Handle(object request)
          {
               if((request as string)== "mixer")
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
              
              var flour = new Flour();
              var milk = new Milk();
              var mixer = new Mixer();
              var bake = new Bake();

              flour.SetNext(milk).SetNext(mixer).SetNext(bake).SetNext(bake);

              ClientCode(flour);
         
         }
         public void ClientCode(AbstractHandler handler)
         {
              foreach(var item in new List<string>{"flour","milk","mixer","bake"})
              {
                   System.Console.WriteLine($"testing: {item}");
                   var result = handler.Handle(item);
                   if(result != null)
                   {
                        System.Console.WriteLine(result);

                   }else
                   {
                    System.Console.WriteLine("not found");
                   }

              }
         }
    }
}