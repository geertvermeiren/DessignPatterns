using System;
using System.Collections.Generic;

namespace CarIterator
{
    //iterator

    public interface IIterator
    {
      int Add(string name);

      int Add(Aggregate aggregate);

      List<Aggregate> GetItems();

      Aggregate GetItem(int index);
        
    }

    //concrete iterator
    public class Iterator:IIterator
    {
      private readonly List<Aggregate> carList = new List<Aggregate>();

      public int Add(string name)
      {
        carList.Add(new Aggregate(name));
        return carList.Count;

      }

      public int Add(Aggregate aggregate)
      {
        carList.Add(aggregate);
        return carList.Count;

      }

      public List<Aggregate> GetItems()
      {
        return carList;
      }

      public Aggregate GetItem(int index)
      {
        return carList[index];
      }

    }

    //aggregate
    
    //concreteaggregate
    public class Aggregate
    {
      public string _name;

      public Aggregate(string name)
      {
        this._name = name;
      }
        
    }
  public class Client
  {
       public Client()
       {
         Iterator carlist = new Iterator();
         carlist.Add(new Aggregate("audi"));
         carlist.Add(new Aggregate("mercedes"));
         carlist.Add(new Aggregate("bmw"));
         carlist.Add(new Aggregate("tesla"));
         
         System.Console.WriteLine("**getitem**");
         System.Console.WriteLine(carlist.GetItem(3)._name);

         System.Console.WriteLine("***getitems**");
         var items = carlist.GetItems();
         foreach(var item in items)
         System.Console.WriteLine(item._name);

  
      }
  }
}
