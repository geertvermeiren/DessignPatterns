using System;
using System.Collections.Generic;

namespace LaundromatFactor
{
 //creator

    public abstract class LaundromatCreator
    {
        public abstract ILaundromat Create(int quantity);
    }

 //concretecreator;creator

    public class WachingMachineCreator: LaundromatCreator
    {
        public override ILaundromat Create(int quantity)
        {
            return new WachingMachine(quantity);
        }

    }

 //iproduct
    public interface ILaundromat
    {
        void Operate();
    }

 //concreteproduct:iproduct

    public class WachingMachine: ILaundromat
    {
        private readonly int _quantity; 

        public WachingMachine(int quantity)
        {
            this._quantity = quantity;

        }

        public void Operate()
        {
            System.Console.WriteLine( _quantity + " waching machines are being created");
        }
    }

 //client

     public enum Actions
     {
         WachingMachine
     }

     public class Laundromat
     {
         // define dictionray<>
         private readonly Dictionary<Actions,LaundromatCreator> _factories;
        //define method wich executes dictionray

        public ILaundromat Execute(Actions actions, int quantity)
        {
            return _factories[actions].Create(quantity);
        }
         //constructor 
         public Laundromat()
         {
         _factories = new Dictionary<Actions,LaundromatCreator>();
         _factories.Add(Actions.WachingMachine,new WachingMachineCreator());
         }

     }

 //runclient

 // 6rde keer kijken.. 
}

