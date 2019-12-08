using System;
using System.Collections.Generic;

namespace BikeFactor{

//creator

public abstract class BikeCreator
{
    public abstract IBike Create(int quantity);


}

//concrete creator

public class RaceBikeCreator:BikeCreator
{
    public override IBike Create(int quantity)
    {
        return new RaceBike(quantity);
    }
}

//iproduct

public interface IBike
{
    void Operate();
}

//concrete product: iproduct

public class RaceBike:IBike
{
    private readonly int _quantity;

    public RaceBike(int quantity)
    {
        _quantity = quantity;

    }
    public void Operate()
    {

        System.Console.WriteLine("constructing " + _quantity +  "race bikes");


    }
}
    public enum Actions
    {
        RaceBike
    }
    public class BikeFactory
    {
        private readonly Dictionary<Actions, BikeCreator> _factory;
        
        public IBike ExecuteCreation(Actions action, int quantity)
        {
            return _factory[action].Create(quantity);
        }

        public BikeFactory()
        {
            _factory = new Dictionary<Actions, BikeCreator>();
            _factory.Add(Actions.RaceBike,new RaceBikeCreator());
        }

    }

//client
//client call
        public class BikeClient
        {
         public BikeClient()
         {
             var c = new BikeFactory().ExecuteCreation(Actions.RaceBike,15);
             c.Operate();
         }

        }


}

