using System;
using System.Collections.Generic;

namespace PizzaFactor
{


 // creator

public abstract class PizzaCreator
{
    public abstract IPizzaria Create(int quantity);
}
 //concretecreator

public class PeperoniProduction:PizzaCreator
{
    public override IPizzaria Create(int quantity)
    {
        return new Peperoni(quantity);
    }

}

public class VeganoProduction:PizzaCreator
{
    public override IPizzaria Create(int quantity)
    {
        return new Vegano(quantity);
    }

}


 //interface

 public interface IPizzaria
 {
     void Operate();
 }

 //concreteproduct 

 public class Peperoni:IPizzaria
 {
     
    public readonly int _quantity;

    public Peperoni(int quantity)
    {
        this._quantity = quantity;

    }
    
     public void Operate()
     {
        System.Console.WriteLine(_quantity + "peperoni pizza´s are being prepared now");
     }

 }

 public class Vegano:IPizzaria
 {
     public readonly int _quantity;

     public Vegano(int quantity)
     {
         this._quantity = quantity;

     }
     public void Operate()
     {
     System.Console.WriteLine(_quantity + "vegano pizza´s are being created");
     }

 }

 //client

 public enum Actions
 {
     Peperoni,
     Vegano
 }

 public class Pizzaria
 {
     public IPizzaria ExecuteCreation(Actions action, int quantity) => _factories[action].Create(quantity);
     
     private readonly Dictionary<Actions,PizzaCreator>_factories;
     public Pizzaria()
     {
         _factories = new Dictionary<Actions, PizzaCreator>();
         _factories.Add(Actions.Peperoni, new PeperoniProduction());
         _factories.Add(Actions.Vegano,new VeganoProduction());

     }
 }

 

}