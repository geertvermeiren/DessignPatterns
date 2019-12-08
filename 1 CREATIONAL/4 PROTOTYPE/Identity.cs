using System;
using System.Collections.Generic;

namespace Identity
{
     public class Identity
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public Identity ShallowCopy()
        {
            return (Identity)this.MemberwiseClone();
        }
        public Identity DeepCopy()
        {
            Identity clone = (Identity)this.MemberwiseClone();
            clone.Id = Id;
            clone.Name = string.Copy(Name);
            return clone;
        }
     
     
     
    }
    //client class
    public class Client
    {
         public Client()
         {
             Identity _myId = new Identity();
             _myId.Name = "pat";
           var dc =  _myId.DeepCopy();
             System.Console.WriteLine(_myId.Name+ "   - deepcopy: " + dc.Name );
         
         }
    }
}