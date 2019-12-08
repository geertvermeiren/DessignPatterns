using System;
namespace MultiplyMemento
{
    public class Multiply
    {
        private int result = 1;

        public void MultiplyNow()
        {
            result *= 5;
        }

        public void Print()
        {
            System.Console.WriteLine($"{result}");
        }

        public Memento CreateMemento()
        {   
            Memento m = new Memento();
            m.SetState(result);
            return m;
        }

        public void SetMemento(Memento memento)
        {
              result = memento.GetState();

        }
    }
    public class Memento
    {
        private int result;

        public void SetState(int input)
        {
            this.result = input;
        }
        public int GetState()
        {
            return this.result;
        }
    }
    public class Client
    {
        public Client()
        {
            Multiply mul = new Multiply();
            mul.MultiplyNow();
            mul.MultiplyNow();
            mul.Print();
            var memento = mul.CreateMemento();
            mul.MultiplyNow();
            mul.MultiplyNow();
            mul.MultiplyNow();
            mul.Print();
            mul.SetMemento(memento);
            mul.Print();

        }
    }
}