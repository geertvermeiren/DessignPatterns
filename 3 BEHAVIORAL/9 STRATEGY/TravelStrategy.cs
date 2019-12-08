using System;

/*strategy pattern places strategies in seperate opbject as such can be applied on input */

namespace TravelStrategy
{
    //strategy
    public abstract class TravelStrategy
    {
        public abstract void Travel(int price);
    }

    //concreteStrategy
    public class OrganizedTravel:TravelStrategy
    {
        public override void Travel(int price)
        {
            System.Console.WriteLine($"the cost of {this.GetType().Name} is {price}");
        }

    }

    public class DIY:TravelStrategy
    {
        public override void Travel(int price)
        {
            System.Console.WriteLine($"the cost of {this.GetType().Name} is {price}");
        }
        
    }


    //context
    
    public class OrganizeTravel
    {
        private TravelStrategy _travelStrategy ;
        public int _cost;

        public void SetTravelStrategy(TravelStrategy travelStrategy)
        {
            this._travelStrategy = travelStrategy;
        }

        public void SetTravelCost(int cost)
        {
            this._cost = cost;
        }

        public void Travel()
        {
            _travelStrategy.Travel(_cost);

        }
    }

    //accessclient
    public class Client
    {
        public Client()
        {
            OrganizeTravel _organizeTravel = new OrganizeTravel();
            _organizeTravel.SetTravelCost(5000);
            System.Console.WriteLine("What is travel strategy will you choose ?");
            _organizeTravel.SetTravelStrategy(new DIY());
            _organizeTravel.Travel();
        }
    }
}
