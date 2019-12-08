using System;
using System.Collections.Generic;

namespace EuComposite
{
    //component
     public abstract class EuMembers
     {
         protected string _name;
         protected int _population;

         public EuMembers(string name,int population)
         {
             this._name = name;
             this._population = population;
         }

         public abstract int TotalPopulation();
         

         

     }
    //operations

    public interface IOperations
    {
         void Add(EuMembers euMembers);
         void Remove(EuMembers euMembers);
    }

    //composite
    public class EU:EuMembers,IOperations
    {
        public List<EuMembers> _memberStates;

        public EU(string name, int population):base(name,population)
        {
            this._memberStates = new List<EuMembers>();
        }
        public void Add(EuMembers euMembers)
        {   
            this._memberStates.Add(euMembers);
        }

        public void Remove(EuMembers euMembers)
        {
            this._memberStates.Remove(euMembers);
        }

        public override int TotalPopulation()
        {
            int _total = 0;
            foreach(var item in _memberStates)
            {
                 _total += item.TotalPopulation();
            }
            return _total;
        }
    }

     public class SingleMember:EuMembers
    {
        public SingleMember(string name,int population):base(name,population)
        {

        }

        public override int TotalPopulation()
        {
            return _population;
        }
        
     
     
     
    }

    //leaf
    //client class
    public class Client
    {
         public Client()
         {
             SingleMember Bel = new SingleMember("belgium",10);
             SingleMember fr = new SingleMember("france",40);
             SingleMember ger = new SingleMember("germany",80);
             SingleMember hol = new SingleMember("holland",16);
             EU eu = new EU("european union",0);
             eu.Add(Bel);
             eu.Add(fr);
             eu.Add(ger);
             eu.Add(hol);
             System.Console.WriteLine(eu.TotalPopulation());

             

             
         
         }
    }
}