using System;
using System.Collections.Generic;

// notification

namespace StockObserver
{

    //subject

    public abstract class Stock
    {
        public int _price { get; set; }
        private List<IInvestor> _investor = new List<IInvestor>();

        public Stock(int price)
        {
            this._price = price;          

        }

        public void Attach(IInvestor investor)
        {
            _investor.Add(investor);

        }
        public void Detach(IInvestor investor)
        {
            _investor.Remove(investor);

        }

        public void Notify()
        {
            foreach(var item in _investor)
            {
                item.Update(this);
            }
        }

        public int Price
        {
            get{return _price;}
            set
            {
                if(_price != value)
                {
                    _price = value;
                    Notify();
                }
            }

        }


   
    }
    //concrete subject
    public class Microsoft:Stock
    {
        public Microsoft(int price):base(price){}
    }
    //observer
    public interface IInvestor
    {
        void Update(Stock stock);

    }
    //concreteobserver 
    public class Investor:IInvestor
    {
     //   private Stock _stock;
        readonly int _treshold ; 
        public string Name { get; set; }

        public Investor(string name,int treshold)
        {
            this.Name = name;
            this._treshold = treshold;

        }

        public void Update(Stock stock)
        {
            System.Console.WriteLine("kan ik dit zien ");
         
            System.Console.WriteLine($"the stock price {stock.GetType().Name} has reachtreshold to {stock._price}");
        }

    }
    //Client
    public class Client
    {
        public Client()
        {
            Microsoft ms = new Microsoft(100);
            ms.Attach(new Investor("geert", 150));
            ms.Attach(new Investor("gael", 103));
            ms.Attach(new Investor("patrizia", 88));

            ms.Price = 200;
            ms.Price =100;
            ms.Price = 50;
            ms.Price = 500;
  


    

        }
    }

}
