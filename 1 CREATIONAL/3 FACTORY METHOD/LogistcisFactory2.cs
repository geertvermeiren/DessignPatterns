using System;
using System.Collections.Generic;

namespace LogisticsFactor2
{
    //creator
    public abstract class Creator
    {
        public abstract ILogistics Create(int quantity);
    }
    //concrete creator

    public abstract class SeaLogisticsCreator:Creator
    {
        public override ILogistics Create(int quantity)
        {
            return new SeaLogistics(quantity);
        }
    }

    //interface 

    public interface ILogistics
    {
        void Operate();
    }

    //concrete product

    public class SeaLogistics:ILogistics
    {
        private readonly int _quantity; 

        public SeaLogistics(int quantity)
        {
            this._quantity = quantity;

        }

        public void Operate()
        {
            System.Console.WriteLine( _quantity + "ships sailing out");
        }
    }

    //client

    public enum Actions
    {
        SeaLogistics
    }

    public class Client
    {
        private readonly Dictionary<Actions,Creator> _factories;

        public ILogistics ExecuteCreate(Actions action,int quantity)
        {
            return _factories[action].Create(quantity);
        }

        public Client()
        {
            _factories = new Dictionary<Actions,Creator>();
          //  _factories.Add(Actions.SeaLogistics, new SeaLogistics() );
        }
    }

}
