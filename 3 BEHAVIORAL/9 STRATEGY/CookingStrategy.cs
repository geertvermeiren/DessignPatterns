using System;

/*The Strategy design pattern defines a family of algorithms, 
then makes them interchangeable by encapsulating each as an object. 
Consequently, the actual operation of the algorithm can vary based on 
other inputs, such as which client is using it. */

namespace CookingStrategy
{
    //strategy
     public abstract class CookStrategy
     {
         public abstract void Cook(string food);
     }

    //concrete strategy

    public class Grilling:CookStrategy
    {
        public override void Cook(string food)
        {
            System.Console.WriteLine($"cooking {food } by {this.GetType().Name} it ");
        }
    }

    public class Baking:CookStrategy
    {
        public override void Cook(string food)
        {
            System.Console.WriteLine($"cooking {food } by {this.GetType().Name} it ");
           
        }
    }

    //context

    public class CookingMethod
    {
        private string _food;

        public CookStrategy _cookStrategy;

        public void SetCookStrategy(CookStrategy cookStrategy)
        {
            this._cookStrategy = cookStrategy;

        }

        public void SetFood(string food)
        {
            this._food = food;

        }
        public void Cook()
        {
            _cookStrategy.Cook(_food);

        }

    }


    public class Client
    {
        public Client()
        {
            CookingMethod _cookingMethod = new CookingMethod();

    Console.WriteLine("What food would you like to cook?");
    var food = Console.ReadLine();
    _cookingMethod.SetFood(food);

    Console.WriteLine("What cooking strategy would you like to use (1-3)?");
    int input = int.Parse(Console.ReadKey().KeyChar.ToString());
            
            

            switch(input)
            {
                case 1: 
                    _cookingMethod.SetCookStrategy(new Grilling());
                    _cookingMethod.Cook();
                    break;
                case 2: 
                    _cookingMethod.SetCookStrategy(new Baking());
                    _cookingMethod.Cook();
                    break;

            }

        
        Console.ReadKey();
        }

        


    }


}