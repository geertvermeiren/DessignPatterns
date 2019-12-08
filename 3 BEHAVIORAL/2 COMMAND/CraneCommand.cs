using System;
using System.Collections.Generic;

namespace CraneCommand
{
    //command
    public interface IAction
    {
        void Execute();
    }
    //concrete command
    public class Lift:IAction
    {
        public Crane _crane; 
        public string Command { get; set; }
        public Lift(Crane crane, string command)
        {
            this.Command = command;
            this._crane = crane;

        }
        public void Execute()
        {
            _crane.Display += Command;
        }

    }
    public class SwingLeft:IAction
    {
        public readonly Crane _crane; 
        public string Command { get; set; }
        public SwingLeft(Crane crane,string command )
        {
            this.Command = command;
            this._crane = crane;

        }
        public void Execute()
        {
            _crane.Display += Command;
        }
    }

    public class Drop:IAction
    {
        private readonly Crane _crane;
        public string Command { get; set; }
        public Drop(Crane crane, string command)
        {
            this.Command= command;
            this._crane= crane;

        }
        public void Execute()
        {
            _crane.Display+= Command;
        }
    }


    //receiver
    public class Crane
    {
        public string Display { get; set; }
        public Crane(string display)
        {
            this.Display += display;
        }

    }

    //invoker
    public class CraneManagement
    {
        private readonly List<IAction> _action = new List<IAction>();

        public void Add(IAction action)
        {
            _action.Add(action);

        }

        public void ProcessCommands()
        {
            foreach(var item in _action)
            {
                item.Execute();
            }
        }
    }
    //client
    public class Client
    {
        public Client()
        {
            CraneManagement cm = new CraneManagement();
            Crane _higerLifter = new Crane("HIGHLIFTER: \n");
            Lift _lift = new Lift(_higerLifter, "lifting now ... \n");
            SwingLeft _swingLeft = new SwingLeft(_higerLifter, "swinging to the lef ... \n");
            Drop _drop = new Drop(_higerLifter,"dropping everything now..\n");
            cm.Add(_lift);
            cm.Add(_swingLeft);
            cm.Add(_drop);
            cm.ProcessCommands();
            System.Console.WriteLine(_higerLifter.Display);
        }
    }
}

