using System;

//lets you define a family of algoritms puts them in a class and makes them interchangeable. 

namespace SoccerStrategy
{ 

    //strategy
    public abstract class SoccerStrategy
    {
        public abstract void Strategy(string team);     

        
    }

    //concrete strategy

    public class TreeFourTree:SoccerStrategy
    {
        public override void Strategy(string team)
        {
            System.Console.WriteLine($"the {team} is play {this.GetType().Name}");

        }
    }

    public class FourFourTwo:SoccerStrategy
    {
        public override void Strategy(string team)
        {
            System.Console.WriteLine($"the {team} is play {this.GetType().Name}");

        }
    }


    //context

    public class SoccerGame
    {
        private SoccerStrategy _soccerStrategy ;
        private string _numberOfGoals;
        

        public void SetSoccerStrategy(SoccerStrategy soccerStrategy)
        {
            this._soccerStrategy = soccerStrategy;
        }


        public void SetGoalsScored(string numberOfGoals)
        {
            this._numberOfGoals = numberOfGoals;

        }

        public void PlaySoccer()
        {
            _soccerStrategy.Strategy(_numberOfGoals);
        }


        
    }


    //AccessClient

    public class Client
    {
        public Client()
        {
            SoccerGame _soccerGame = new SoccerGame();
            System.Console.WriteLine("how many goals where scored ??");
            _soccerGame.SetGoalsScored("5");
            System.Console.WriteLine("what strategy was used ?");
            _soccerGame.SetSoccerStrategy(new FourFourTwo());
            _soccerGame.PlaySoccer();
        }
    }

}