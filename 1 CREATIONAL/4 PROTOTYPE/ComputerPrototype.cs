using System;
using System.Collections.Generic;

namespace ComputerPrototype
{
     public class Computer
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Computer ShallowCopy()
        {
            return (Computer)this.MemberwiseClone();
        }
        public Computer DeepCopy()
        {   
            Computer clone = (Computer)this.MemberwiseClone();
            clone.Name = string.Copy(Name);         
            
            clone.Id = Id;         
            return clone;
        }
     
     
    }
    //client class
    public class Client
    {
         public Client()
         {
             Computer c = new Computer();
             c.Id = 1;
             c.Name = "test";
             var copy =  c.ShallowCopy();
             System.Console.WriteLine( $"shallow: {copy.Id}  {copy.Name} ");
             var dc = c.DeepCopy();
             System.Console.WriteLine($"deep: {dc.Name} {dc.Id}");

         }
    }
}