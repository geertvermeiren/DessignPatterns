using System;
using System.Collections.Generic;

namespace CoffeeFactory
{

    //creator
   public abstract class CoffeeCreator
   {
       public abstract ICoffeeBar Create(int quantity);
   }

    //concretecreator

    public class CapucinoCreator: CoffeeCreator
    {
        public override ICoffeeBar Create(int quantity)
        {
          return new Capucino(quantity);
        }
    }

    public class ExpressoCreator:CoffeeCreator
    {
        public override ICoffeeBar Create(int quantity)
        {
            return new Expresso(quantity);
        }
    }

    //interface

    public interface ICoffeeBar
    {
        void Operate();
    }

    //concreteProduct

    public class Capucino:ICoffeeBar
    {
        private readonly int _quantity;
        public Capucino(int quantity)
        {
            this._quantity = quantity;
        }

        public void Operate()
        {
            System.Console.WriteLine(_quantity + "capucinos are being prepared");
        }
    }

    public class Expresso:ICoffeeBar
    {
        private readonly int _quantity;

        public Expresso(int quantity)
        {
            this._quantity = quantity;
        }

        public void Operate()
        {
            System.Console.WriteLine(_quantity + " expressos are being prepared");
        }
    }
    
    //client

    public enum Actions
    {
        Capucino,
        Expresso
    }

    public class CoffeeBar
    {
        private readonly Dictionary<Actions,CoffeeCreator>_factories = new Dictionary<Actions,CoffeeCreator>();

        public ICoffeeBar ExecuteCreation(Actions action,int quantity)
        {
            return _factories[action].Create(quantity);
        }
        public CoffeeBar()
        {
            _factories.Add(Actions.Capucino, new CapucinoCreator());
            _factories.Add(Actions.Expresso, new ExpressoCreator());

        }


    }



}