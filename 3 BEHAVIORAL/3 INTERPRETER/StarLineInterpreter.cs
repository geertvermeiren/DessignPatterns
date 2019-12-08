using System;
using System.Collections.Generic;

namespace StarLineInterpreter
{
    //expression
    public abstract class Expression
    {
        public void Interpret(Context context)
        {
            if(context.Input.Length == 0 )
            {
                return;
            }

            if(context.Input.StartsWith(star()))
            {
                context.Output += 1;
                context.Input = context.Input.Substring(1);
            }
            if(context.Input.StartsWith(Dash()))
            {  context.Output += 2;
                context.Input = context.Input.Substring(1);
            }
            if(context.Input.StartsWith(BackSlash()))
            {   context.Output += 3;
                context.Input = context.Input.Substring(1);
            }

        }

        public abstract string star();
        public abstract string BackSlash();

        public abstract string Dash();
    }


    //terminal expression
    public class TerminalExpression:Expression
    {
        public override string star()
        {
            return "*";
        }
        public override string BackSlash()
        {
            return "/";
        }

        public override string Dash()
        {
            return "-";
        }
    }



    //context

    
    public class Context
    {
        public string Input { get; set; }
        public int Output { get; set; }
     
     
     
    }
    //client class
    public class Client
    {
         public Client()
         {
         
         }
    }
}