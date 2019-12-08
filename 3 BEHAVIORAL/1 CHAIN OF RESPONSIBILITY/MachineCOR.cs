using System;
using System.Collections.Generic;

namespace MachineCOR
{

    //handler
    public interface IHandler
    {
         IHandler SetNext (IHandler handler);

         object Handle(object request);
    }
    //base  handeler = abstract handler

    public abstract class AbstractHandler:IHandler
    {
        private IHandler _nextHandler;

        public IHandler SetNext(IHandler nextHandler)
        {
            this._nextHandler = nextHandler;

            return _nextHandler;
        }

        public virtual object Handle(object request)
        {
                if(this._nextHandler != null)
                {
                    return this._nextHandler.Handle(request);
                }else
                {
                    return null;
                }

        }

      }

      public class MachineOne:AbstractHandler
      {
           public override object Handle(object request)
           {
                if((request as string )=="step 1")
                {
                     return $"this is : {request.ToString()}";
                }
                else
                {
                     return base.Handle(request);
                }
           }
      }

      public class MachineTwo:AbstractHandler
      {
           public override object Handle(object request)
           {
                if ((request as string)=="step 2")
                {
                     return $"this is : {request.ToString()}";
                }
                else
                {
                     return base.Handle(request);
                }
           }
      }

      public class MachineThree:AbstractHandler
      {
           public override object Handle(object request)
           {
                if((request as string) == "step 3")
                {
                     return $"this is : {request.ToString()}";
                }
                else
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
              var one = new MachineOne();
              var two = new MachineTwo();
              var three = new MachineThree();

              one.SetNext(two).SetNext(three);

              System.Console.WriteLine("RESULT:");
              ClientCode(one);
         
         }

         public static void ClientCode(AbstractHandler handler)
         {
              foreach(var item in new List<string>{"step 1", "step 2", "step 3"})
              {
                   System.Console.WriteLine($"client: what is done: {item}");

                    var result = handler.Handle(item);
                    
                    if(result != null)
                    {
                         System.Console.WriteLine($" {result}");
                    }
                    else
                    {
                         System.Console.WriteLine($"{item} did not work");
                    }
                    

              }
         }
    }
}