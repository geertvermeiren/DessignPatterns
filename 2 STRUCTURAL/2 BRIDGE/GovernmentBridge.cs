using System;
using System.Collections.Generic;

namespace GovernmentBridge
{
    //abstraction

    public abstract class Politics
    {
        public abstract void Popular();
        public abstract void UnPopular();
    }
       

    //refined abstraction

    public class Governement:Politics
    {
        IPopulation _population;

        public Governement(IPopulation population)
        {
          this._population = population;  

        }
        public override void Popular()     
        {
            this._population.SetPopularity(this._population.GetPopularity()+ 10);            
        }
        public override void UnPopular()     
        {
            this._population.SetPopularity(this._population.GetPopularity()-10);            
        }

        public void GetPopularity()
        {
            System.Console.WriteLine(this._population.GetPopularity());
        }

    }


    //interface

    public interface IPopulation
    {
         int GetPopularity ();
         void SetPopularity (int precent);
    }

    //concrete interface

    public class Voters:IPopulation
    {
        int _percent = 0;

        public int GetPopularity()
        {
            return _percent;

        }

        public void SetPopularity(int precent)
        {
            this._percent= precent;
        }

    }
   
    //client class
    public class Client
    {
         public Client()
         {
             Governement gov = new Governement(new Voters());
             gov.Popular();
             gov.Popular();
             gov.Popular();
             gov.Popular();
             gov.Popular();
             gov.Popular();
             gov.GetPopularity();
             gov.UnPopular();
             gov.UnPopular();
             System.Console.WriteLine(DateTime.Now);
             System.Console.WriteLine("VOTING:");
             gov.GetPopularity();
         
         }
    }
}