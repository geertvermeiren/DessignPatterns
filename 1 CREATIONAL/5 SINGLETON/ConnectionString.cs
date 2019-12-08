using System;
using System.Collections.Generic;

namespace ConnectionString
{
     public class Connection
    {
        private static Connection _conn;
        private static Object _lock = new Object();

        private Connection(){}

        public static Connection GetConnection()
        {
            lock(_lock)
            {
                return _conn??(_conn = new Connection());
            }
        }
     
        public string myConn { get; set; }
     
    }
    //client class
    public class Client
    {
         public Client()
         {
             var c1 = Connection.GetConnection();
             var c2 = Connection.GetConnection();
             c2.myConn = "x";
             if(c1.myConn == "x")
             System.Console.WriteLine("ok works fine");

             
         }
    }
}