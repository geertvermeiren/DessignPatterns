using System;
using System.Collections.Generic;

namespace NumberRulesInerpreter
{
    //expression

    public interface IExpression
    {
         bool Interpret(int context);
    }

     //terminal 
    public class TerminalExpression:IExpression
    {
        private int _data;

        public TerminalExpression(int data)
        {

            this._data = data;
        }


        public bool Interpret(int context)
        {
           
                return true;
         
        }
    }


    public class NonTerminalExpression:IExpression
    {
        private IExpression _expr1;
        private IExpression _expr2;
        public NonTerminalExpression(IExpression expr1, IExpression expr2)
        {
            this._expr1 = expr1;
            this._expr2 = expr2;   
        }

        public bool Interpret(int context)
        {
            
            return _expr1.Interpret(context) && _expr2.Interpret(context);
        }
    }

    //non terminal

    //context
    public class Context
    {
        public static IExpression Multiply()
        {
            IExpression factor1 = new TerminalExpression(15);
            IExpression factor2 = new TerminalExpression(3);
            return new NonTerminalExpression(factor1,factor2);
        }

    }


    //client class
    public class Client
    {
         public Client()
         {
           var m = Context.Multiply();
      System.Console.WriteLine("not working ");
         
         }
    }
}