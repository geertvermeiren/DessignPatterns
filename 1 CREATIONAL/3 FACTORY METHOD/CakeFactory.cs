using System; 
using System.Collections.Generic;

namespace CakeFactor
{
     //creator

     public abstract class CakeCriator
     {
         public abstract ICake Create(int quantity);
     }


     //concretecreator 1

     public class ChocolateCakeCreator:CakeCriator
     {

         public override ICake Create(int quantity)
         {

             return new ChocolateCake(quantity);

         }

     }

     //concretecreator 2

     public class LemmonCakeCreator:CakeCriator
     {
         public override ICake Create(int quantity)
         {
             return new LemmonCake(quantity);
         }

     }

     //interface 

     public interface ICake
     {
         void Operate();
     }

     //concreteproduct 1: inteface
     public class ChocolateCake: ICake
     {
         private readonly  int _quantity; 

         public ChocolateCake(int quantity)
         {
                _quantity = quantity;
         } 

         public void Operate()
         {
             System.Console.WriteLine("creating " + _quantity + " of cakes");
         }

     }
     //concreteproduct 2: interface

     public class LemmonCake:ICake
     {
         private readonly int _quantity;

         public LemmonCake(int quantity)
         {
             this._quantity = quantity;

         }

         public void Operate()
         {
             System.Console.WriteLine( _quantity + " are being created ");
         }



     }

     //client

     public enum Actions
     {
         ChocolateCake,
         LemmonCake
     }

     public class CakeFactory
     {
         private readonly Dictionary<Actions,CakeCriator> _factories;

         public ICake ExecuteCreation(Actions action, int quantity)
         {
             return _factories[action].Create(quantity);


         }

             public CakeFactory()
             {
                 _factories = new Dictionary<Actions, CakeCriator>();
                 _factories.Add(Actions.ChocolateCake,new ChocolateCakeCreator());
                 _factories.Add(Actions.LemmonCake,new LemmonCakeCreator());

             }
     }

     public class Client
     {
         public Client()
         {
         var cf = new CakeFactory().ExecuteCreation(Actions.ChocolateCake, 24);
         cf.Operate();
         }
     }
}


