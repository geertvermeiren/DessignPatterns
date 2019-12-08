using System;
using System.Collections.Generic;

namespace PoliticsDecorator
{
    //component
    public class Politician
    {
      public int Id { get; set; } 
      public string Name { get; set; }
    }
    public abstract class PoliticalParty
    {
       protected List<Politician> _politician = new List<Politician>
        { new Politician{Id=1, Name ="verhofstadt"},
         new Politician{Id=2, Name ="verhofstadt"},
         new Politician{Id=3, Name ="verhofstadt"},
         new Politician{Id=4, Name ="verhofstadt"}

        };

        // public PoliticalParty()
        // {
        //     List<Politician> _politician2 = new List<Politician>();
        //     _politician2.Add(new Politician(){Id=1,Name="geert"});
        //     _politician2.Add(new Politician(){Id=1,Name="patrizia"});
        //     _politician2.Add(new Politician(){Id=1,Name="g"});
        //     _politician2.Add(new Politician(){Id=1,Name="geert"});
        // }

        public abstract int PoliticiansCount();            

    }

    //concrete component   

     public class Government:PoliticalParty
    { 
      
        public override int PoliticiansCount()
        {
             return  _politician.Count;


        }
     
     
    }
    //decorator
        public class GovernmentDecorator: Government
        {
            Government _government;
            public GovernmentDecorator(Government governement)
            {
                this._government = governement;
            }

            public override int PoliticiansCount()
            {
               return this._government.PoliticiansCount();
            }
        }




    //concrete decorator

    public class Coalition:GovernmentDecorator
    {
        public Coalition(Government governement):base(governement)
        {

        }
        public override int PoliticiansCount()
        {
           return base.PoliticiansCount()+ 5;
        }
    }

    //client class
    public class Client
    {
         public Client()
         {
            Government _gov = new Government();
            Coalition coalition = new Coalition(_gov);
            System.Console.WriteLine( coalition.PoliticiansCount());
         
         }
    }
}