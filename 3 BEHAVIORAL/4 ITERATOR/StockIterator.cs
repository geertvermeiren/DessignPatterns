using System;
using System.Collections.Generic;

namespace StockIterator
{

    //iterator
    public class StockArray
    {
        private List<StockListing> stockList = new List<StockListing>();

        public int Add(string ticker,string name)
        {
            stockList.Add(new StockListing(ticker,name));
            return stockList.Count;
        }


        public int Add(StockListing stockListing)
        {
            stockList.Add(stockListing);
            return stockList.Count;
        }

        public StockListing GetItem(int index)
        {
            if(index < stockList.Count)
            {
               return stockList[index];
            }else
            {
                return null;
            }

        }

        public List<StockListing> GetItems()
        {
            return stockList;
        }

        public bool RemoveItem(int index)
        {
            if(index < stockList.Count){
            stockList.RemoveAt(index);
                return true;
            }else
            {
                return false;
            }
        }
    }

    //concrete itertor

    //aggregate

    //concrete aggregate

    public class StockListing
    {
    public string Ticker;
    public string Name;

    public StockListing(string ticker,string name)
    {
        this.Ticker= ticker;
        this.Name = name;
    }

    public override string ToString()
    {
        string mystring = $"{Ticker}  {Name}";
        return mystring; 
    }
    }

    public class Client
    {
        public Client()
        {
           StockArray stock = new StockArray();
           stock.Add(new StockListing("yaho", "yahoo inc"));
           stock.Add(new StockListing("msft", "microsoft inc"));
           stock.Add(new StockListing("goog", "Alphabeth inc"));
           stock.Add(new StockListing("aapl", "Apple inc"));

           System.Console.WriteLine("** GET ITEM ***");
          System.Console.WriteLine(stock.GetItem(2));

          System.Console.WriteLine(" ***Get items ** ");


           var items = stock.GetItems();
           foreach(var item in items)
           {
               System.Console.WriteLine(item);
           }

           stock.RemoveItem(3);

           System.Console.WriteLine("**remove item*** ");

           foreach(var item in items)
           {
               System.Console.WriteLine(item);
           }

        }
    }

}
