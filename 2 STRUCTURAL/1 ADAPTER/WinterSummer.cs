using System;
using System.Collections.Generic;

namespace WinterSummer
{
     public class Adaptee
    {
        
         public List<string> GetWinters()
        {
         List<String> _winter = new List<string>();      
        _winter.Add("winter");
        _winter.Add("winter");
        _winter.Add("winter");
        _winter.Add("winter");
        _winter.Add("winter");
        return _winter;    
     
        
        }
    }

    // itarget

    public interface ITarget
    {
         List<string> TransformWinterToSummer ();
    }

    // adapter

    public class Adapter:ITarget
    {
        Adaptee _adaptee; 
        List<string> _summer ; 
        public Adapter(Adaptee adaptee)
        {
            this._adaptee = adaptee;
            this._summer = new List<string>();
        }
        public List<string> TransformWinterToSummer()
        {
            
             foreach(var item in _adaptee.GetWinters())
             {
                _summer.Add("summer");
             }

             return _summer;
        }
    }


    //client class
    public class Client
    {
         public Client()
         {
             Adapter _ad = new Adapter(new Adaptee());
            var _summer  = _ad.TransformWinterToSummer();
            foreach(var item in _summer)
            {
                System.Console.WriteLine(item);

            }

         
         }
    }
}