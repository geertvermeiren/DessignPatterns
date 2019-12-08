using System;
using System.Collections.Generic;

namespace Formule1Composite
{
    //component

    public abstract class F1Car
    {
        protected string _name;
        protected int _price;

        public F1Car(string name,int price)
        {
            this._name =name;
            this._price = price;
        }

        public abstract int TotalCost();       
           
        
    }

    public interface IOperations
    {
         void Add (F1Car f1Car);
         void Remove(F1Car f1Car);
    }
    //composite

    public class Formule1Composite:F1Car,IOperations
    {
        public List<F1Car> _f1car;
        public Formule1Composite(string name,int price):base(name,price)
        {

            this._f1car = new List<F1Car>();
        }

        public void Add(F1Car f1car)
        {
            this._f1car.Add(f1car);

        }
        public void Remove(F1Car f1Car)
        {
            this._f1car.Remove(f1Car);
        }

        public override int TotalCost()
        {
            int total = 0;
            foreach(var item in _f1car)
            {
                total += item.TotalCost();
            }
            return total;
        }


    }
    //leaf
   
     public class SingleCar:F1Car
    {
        public SingleCar(string name,int price):base(name,price)
        {

        }

        public override int TotalCost()
        {
            return _price;
        }


     
     
     
    }
    //client class
    public class Client
    {
         public Client()
         {
             SingleCar mer = new SingleCar("mercedes", 4000000);
             SingleCar fer = new SingleCar("ferari", 4000000);
             SingleCar wil = new SingleCar("williams", 1000000);
             SingleCar mc = new SingleCar("mclaren", 2000000);
             Formule1Composite f1 = new Formule1Composite("f1",0);

             f1.Add(mer);
             f1.Add(fer);
             f1.Add(wil);
             f1.Add(mc);
              System.Console.WriteLine(f1.TotalCost());
         
         }
    }
}