using System;
using System.Collections.Generic;

// command patterns.. ability to postpone operations.. by encapsualting then in an objct
//then call this object via a list => invoker.. 

namespace CalculatorCommand
{
    //command
    public interface IAction
    {
        void Execute();
    }

    //concreteCommand
    public class Adding:IAction
    {
        private readonly Calculator _calculator;
        public int Operation { get; set; }
        public Adding(Calculator calculator,int operation)
        {
            this._calculator = calculator;
            this.Operation = operation;
        }
        public void Execute()
        {
            _calculator.Result += Operation;
        }

    }

    public class   Substraction:IAction
    {
        private readonly Calculator _calculator;
        public int Operation { get; set; }
        public Substraction(Calculator calculator, int operation)
        {   
            this.Operation = operation;        
            this._calculator = calculator;

        }
        public void Execute()
        {
         _calculator.Result -=  Operation;   
        }

    }
    
    public class Multiply:IAction
    {
        private readonly Calculator _calculator;
        public int Operation { get; set; }
        public Multiply(Calculator calculator,int operation)
        {
            this.Operation = operation;
            this._calculator = calculator;
        }

        public void Execute()
        {
            _calculator.Result *=Operation;
        }
    }

    //invoker
    public class CalculatorControl
    {
        public readonly List<IAction> _calculator = new List<IAction>();

        public void Add(IAction action)
        {
            _calculator.Add(action);

        } 
        public void ProcessExecution()
        {
            foreach(var item in _calculator)
            {
                item.Execute();
            }
        }

    }

    //receiver
    public class Calculator
    {
        public int Result { get; set; }
        
        public Calculator(int result)
        {
            this.Result += result;
        
        }
        
    }

    //client
    public class Client
    {
        public Client()
        {
            CalculatorControl cc = new CalculatorControl();
            Calculator _calculator = new Calculator(0);
            Adding _add = new Adding(_calculator,15);
            Substraction _sub = new Substraction(_calculator,10);
            Multiply _multi = new Multiply(_calculator,3);
            cc.Add(_add);
            cc.Add(_sub);
            cc.Add(_multi);
            cc.ProcessExecution();
            System.Console.WriteLine(_calculator.Result);
        }
    }
}