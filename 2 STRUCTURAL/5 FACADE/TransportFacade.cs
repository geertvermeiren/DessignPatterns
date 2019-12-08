using System;
using System.Collections.Generic;
using System.Reflection;

namespace TransportFacade
{
    //facade
    public class Facade
    {
        Transport _transport;
        Loading _loading;

        public Facade(Transport transport,Loading loading)
        {
            this._loading = loading;
            this._transport = transport;
        }

        
        public void Operate()
        {
            Message();
            string result = "OPERATIONS:";
            result+= _loading.Operation1();
            result+= _loading.Operation2();
            result += _transport.Operation1();
            result += _transport.Operation2();
            result += _transport.Operation3();
            result += _transport.Operation4();

            System.Console.WriteLine(result);

        }

        public void Message()
        {
            System.Console.WriteLine("message regarding packging and transportation;");
        }
    }

    public class CopyFacade:Facade
        {
            public CopyFacade(Transport transport, Loading loading):base(transport, loading )
            {

            }

        }

    

    //multiple compolex sytems

    public class Transport
    {
        public string Operation1()
        {
            return $" {this.GetType().Name}  {MethodBase.GetCurrentMethod().Name}";
        }
         public string Operation2()
        {
            return $" {this.GetType().Name}  {MethodBase.GetCurrentMethod().Name}";
        }
        public string Operation3()
        {
            return $" {this.GetType().Name}  {MethodBase.GetCurrentMethod().Name}";
        }
        public string Operation4()
        {
            return $" {this.GetType().Name}  {MethodBase.GetCurrentMethod().Name}";
        }    
    }
     public class Loading
    {
        public string Operation1()
        {
            return $" {this.GetType().Name}  {MethodBase.GetCurrentMethod().Name}";
        }
         public string Operation2()
        {
            return $" {this.GetType().Name}  {MethodBase.GetCurrentMethod().Name}";
        }
     
     
     
    }
    //client class
    public class Client
    {
         public Client()
         {
             Transport _transport = new Transport();
             Loading _loading = new Loading();
           //  Facade _facade = new Facade(_transport,_loading);

            CopyFacade cf = new CopyFacade(_transport,_loading);
            cf.Operate();

         
         }
    }
}