using System;

namespace MementoCalculator3
{
    public class Calculator
    {
        private int result = 0;
        public int Add(int input)
        {
          return  this.result += input;

        }

        public int Substract(int input)
        {
           return this.result -= input;
        }

        public void Print()
        {
            System.Console.WriteLine($"RESULT: {result}");
        }

        public Memento CreateMemento()
        {
            Memento memento = new Memento();
            memento.SetState(this.result);
           return memento;
        }

        public void SetMemento(Memento memento)
        {
            this.result = memento.GetState();

        }



    }

    public class Memento
    {
        private int state;

        public int GetState()
        {
          return  this.state;
        }

        public void SetState(int state)
        {
            this.state = state;

        }

    }

    public class Client
    {
        public Client()
        {

            Calculator c = new Calculator();
            c.Add(5);
            c.Substract(3);
            c.Print();
            var mymemento =  c.CreateMemento();
            System.Console.WriteLine("memento created");
            c.Add(20);
            c.Print();
            c.SetMemento(mymemento);
            System.Console.WriteLine("memento set");
            c.Print();

        }
    }
}