using System;
using System.Collections.Generic;

namespace PrefabFac
{

    //creator 
    public abstract class Creator
    {
        public abstract IFabric Create(int quantity);         
    }

    //concrete: creator

    public class House1Production:Creator
    {
        public override IFabric Create(int quantity)
        {
            return new  House1(quantity);
        }
    }

    //interface 

    public interface IFabric
    {
        void Operate();
    }

    //concrete product: interface

    public class House1: IFabric
    {
        private readonly int _quantity;

        public House1(int quantity)
        {
            this._quantity = quantity;
            
        }

        public void Operate()
        {
            System.Console.WriteLine(_quantity + "houses1 are being built");
        }
    }

    //client

     public enum Actions
     {
         House1
     }

     public class Prefab
     {
         private readonly Dictionary<Actions,House1Production> _factories;

         public IFabric Exectution(Actions action,int quantity)
         {

             return _factories[action].Create(quantity);

         }

         public Prefab()
         {
             _factories = new Dictionary<Actions,House1Production>();
             _factories.Add(Actions.House1,new House1Production());
         }



     }


}