using System;
using System.Collections.Generic;

namespace StateIterator
{
    //iterator
    public interface IIterator
    {
        void Add(string name);

        void Add(BrazilianState brazilianState);

        List<BrazilianState> GetItems();

        BrazilianState GetItem(int index);
    }
    //concrete iterator

    public class BrazilianStateIterator:IIterator
    {
        public List<BrazilianState> brazilianStateList = new List<BrazilianState>();

        public void Add(string name)
        {

            brazilianStateList.Add(new BrazilianState(name));

        }

        public void Add(BrazilianState brazilianState)
        {
            brazilianStateList.Add(brazilianState);
        }

        public List<BrazilianState> GetItems()
        {
            return brazilianStateList;
        }

        public BrazilianState GetItem(int index)
        {
            return brazilianStateList[index];
            
        }



    }

    //aggregate

    //concrete aggregate
    public class BrazilianState    
    {
        public string _name;
        public BrazilianState(string name)
        {
            _name = name;
        }


    }

    //client
    public class Client
    {
         public Client()
         {
             BrazilianStateIterator bsi = new BrazilianStateIterator();
             bsi.Add("pernambuco");
             bsi.Add("bahia");
             bsi.Add("ceara");
             bsi.Add("rio de janeiro");
             bsi.Add("victoria");

             var items = bsi.GetItems();
             foreach(var item in items)
             System.Console.WriteLine(item._name);

             System.Console.WriteLine("****get index***");

             System.Console.WriteLine(bsi.GetItem(4)._name);
    
        }
    }
}
