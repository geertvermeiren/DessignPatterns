using System;

namespace mementoCalcualor2
{
    public class Calculator
    {
        private int _result =0;

        public int Add(int input)
        {
            this._result = input;
            return _result;
        }
        public int Substract(int input)
        {
            this._result -= input;
            return _result;
        }

        public void Print()
        { 
            System.Console.WriteLine($"result :{_result}");
            

        }

        public CalculatorMemento CreateMemento()
        {
            CalculatorMemento calculatorMemento = new CalculatorMemento();
            calculatorMemento.SetState(this._result);
            return calculatorMemento;
        }

        public void SetMemento(CalculatorMemento calculatorMemento)
        {
            this._result =calculatorMemento.GetState();
        }
    }

    public class CalculatorMemento
    {
        private int state;

        public int GetState()
        {
            return this.state;
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
            Calculator calc = new Calculator();
        calc.Add(4);        // result 4
        calc.Add(3);        // result 7
        calc.Substract(1);   // result 6
            calc.Print();


        }
    }
}