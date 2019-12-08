using System;
using System.Collections.Generic;

namespace CompanyComposite
{

    //component

    public abstract class CompanyLevel
    {
       protected string _rank;
       protected int _earnings;
       public CompanyLevel(string rank,int earnings)
       {
           this._rank = rank;
           this._earnings = earnings;
           
       }
 

       public abstract int TotalEarning();       

    } 

    public interface CompanyOperations
    {
        void Add(CompanyLevel company);

        void Remove(CompanyLevel company);
    }

  //composite
    public class CompanyComposite:CompanyLevel,CompanyOperations
    {
        public List<CompanyLevel> _company;

        public CompanyComposite(string rank, int earnings ):base(rank, earnings)
        {
            this._company = new List<CompanyLevel>();

        }

        public void Add(CompanyLevel company)
        {
            this._company.Add(company);
        }

        public void Remove(CompanyLevel company)
        {

        }

        public override int TotalEarning()
        {
            int TotalEarnings =0;

            foreach(var item in _company)
            {
                TotalEarnings += item.TotalEarning();

            }

            return TotalEarnings;
        }
    }


    //leaf
    public class Singlelevel:CompanyLevel
    {
        public Singlelevel(string rank,int earnings):base(rank,earnings)
        {
            
        }

        public override int TotalEarning()
        {
            return _earnings;
        }





    }

    //client
     public class name
    {
     
     
     
    }
    //client class
    public class Client
    {
         public Client()
         {

             var sl = new Singlelevel("ceo",10000);
             var sl2 = new Singlelevel("cio",8000);
             var company = new CompanyComposite("empacto",0);
             company.Add(sl);
             company.Add(sl2);
             System.Console.WriteLine("company payroll cost");
            System.Console.WriteLine( company.TotalEarning());
            System.Console.WriteLine("ceo cost");
            
            System.Console.WriteLine( sl.TotalEarning());
         
         }
    }
}