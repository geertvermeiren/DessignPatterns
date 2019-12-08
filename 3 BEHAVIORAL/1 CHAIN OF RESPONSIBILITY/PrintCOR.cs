using System;
using System.Collections.Generic;

namespace PrintCOR
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

        public IHandler SetNext(IHandler nextHandler)
        {
            this._handler = nextHandler;
            return nextHandler;
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
     public class Paper:AbstractHandler
    {
        public override object Handle(object request)
        {
            if((request as string)== "paper")
            {
                return $"test  :{request.ToString()}";
            }else
            {
                return base.Handle(request);
            }
        }          
    }

    public class Inkt:AbstractHandler
    {
        public override object Handle(object request)
        {
           if((request as string)== "inkt")
            {
                return $"test  :{request.ToString()}";
            }else
            {
                return base.Handle(request);
            }
        }
    }

    public class WaitRowEmpty:AbstractHandler
    {
        public override object Handle(object request)
        {
            if((request as string) == "empty")
            {
                return $"test: {request.ToString()}";
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
             var paper = new Paper();
             var inkt = new Inkt();
             var waitRow = new WaitRowEmpty();
             
             paper.SetNext(inkt).SetNext(waitRow);

            ClientCode(paper);
         
         }

         public static void ClientCode(AbstractHandler handler)
         {
             foreach(var item in new List<string>{"paper","inkt", "empty"})
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