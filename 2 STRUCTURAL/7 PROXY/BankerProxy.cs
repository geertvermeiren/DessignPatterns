using System;
using System.Collections.Generic;

namespace BankerProxy
{
    //subject
    public interface ICustomer
    {
         void AskLoan (int amount);
        int GetLoan();
    }
    //real subject
    public class Customer:ICustomer
    {
        private int _amount;

        public void AskLoan(int amount)
        {
            this._amount = amount;  
        }

        public int GetLoan()
        {
            return _amount;
        }

    }


    //proxy 
     public class Banker:ICustomer
    {

         private int _amount;

        public void AskLoan(int amount)
        {
            this._amount = amount;  
        }

        public int GetLoan()
        {
            return _amount;
        }
        
        
     
     
     
    }
    //client class
    public class Client
    {
         public Client()
         {
             Banker banker = new Banker();
             banker.AskLoan(1000);
             System.Console.WriteLine( banker.GetLoan());
         
         }
    }
}