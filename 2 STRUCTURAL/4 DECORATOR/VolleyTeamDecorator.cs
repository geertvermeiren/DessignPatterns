using System;
using System.Collections.Generic;

namespace VolleyTeamDecorator
{
    //add behavior dynamiccally by placing them inside wrapper object 
    //component
     public class Player
    {
        public string Name { get; set; }    
     
     
    }
    public abstract class Volley
    {
        public List<Player> _players = new List<Player>
        {
            new Player{Name="geert"},
            new Player{Name="patrizia"},
            new Player{Name="gael"},
            new Player{Name="max"},
            new Player{Name="max"},
            new Player{Name="max"},
            new Player{Name="max"},
            new Player{Name="max"},
        };
        public abstract int CountPlayers();

    }   

    //concrete component
    public class NormalVolley:Volley
    {
        public override int CountPlayers()
        {
            return _players.Count;
        }
    }
    // decorator
    public class BeachVolley:NormalVolley
    {
        NormalVolley _normalVolley;

        public BeachVolley(NormalVolley normalVolley)
        {
            this._normalVolley = normalVolley;
        }

       
    }
    //concrete decorator

    public class Sand:BeachVolley
    {
        public Sand(NormalVolley normalVolley):base(normalVolley)
        {

        }

        public override int CountPlayers()
        {
            return this._players.Count - 6;
        }
    }
    //client class
    public class Client
    {
         public Client()
         {
             NormalVolley nv = new NormalVolley();
             System.Console.WriteLine( $"normal volley has: {nv.CountPlayers()} players on the field");
             Sand s = new Sand(nv);
             System.Console.WriteLine( $"beach volley has: {s.CountPlayers()} players on the field");
         
         }
    }
}