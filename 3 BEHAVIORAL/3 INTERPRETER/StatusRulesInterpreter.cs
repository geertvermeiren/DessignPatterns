using System;

namespace StatusRulesInterpreter
{
    //expression
    public interface IExpression
    {
         bool Interpret(string context);     
      
    }

    //terminal
    public class TerminalExpression:IExpression
    {
        private string _data;
        public TerminalExpression(string data)
        {
            this._data = data;
        }
        public bool Interpret(string context)
        {
            if(context.Contains(_data))
            {
                return true;
            }
            return false;
        }

    }
    //non terminal

    public class OrExpression:IExpression
    {
        private IExpression _expr1 = null;
        private IExpression _expr2 = null;

        public OrExpression(IExpression expr1,IExpression expr2)
        {
            this._expr1 = expr1;
            this._expr2 = expr2;
        }

        public bool Interpret(string context)
        {
            return _expr1.Interpret(context) && _expr2.Interpret(context);
        }
    }

    public class AndExpression:IExpression
    {
        private IExpression _expr1;
        private IExpression _expr2;

        public AndExpression(IExpression expr1,IExpression expr2)
        {
            this._expr1 = expr1;
            this._expr2 = expr2;
        }

        public bool Interpret(string context)
        {
            return _expr1.Interpret(context) & _expr2.Interpret(context);
        }
    }

    //context

    public class Context
    {
       
            public static IExpression GetMaleExpression()
            {
                IExpression robert = new TerminalExpression("rober");
                IExpression luc = new TerminalExpression("luc");
                return new OrExpression(robert,luc);                
            }

            public static IExpression GetMarriedExpression()
            {
                IExpression julie = new TerminalExpression("julie");
                IExpression married = new TerminalExpression("married");
                return new AndExpression(julie,married);
            }
        
    }

    public class Client
    {
         public Client()
         {
          var IsMale = Context.GetMaleExpression();
          System.Console.WriteLine(IsMale.Interpret("robert"));

         var isMarried = Context.GetMarriedExpression();
         System.Console.WriteLine(isMarried.Interpret("married julie"));

            
         }
    }
}