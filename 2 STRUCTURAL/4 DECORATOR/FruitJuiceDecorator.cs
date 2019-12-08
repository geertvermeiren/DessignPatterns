using System;
using System.Collections.Generic;

namespace FruitJuiceDecorator
{
    //component
    public class Fruit
    {
        public string Name { get; set; }
    }

    public abstract class FruitCollection:Fruit
    {
        public List<Fruit> _fruitCollection = new List<Fruit>
        {
            new Fruit{Name="apple"},
            new Fruit{Name="organge"},
            new Fruit{Name="strawberry"},
            new Fruit{Name="grapefruit"},
        };

        public abstract int CountFruits();
    }

    //concrete component

    public class FruitSalad:FruitCollection
    {
        public override int  CountFruits()
        {
            return _fruitCollection.Count;
        }
    }

    //decorator
    public class MixerDecorator:FruitSalad
    {
        FruitSalad _fruitSalad;

        public MixerDecorator(FruitSalad fruitSalad)
        {
            this._fruitSalad= fruitSalad;
        }

      
    }

    //concrete decorator
     public class FruitJuice:MixerDecorator
    {
        public FruitJuice(FruitSalad fruitSalad):base(fruitSalad)
        {

        }

        public override int CountFruits()
        {
            return _fruitCollection.Count + 15;
        }

     
     
     
    }
    //client class
    public class Client
    {
         public Client()
         {

             FruitSalad _fs = new FruitSalad();
             FruitJuice _fj = new FruitJuice(_fs);
             System.Console.WriteLine( _fj.CountFruits());
         
         }
    }
}