using System;
using System.Collections.Generic;

namespace IceCreamFactor
{
    public interface IIceCream
    {
        void Operate();
    };

    //concrete product 1

    public class StrawBerry:IIceCream
    {
        private readonly int _quantity;

        public StrawBerry(int quantity)
        {
            this._quantity = quantity;

        }

        public void Operate()
        {
    System.Console.WriteLine("strawberries are added now");
        }


    }
    //concreteproduct 2
    public class Banana:IIceCream
    {
        private readonly int _quantity;

        public Banana(int quantity)
        {
            this._quantity = quantity;

        }

        public void Operate()
        {
    System.Console.WriteLine("Bananas are added now");
        }
    }
    // creator 
    public abstract class IceCreamFactory
    {
        public abstract IIceCream Create(int quantity);
    }

    // concrete creator 1
     public class StrawBerryFactory:IceCreamFactory
     {

         public override IIceCream Create(int quantity)
         {
             return new StrawBerry(quantity);
         }

     }

     // concrete creator 2
     public class BananaFactory:IceCreamFactory
     {
         public override IIceCream Create(int quantity)
         {
             return new Banana(quantity);
         }
     }

     public enum Actions
     {
         Strawberry,
         Banana
     }

     public class IceCream
     {

         public IIceCream ExecuteCreation(Actions action,int quantity) => _factories[action].Create(quantity);

         private readonly Dictionary<Actions,IceCreamFactory> _factories;

         public IceCream()
         {
             _factories = new Dictionary<Actions,IceCreamFactory>();
             _factories.Add(Actions.Strawberry, new StrawBerryFactory());
             _factories.Add(Actions.Banana, new BananaFactory());
         }


          public void CreateIceCream(IceCreamFactory icecreamFactory)
         {
             System.Console.WriteLine("this is icecream");

         }
     }




}
