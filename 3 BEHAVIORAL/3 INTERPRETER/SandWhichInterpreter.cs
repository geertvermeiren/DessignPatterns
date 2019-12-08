using System;
using System.Collections.Generic;

namespace SandWhichInterpreter
{
    public interface IExpression
    {
        void Interpret(Context context);
    }
    public class Context
    {
        public string Output { get; set; }
    }
    public interface ICondiment : IExpression{}
    public interface IIngredient : IExpression{}

    public class MayoCondiment:ICondiment
    {
        public void Interpret(Context context)
        {
            context.Output += "Mayo";
        }
    }

    public class KetchupCondiment:ICondiment
    {
        public void Interpret(Context context)
        {
            context.Output += "ketchup";
        }
    }
    
    public class MostardCondiment:ICondiment
    {
        public void Interpret(Context context)
        {
            context.Output += "Mostard";
        }
    }

    public class CondimentList:IExpression
    {
        private readonly List<ICondiment> _condiments;

        public CondimentList(List<ICondiment> condiments)
        {   
            this._condiments = condiments;
        }

        public void Interpret(Context context)
        {
            foreach(ICondiment condiment in _condiments)
            {
                condiment.Interpret(context);
            }
        }

    }

    public class LettuceIngredient:IIngredient
    {
        public void Interpret(Context context)
        {
            context.Output += "Lettuce";

        }
    }

    public class ChickenIngredient:IIngredient
    {
        public  void Interpret(Context context)
        {
            context.Output += "Chicken";
        }
    }

    public class IngredientList:IIngredient
    {
        private readonly List<IIngredient> _ingredientList;

        public IngredientList(List<IIngredient> ingredientList)
        {
            this._ingredientList = ingredientList;
        }

        public void Interpret(Context context)
        {
            foreach (IIngredient ingredient in _ingredientList)
                ingredient.Interpret(context);
        }
    }

    public interface IBread:IExpression{}

    public class WhiteBread:IBread
    {
        public void Interpret(Context context)
        {
            context.Output += "Whitebread";
        }
    }

    public class DarkBread:IBread
    {
        public void Interpret(Context context)
        {
            context.Output += "DarkBread";
        }
    }

    public class SandWhich:IExpression
    {
        private readonly IBread _topBread;
        private readonly CondimentList _topCondiments;
        private readonly IngredientList _ingredients;
        private readonly CondimentList  _bottomCondiments;
        private readonly IBread _bottomBread;

        public SandWhich(IBread topBread,CondimentList topCondiments,IngredientList ingredients,CondimentList bottomCondiments,IBread bottomBread)
        {
            this._topBread = topBread;
            this._topCondiments = topCondiments;
            this._ingredients = ingredients;
            this._bottomCondiments = bottomCondiments;
            this._bottomBread = bottomBread;
        }

        public void Interpret(Context context)
        {
            context.Output += "|";
            _topBread.Interpret(context);
            context.Output += "|";
            context.Output += "<--";
            _topCondiments.Interpret(context);
            context.Output += "-";
            _ingredients.Interpret(context);
            context.Output += "-";
            _bottomCondiments.Interpret(context);
            context.Output += "-->";
            context.Output += "|";
            _bottomBread.Interpret(context);
            context.Output += "|";
            Console.WriteLine(context.Output);

        }
    }

    public class Client
    {
         public Client()
         {
             SandWhich sandWhich = new SandWhich(
             new WhiteBread(),
                new CondimentList(
                    new List<ICondiment> { new MayoCondiment(), new MostardCondiment() }),
                new IngredientList(
                    new List<IIngredient> { new LettuceIngredient(), new ChickenIngredient() }),
                new CondimentList(new List<ICondiment> { new KetchupCondiment() }),
                new WhiteBread());
 
            sandWhich.Interpret(new Context());
    
         }
    }

}