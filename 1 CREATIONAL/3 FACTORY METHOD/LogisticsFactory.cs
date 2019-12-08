using System.Collections.Generic;

namespace LogisticsFactor
{
    //creator

    public abstract class LogisticsCreator
    {
        public abstract ILogistics Create(int quantity);

    }

    //concreteCreator

    public class SeaLogisticsCreator: LogisticsCreator
    {
        public override ILogistics Create(int quantity)
        {
            return new SeaLogistics(quantity);

        }
    }

    public class RoadLogisticsCreator:LogisticsCreator
    {
        public override ILogistics Create(int quantity)
        {
            return new RoadLogistics(quantity);
        }
    }

    //interface

    public interface ILogistics
    {
        void Operate();
    }

    //concreteproduct

    public class SeaLogistics:ILogistics
    {
        private readonly int _quantity; 

        public SeaLogistics(int quantity)
        {
            this._quantity = quantity;

        }
        public void Operate()
        {
            System.Console.WriteLine(_quantity + " of ships are ");

        }
    }

    public class RoadLogistics:ILogistics
    {
        private readonly int _quantity; 

        public RoadLogistics(int quantity)
        {
            this._quantity = quantity;
        }

        public void Operate()
        {
            System.Console.WriteLine(_quantity + " trucks are leaving the factory");
        }
    }
    

    //client
    public enum Actions
    {
        sea,
        road
    }

    public class Logistics
    {
        private readonly Dictionary<Actions,LogisticsCreator> _factories = new Dictionary<Actions,LogisticsCreator>();
        public ILogistics ExecuteCreation(Actions action,int quantity)
        {
            return _factories[action].Create(quantity);
        }

        public Logistics()
        {
            _factories.Add(Actions.road,new RoadLogisticsCreator());
            _factories.Add(Actions.sea, new SeaLogisticsCreator());
        }
       

        
    }

}