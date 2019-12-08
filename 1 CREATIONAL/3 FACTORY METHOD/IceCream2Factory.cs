using System;
using System.Collections.Generic;

namespace IceCreamFactor2
{
    //creator
    public abstract class IceCreamCreator
    {
        public abstract IIceCream Create(int quantity);

    }

    //concrete creator

    public class IceCreamFactory:IceCreamCreator
    {
        public override IIceCream Create(int quantity)
        {
            return new StrawBerryIcecream(quantity);
        }
    }

    //interface

    public interface IIceCream
    {
        void Operate();
    }

    //concrete product

    public class Production
    {
        public Production(int quantity)
        {
             System.Console.WriteLine(quantity + this.GetType().Name + " are being produced");
        }

    }

    public class StrawBerryIcecream:IIceCream
    {
     readonly int _quantity;

        public StrawBerryIcecream(int quantity)
        {
            _quantity = quantity;

        }
        public void Operate()
        {
           
        }
    }

    //client

    public enum Actions{StrawBerryIcecream}

    public class IceCreamClient
    {
        private readonly Dictionary<Actions,IceCreamFactory> _factories = new Dictionary<Actions,IceCreamFactory>();

        public IIceCream ExecuteCreate(Actions action,int quantity)
        {
            return _factories[action].Create(quantity);
        }

        public IceCreamClient()
        {
            _factories.Add(Actions.StrawBerryIcecream,new IceCreamFactory());
        }

    }

    //accessclient

    public class AccessClient
    {
        public AccessClient()
        {
         var factory = new IceCreamClient().ExecuteCreate(Actions.StrawBerryIcecream,15);
            
        }
    }


}