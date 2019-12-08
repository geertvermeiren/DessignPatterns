using System;
using System.Collections.Generic;

namespace PositiveAdapter
{
    //adaptee = class which need to be adapted = negative values
    //itarget = interfacde with functionalits ot access adaptee
    //adapter = implements itarget 

    //adaptee = original values
    public class NegativeAdaptee
    {
        public List<int> GetNegative()
        {
            List<int> _negatives = new List<int>();
            _negatives.Add(-5);
            _negatives.Add(-3);
            _negatives.Add(-10);
            _negatives.Add(-5);
            return _negatives;
        }
        
     
    }

    //itarget
    public interface ITarget
    {
         List<int> TransFormNetToPos();
    }

    public class Adapter
    {
        public List<int> TransFormNetToPos()
        {   
            NegativeAdaptee na = new NegativeAdaptee();

            List<int> _positives = new List<int>();
            foreach(var item in na.GetNegative())
            {  
              _positives.Add(Math.Abs(item));
            }
            return _positives;
        }
    }
    //client class
    public class Client
    {
         public Client()
         {
             Adapter ad = new Adapter();
             foreach(var item in ad.TransFormNetToPos())
             {
                 System.Console.WriteLine($"only {item}");
             }
         
         }
    }
}