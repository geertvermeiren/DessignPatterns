using System.Collections.Generic;
using System;

namespace PastaFactor
{
    //creator

    public abstract class PastaCreator
    {
        public abstract IItalianCuisine Create(int quantity);

    }

    //concreteCreator

    public class SpagettiCreator:PastaCreator
    {
        public override IItalianCuisine Create(int quantity)
        {
            return new Spagetti(quantity);
        }

    }

    public class GnotchiCreator:PastaCreator
    {

        public override IItalianCuisine Create(int quantity)
        {
            return new Gnotchi(quantity);
        }

    }

    //interface 

    public interface IItalianCuisine
    {
        void Operate();
    }

    //concreteProduct
    public class Spagetti:IItalianCuisine
    {
        private readonly int _quantity;

        public Spagetti(int quantity)
        {
            this._quantity = quantity;

        }
        public void Operate()
        {
            System.Console.WriteLine(_quantity + " kg of spagetting are being created now ");
        }
    }

    public class Gnotchi:IItalianCuisine
    {
        private readonly int _quantity;

        public Gnotchi(int quantity)
        {
            this._quantity = quantity;
        }

        public void Operate()
        {
            System.Console.WriteLine(_quantity + " kg of Gnotchi are being prepared now");
        }
    }

    public enum Actions
    {
        Spagetti,
        Gnotchi
    }

     //Client

     public class ItalianRestaurant
     {
         private readonly Dictionary<Actions,PastaCreator> _factories;

         public IItalianCuisine ExecuteCreation(Actions action,int quantity)
         {
           return  _factories[action].Create(quantity);
         }

         public ItalianRestaurant()
         {
             _factories = new Dictionary<Actions, PastaCreator>();
             _factories.Add(Actions.Gnotchi,new GnotchiCreator());
             _factories.Add(Actions.Spagetti, new SpagettiCreator());
        }


     }

     public class PastaClient
     {
         public PastaClient()
         {
             var ir = new ItalianRestaurant().ExecuteCreation(Actions.Gnotchi, 15);
             ir.Operate();
         }
     }





}