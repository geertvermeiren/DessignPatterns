using System;
using System.Collections.Generic;

namespace HoldingComposite
{
    //component
    public abstract class HoldingMember
    {
        protected string _name;
        protected int _bookValue;

         public HoldingMember(string name,int bookValue)
         {
             this._name = name;
             this._bookValue = bookValue;            
         }

        public abstract int TotalValue();
    }
    //operations

    public interface IOperations
    {
         void Add (HoldingMember holdingMember);
         void Remove (HoldingMember holdingMember);
    }

    //composite
     public class HoldingStructure:HoldingMember,IOperations
     {
         public List<HoldingMember> _holding;
         public HoldingStructure(string name,int bookValue):base(name,bookValue)
         {
           this._holding = new List<HoldingMember>();
         }

         public void Add(HoldingMember holdingMember)
         {
             this._holding.Add(holdingMember);
         }
         public void Remove(HoldingMember holdingMember)
         {
             this._holding.Remove(holdingMember);
         }

         public override int TotalValue()
         {
             int _total = 0;
             foreach(var item in _holding)
             {
                 _total += item.TotalValue();
                 
             }

             return _total;
         }        
     
     
    }

    //leaf
    public class SingleMember:HoldingMember
    {
        public SingleMember(string name,int bookValue):base(name,bookValue)
        {

        }

        public override int TotalValue()
        {
            return _bookValue;
        }
    }

    //client class
    public class Client
    {
         public Client()
         {
             SingleMember fin = new SingleMember("finaland",300);
             SingleMember ger = new SingleMember("germany",800);
             SingleMember fra = new SingleMember("france",700);
             SingleMember be= new SingleMember("belgium",500);
             HoldingStructure hs = new HoldingStructure("navision",0);
             hs.Add(fin);
             hs.Add(ger);
             hs.Add(fra);
             hs.Add(be);
             System.Console.WriteLine($"total group value:  {hs.TotalValue()} billion usd");
         
         }
    }
}