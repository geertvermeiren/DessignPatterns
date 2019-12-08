using System;
using System.Collections.Generic;

namespace Aut
{
     public class Auth
    {
        private static Auth _AuthInstance;
        private static Object _lock = new Object();

        public int Id { get; set; }
        public string Name { get; set; }
       

        private Auth(){}

        public static Auth GetAuthInstance()
        {
            lock(_lock)
            {
                return _AuthInstance??(_AuthInstance = new Auth());
            }

        }
     
     
     
    }
    //client class
    public class Client
    {
         public Client()
         {
             var s1 = Auth.GetAuthInstance();
             var s2 = Auth.GetAuthInstance();
             s1.Name = "geert";

             System.Console.WriteLine($"name of s2 {s2.Name}");

          
         }
    }
}