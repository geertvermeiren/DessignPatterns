using System;
using System.Collections.Generic;

namespace Car2
{
    //abstract creator
    public abstract class Creator
    {
        public abstract ICar Create(int quantity);
    }

    //concrete creator
    public class CarCreator:Creator
    {
        public override ICar Create(int quantity)
        {
            return new Volvo(quantity);
        }
    }


    //interface

    public interface ICar
    {
        void Operate();
    }

    //concrete product

    public class Volvo:ICar
    {
        private readonly int _quantity;

        public Volvo(int quantity)
        {
            this._quantity = quantity;

        }

        public void Operate()
        {
            System.Console.WriteLine(_quantity + "volvos are being produced");
        }
    }

    //client

    public enum Actions
    {
        Volvo
    }

    public class Client
    {
        private readonly Dictionary<Actions,CarCreator> _factories;

        public ICar Executar(Actions action,int quantity)
        {
            return _factories[action].Create(quantity);

        }


        public Client()
        {
            _factories = new Dictionary<Actions,CarCreator>();
            _factories.Add(Actions.Volvo,new CarCreator());
        }


    }
}