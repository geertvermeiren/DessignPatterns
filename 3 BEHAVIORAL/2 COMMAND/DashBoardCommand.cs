using System;
using System.Collections.Generic;
using System.Linq;

//encapsulate commands requests as an object, then treat is  differently 
//The Command design pattern encapsulates a request as an object,
// thereby allowing us developers to treat that request differently
// based upon what class receives said command. Further, 
//it enables much more complex architectures, and even enables operations such as undo/redo

namespace DashBoardCommand
{

    //command = class that executes the acton

    public interface IAction
    {
       // bool IsCompleted { get; set; } 

        void Execute();
    }

    //concrete command= implementation of command

    public class Phone: IAction
    {
        private readonly DashBoard _dashBoard; 
        public string VoiceCall { get; set; }

        public Phone(DashBoard dashBoard,string voiceCall)
        {
            _dashBoard = dashBoard;
            VoiceCall = voiceCall;
        }

        public void Execute()
        {
            _dashBoard.Display += VoiceCall;
           
        }

    }

    public class Radio: IAction
    {
        private readonly DashBoard _dashBoard;
        public string Voice { get; set; }

        public Radio(DashBoard dashBoard ,string voice)
        {
            this._dashBoard = dashBoard;
            this.Voice = voice;
        }

        public void Execute()
        {
            _dashBoard.Display += Voice;
            

        }

    }

    public class PodCast:IAction
    {
        private readonly DashBoard _dashBoard;
        public string Voice { get; set; }

        public PodCast(DashBoard dashBoard, string voice)
        {
            this._dashBoard = dashBoard;
            this.Voice = voice;
        }
        public void Execute()
        {
            _dashBoard.Display += Voice;
        }
    }

    //receiver = business object that receives the action from the command

    public class DashBoard
    {
        public string Display { get; set; }

        public DashBoard(string display)
        {
            this.Display += display;
        }
    }




    //invoker = this class tells the to exectute the actions. the invoker can somethimes be quequed

    // everything is stored in a list.. ==> simple then execute the list whenever we want it to be executed.
    public class DashBoardManager
    {
        public readonly List<IAction> _dashBoard = new List<IAction>();

        public void AddAction(IAction action)
        {
            _dashBoard.Add(action);
        }

        public void ProcessPendingTransaction()
        {
            foreach(var item in _dashBoard)
            {
                item.Execute();

            }


        }

    }

    //client =uses the other classes
    public class Client
    {
        public Client()
        {
            DashBoardManager _dashBoardManager = new DashBoardManager();
            DashBoard _tesladashboard = new DashBoard($"TESLA : \n");
            Phone _phone = new Phone(_tesladashboard,"hello this is me \n");
            PodCast _podCast = new PodCast(_tesladashboard, "hello this is a podcast in your tesla \n");
            _dashBoardManager.AddAction(_phone);
            _dashBoardManager.AddAction(_podCast);
            _dashBoardManager.ProcessPendingTransaction();
            System.Console.WriteLine(_tesladashboard.Display);

        }
    }


}
