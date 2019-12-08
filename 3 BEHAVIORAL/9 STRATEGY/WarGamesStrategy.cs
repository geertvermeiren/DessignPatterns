using System;

/*The Strategy design pattern defines a family of algorithms, 
then makes them interchangeable by encapsulating each as an object. 
Consequently, the actual operation of the algorithm can vary based on 
other inputs, such as which client is using it. */

/*strategy defines a family of algorithms,then makes them 
interchangeable by encapsulating as an object */

namespace WarGamesStrategy
{
    //Strategy
     public abstract class Tactics
     {
         public abstract void Battle(string army);
     }

    //Concrete Strategy

    public class Guerillia:Tactics
    {
        public override void Battle(string army)
        {
            System.Console.WriteLine($"the {army} are applying {this.GetType().Name} tactics");

        }

    }
    public class FrontalWar:Tactics
    {
        public override void Battle(string army)
        {
            System.Console.WriteLine($"the {army} are applying {this.GetType().Name} tactics");

        }
    }

    //context

    public class BattleField
    {
        public Tactics _tactics ;
        private string _weapons;

        public void SetArmy(Tactics tactics)
        {
            this._tactics = tactics;
        }

        public void SetWeapons(string weapons)
        {
            this._weapons = weapons;

        }

        public void PlayWar()
        {
            _tactics.Battle(_weapons);
        }



    }

    //client

    public class Client
    {
        public Client()
        {
            BattleField _battelfield = new BattleField();
            _battelfield.SetArmy(new FrontalWar());
            _battelfield.PlayWar();


        }
    }

}