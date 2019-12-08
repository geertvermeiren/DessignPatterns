using System;
using System.Collections.Generic;
using System.Reflection;

namespace LogisticsFacade
{
    //facade
    public class Facade
    {
        Storage _storage;
        Picking _picking;
        public Facade(Storage storage,Picking picking)
        {
            this._picking= picking;
            this._storage = storage;
        }

        public string Operate()
        {  
         string result = "Storage Operations:";
           result += _storage.Operation1();
           result += _storage.Operation2();
           result += _storage.Operation3();
           result += "Picking operations:";
           result += _picking.Operation1();
           result += _picking.Operation2();
           return result;
        }
    }



    //multicomplex sy
     public class Storage
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

      public class Picking
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
             Storage s = new Storage();
             Picking p = new Picking();
             Facade fc = new Facade(s,p);
             System.Console.WriteLine( fc.Operate());
         
         }
    }
}