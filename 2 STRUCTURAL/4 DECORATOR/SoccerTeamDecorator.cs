using System;
using System.Collections.Generic;
using System.Linq;

//add new behavior to an existing object dynamically by placing them inside a special wrapper
namespace SoccerTeam
{
    public class SoccerTeam
    {
        public int Id { get; set; }
        public string Name { get; set; }

    }
    //component
    public abstract class Team
    {
        public List<SoccerTeam> soccerTeam = new List<SoccerTeam>
        {
            new SoccerTeam{Id = 1 , Name = "Geert"},
            new SoccerTeam{Id = 2 , Name = "Pat"},
            new SoccerTeam{Id = 3 , Name = "Ga"}
        };
        public abstract int TeamCount();
        

        
    }
    // Concrete Component
    public class BasicTeam:Team
    {
        public override int TeamCount()
        {
            return soccerTeam.Count();
        }

    }

    // decorator
   public class TeamDecorator:Team
   {
       Team _team; 

       public TeamDecorator(Team team)
       {
           this._team = team;
       }

       public override int TeamCount()
       {
           return _team.TeamCount();
       }
   }
    //concrete decorator

    public class ReservesTeam: TeamDecorator
    {
        public ReservesTeam(Team team):base(team)
        {
            
        }
        public override int TeamCount()
        {
            return base.TeamCount() + 10;
        }
    }

    public class Client
    {
        public Client()
        {
            var bt = new BasicTeam();
            System.Console.WriteLine(bt.TeamCount());
            var rs = new ReservesTeam(bt);
            System.Console.WriteLine(rs.TeamCount());
        }
    }










}