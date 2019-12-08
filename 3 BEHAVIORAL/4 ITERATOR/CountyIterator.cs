using System;
using System.Collections.Generic;

namespace CountryIterator
{
    //iterator 

    public interface Iiterator
    {
        int Add(string name);

        int Add(Agregator agregator );

        Agregator GetItem(int index);

       List<Agregator> GetItems();     

        
    }
    
    //concrete iterator
    public class CountryIterator:Iiterator
    {
        private List<Agregator> countryList = new List<Agregator>();

        public int Add(string name)
        {
            countryList.Add(new Agregator(name));
            return countryList.Count;

        }
        public int Add(Agregator agregator)
        {
            countryList.Add(agregator);
            return countryList.Count;
        }

        public List<Agregator> GetItems()
        {
            return  countryList;
        }

        public Agregator GetItem(int index)
        {
            return countryList[index];
        
        }

        

    }
    //aggregator
    
    public interface IAgregator
    {

    }
    //concrete aggregator

    public class Agregator
    {
        public string _name;

        public Agregator(string name)
        {
            this._name = name;
        }

    }

    //client
    public class Client
    {
        public Client()
        {
            CountryIterator countries = new CountryIterator();
            countries.Add("Belgium");
            countries.Add("Brazil");
            countries.Add("Bosnia");
            countries.Add("finland");
            countries.Add("portugal");
            countries.Add("usa");
            System.Console.WriteLine("**GET ITEM* ***");
            System.Console.WriteLine(countries.GetItem(3));
            System.Console.WriteLine("***GET COUNTRIES");

           var items = countries.GetItems();
           foreach(var item in items){

                 System.Console.WriteLine(item._name);
           }         


        }
    }
}
