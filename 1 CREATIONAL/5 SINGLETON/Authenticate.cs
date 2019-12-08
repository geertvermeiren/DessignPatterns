using System;

namespace Authenticate
{
    public class Authenticate
    {
        private static Authenticate _instance;
        private static Object _lock = new Object();

        private Authenticate(){}

        public static Authenticate GetInstance()
        {
            lock(_lock)
            {
                return _instance??(_instance = new Authenticate());
            }
        }

    }

    public class Client
    {
         public Client()
         {
             var geert = Authenticate.GetInstance();

             var patrizia = Authenticate.GetInstance();

             if(geert == patrizia)
             System.Console.WriteLine("we are the same");

        }
    }
}