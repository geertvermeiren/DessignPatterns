using System;
using System.Collections.Generic;

namespace RocketCommand
{
    // command
    public interface IAction
    {
         void Execute();
    }

    //concrete command
    public class Start:IAction
    {        
        private readonly Rocket _rocket;
        public string Command { get; set; }
        public Start(Rocket rocket,string command)
        {
            this.Command = command;
            this._rocket = rocket;
        }
        public void Execute()
        {
            _rocket.Display += Command;
        }
    }

    public class Stop:IAction
    {
        private readonly Rocket _rocket;

        public string Command { get; set; }
        public Stop(Rocket rocket,string command)
        {
            this.Command = command;
            this._rocket = rocket;
        }
        public void Execute()
        {
            _rocket.Display += Command;
        }
    }
    //invoker

    public class ControllCenter
    {
        private readonly List<IAction> _rocket = new List<IAction>();        
        public void AddAction(IAction action)
        {
            _rocket.Add(action);
        }
        public void ProcessPendingTransaction()
        {
            foreach(var item in _rocket)
            {
                item.Execute();

            }
        }       
    }


    //receiver 

    public class Rocket
    {
        public string  Display { get; set; }

        public Rocket(string display)
        {
            this.Display += display;

        }

    }

    //client
    public class Client
    {
        public Client()
        {
            ControllCenter _controlCenter = new ControllCenter();
            Rocket spaceShipOne = new Rocket("TESLA ROCKET \n");
            Start start = new Start(spaceShipOne,"starting  \n ");
            Stop stop = new Stop(spaceShipOne,"stopping  \n");
            _controlCenter.AddAction(start);
            _controlCenter.AddAction(stop);
            _controlCenter.ProcessPendingTransaction();
            System.Console.WriteLine(spaceShipOne.Display);


        }
    }
}


