using System;
using System.Collections.Generic;

namespace TrainCommand
{
    //command 

    public interface IAction
    {
        void Execute();
    }

    //concrete command

    public class Start:IAction
    {
        private readonly Train _train;
        public string Command { get; set; }
        public Start(Train train,string command)
        {
            this.Command = command;
            this._train = train;

        }
        public void Execute()
        {
            _train.Dislay += Command;
        }



    }
    public class Stop:IAction
    {
        public readonly Train _train;
        public string Command { get; set; }
        public Stop(Train train,string command)
        {
            this.Command = command;
            this._train = train;
        }
        public void Execute()
        {
            _train.Dislay += Command;
        }

    }

    public class Drive:IAction
    {
        private readonly Train _train; 
        public string Command { get; set; }
        public Drive(Train train,string command)
        {
            this.Command = command;
            this._train = train;

        }

        public void Execute()
        {
            _train.Dislay += Command;
        }
    }

    //receiver 
    public class Train
    {
        public string Dislay { get; set; }
        public Train(string display)
        {
            this.Dislay += display;
        }
    }

    //invoker
    public class RemoteTrainControll
    {
        private readonly List<IAction> _train = new List<IAction>();

        public void Add(IAction action)
        {

            _train.Add(action);

        }
        public void ProcessPendingTransactions()
        {
            foreach(var item in _train)
            {
                item.Execute();
            }

        }
    } 

    // Client

    public class Client
    {

        public Client(){
        RemoteTrainControll rtc = new RemoteTrainControll();
        Train _train = new Train("TGV \n");
        Start _start = new Start(_train,"starting the train.. \n");
        Stop _stop = new Stop(_train, "stopping the train");
        Drive _drive = new Drive(_train, "Driving the train..\n");
        rtc.Add(_start);
        rtc.Add(_drive);
        rtc.Add(_stop);
        rtc.ProcessPendingTransactions();
        System.Console.WriteLine(_train.Dislay);
        }
    }
}
