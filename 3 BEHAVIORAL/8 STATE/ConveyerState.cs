using System;
namespace ConveyerState
{
    //state
    public abstract class Output
    {
        protected Conveyer _state;
        protected int _currentOutput;

        protected int _minOutput;

        protected int _maxOutput;

        public int CurrentOutput
        {
            get{return _currentOutput;}
            set{_currentOutput = value;}
        }
        public Conveyer Conveyer
        {
            get{return _state;}
            set{_state = value;}
        }
     public abstract void AddOutPut(int quantity);

     public abstract void CheckOutput();


    }

    //concrete State

    public class NoOutput:Output
    {
        public NoOutput(Output state):this(state.CurrentOutput,state.Conveyer)
        {
        }

        public NoOutput(int currentOutput,Conveyer conveyer)
        {
            this._currentOutput = currentOutput;
            this.Conveyer = conveyer;
            Initialize();

        }
        public void Initialize()
        {
            _minOutput = 0;
            _maxOutput = 0;
        }

        public override void AddOutPut(int quantity)
        {
            _currentOutput += quantity;
            CheckOutput();
        }
        public override void CheckOutput()
        {  if(this._currentOutput > _maxOutput)
            Conveyer._state = new Normal(this);
        }


    }


    public class Normal:Output
    {
        public Normal(Output state):this(state.CurrentOutput,state.Conveyer)
        {

        }
        public Normal(int currentOutput,Conveyer conveyer)
        {
            this._currentOutput = currentOutput;
            this.Conveyer = conveyer;
            Initialize();
        }

        public void Initialize()
        {

            _minOutput = 1;
            _maxOutput = 50;

        }

        public override void AddOutPut(int quantity)
        {
            _currentOutput += quantity;
            CheckOutput();
        }
        public override void CheckOutput()
        {
          if(this._currentOutput > _maxOutput)
           Conveyer._state = new High(this);

        }

    }

    public class  High:Output
    {
        public High(Output state):this(state.CurrentOutput,state.Conveyer){}

        public High(int currentOutput,Conveyer conveyer)
        {
            this.CurrentOutput = currentOutput;

            Initialize();
        }
        public void Initialize()
        {
            _minOutput = 51;
            _minOutput = 200;

        }

        public override void AddOutPut(int quantity)
        {
            this._currentOutput += quantity;
            CheckOutput();
        }
        public override void CheckOutput()
        {
            
        }

    }

    //context
    public class Conveyer
    {
        public Output _state;

        public Conveyer()
        {
            _state = new NoOutput(0,this);
        }

        public Output State
        {
            get{return _state;}
            set{_state =value;}
        }

        public int CurrentOutput
        {
            get{return _state.CurrentOutput;}
            set{_state.CurrentOutput = value;}
        }

        public void AddOutPut(int quantity)
        {
            this._state.AddOutPut(quantity);
            System.Console.WriteLine($"the output amounts to : {CurrentOutput} items ");
            System.Console.WriteLine($"the output is thus : {_state.GetType().Name}  ");

        }

    }

    //client
    public class Client
    {
        public Client()
        {
            Conveyer cv = new Conveyer();
            cv.AddOutPut(0);
            cv.AddOutPut(5);
            cv.AddOutPut(30);
            cv.AddOutPut(55);
            cv.AddOutPut(120);

        }
    }
}