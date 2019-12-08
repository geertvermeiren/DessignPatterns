using System;
using System.Collections.Generic;
using System.Linq;

/*command pattern encanpsulate command as an object, 
the calls which calls the command can treat it
dofferently,because is is an object
much complex arquitecture is possible */

namespace RobotCommand
{
    public class RobotAction
    {
        public string _name { get; set; }
        public int _quantity { get; set; }

        public RobotAction(string name,int quantity)
        {
            this._name = name;
            this._quantity = quantity;
        }

        public void Display()
        {
            System.Console.WriteLine($"Action name: {_name}");
            System.Console.WriteLine($"How many {_name} ? {_quantity}");
        }
    }


    //The Invoker asks the command to carry out its request.
    public class Player
    {
       private Action _action;
       private RobotAction _robotAction;

       private RobotController _robotController;

       public Player()
       {
           _robotController = new RobotController();           
       }

       public void SetCommand(int commandOption)
       {
           _action = new CommandFactory().GetCommand(commandOption);

       }

       public void SetRobotAction(RobotAction robotAction)
       {
           this._robotAction = robotAction;


       }
       public void ExecuteAction()
       {
           this._robotController.ExecuteCommand(_action,_robotAction);
       }

       public void ShowCurrentAction()
       {
           this._robotController.ShowCurrentCommand();

       }




    }
    

    //factory method
    public class CommandFactory
    {
        public Action GetCommand(int commandOption)
        {
            switch(commandOption)
            {
               case 1: return new Add();

               case 2: return new Remove();

               default:return new Modify();

            }

        }

    }
    // The Receiver knows how to perform the operations associated with carrying out the request.
   
    public class RobotController
    {

      public List<RobotAction>  _currentAction { get; set; }

      public RobotController()
      {
          _currentAction = new List<RobotAction>();

      }

      public void ExecuteCommand(Action action,RobotAction robotAction)
      {
          action.Execute(this._currentAction,robotAction);

      }

      public void ShowCurrentCommand()
      {
          foreach(var item in _currentAction)
          {
              item.Display();
          }
          System.Console.WriteLine("-----------------");
      }

    }



    //The Command declares an interface for executing an operation.

    public abstract class Action
    {
            public abstract void Execute(List<RobotAction> _robotAction,RobotAction _action);
          

    }

    //The ConcreteCommand defines a binding between a Receiver and an action.
    
    public class Add:Action
    {
         public override void Execute(List<RobotAction> _robotAction,RobotAction _action)
         {
            _robotAction.Add(_action);
         }
        
    }

    public class Remove:Action
    {
         public override void Execute(List<RobotAction> _robotAction,RobotAction _action)
         {
            _robotAction.Remove(_robotAction.Where( x =>x._name == _action._name).First());
           
         }
        
    }

    public class Modify:Action
    {
         public override void Execute(List<RobotAction> _robotAction,RobotAction _action)
         {
             var act = _robotAction.Where(x => x._name == _action._name).First();
             act._name = _action._name;
             act._quantity = _action._quantity;

         }

    }



    public class Client
    {
        public Client()
        {
            Player _player = new Player();
            _player.SetCommand(1); //add
            _player.SetRobotAction(new RobotAction("walk",5));
            _player.ExecuteAction();
            _player.SetCommand(1); //add
            _player.SetRobotAction(new RobotAction("kick",5));
            _player.ExecuteAction();
            _player.SetCommand(1); //add
            _player.SetRobotAction(new RobotAction("jump",5));
            _player.ExecuteAction();
            _player.ShowCurrentAction();

        }
    }



}