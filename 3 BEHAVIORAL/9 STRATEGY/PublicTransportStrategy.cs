using System;

/*DEFINE A FAMILY OF ALGORITMS THAT MAKES THEM INTERCHANGEABLE (CAN BE APPLIED ANYWEHRE) 
BY ENCAPSULATINTHEN IN A CLASS - AS AN OBJECT. THE ACTUAL OPERATION CAN VARY */

namespace PubicTransportStrategy{

public abstract class PublicTransportStrategy
{
    public abstract void TransportCost(int cost);
}

//concrete strategy

public class Train:PublicTransportStrategy
{
    public override void TransportCost(int cost)
    {
        System.Console.WriteLine($"the cost of {this.GetType().Name} as a means of public transport amount to {cost} Euros.");
    }
}

public class Bus:PublicTransportStrategy
{
    public override void TransportCost(int cost)
    {
        System.Console.WriteLine($"the cost of {this.GetType().Name} as a means of public transport amount to {cost} Euros.");
    }

}

public class AutomaticDrivingVehicle:PublicTransportStrategy
{
    public override void TransportCost(int cost)
    {
        System.Console.WriteLine($"the cost of {this.GetType().Name} as a means of public transport amount to {cost} Euros.");
    }

}

//context

public class PublicTransportationBudget
{
   public PublicTransportStrategy _publicTransportStrategy ;
   private int _budget;

   public void SetTransportStrategy(PublicTransportStrategy publicTransportStrategy)
   {
       this._publicTransportStrategy = publicTransportStrategy;
   }

   public void SetBudget(int budget)
   {
       this._budget = budget;
   }

   public void Simulate()
   {
       _publicTransportStrategy.TransportCost(_budget);

   }
}
//clientaccess

    public class Client
    {
        public Client()
        {
            PublicTransportationBudget _publicTransportationBudget = new PublicTransportationBudget();
            _publicTransportationBudget.SetBudget(50000);
            System.Console.WriteLine("what transport strategy will you choose 1 - 3");
            _publicTransportationBudget.SetTransportStrategy(new Train());
            _publicTransportationBudget.Simulate();        
        
        }
    }
} 




