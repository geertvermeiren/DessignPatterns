using System.Collections.Generic;

namespace FrenchFritesFactor
{

    //creator
    public abstract class Creator
    {
        public abstract IFrechFrites Create(int quantity);
    }

    //concretecreator

    public class FrenchFritesWithMayoCreator:Creator
    {
        public override IFrechFrites Create(int quantity)
        {
            return new FrenchFritesWithMayo(quantity);
        }

    }
    public class FrenchFritesWithKetchupCreator :Creator
    {

        public override IFrechFrites Create(int quantity)
        {
            return new FrenchFritesWithKetchup(quantity);
        }

    }
    
    //interface
    public interface IFrechFrites
    {
        void Operate();
    }

    //concreteProduct

    public class FrenchFritesWithMayo: IFrechFrites
    { 
        private readonly int _quantity;

        public FrenchFritesWithMayo(int quantity)
        {
            this._quantity = quantity;
        }

        public void Operate()
        {

        }        
    }
    public class FrenchFritesWithKetchup: IFrechFrites
    { 
        private readonly int _quantity;

        public FrenchFritesWithKetchup(int quantity)
        {
            this._quantity = quantity;

        }

        public void Operate()
        {
            System.Console.WriteLine(_quantity + " french frietes with ketchup created");

        }        
    }

    //client

    public enum Actions
    {
        Ketchup,
        Mayo
    }

}