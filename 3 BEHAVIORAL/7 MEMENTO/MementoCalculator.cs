using System;

namespace MementoCalculator
{
 public class Calculator
{
  public int result = 0;
 
    public int Add(int a)
    {
        this.result += a;
        return this.result;
    }
 
    public int Subtract(int a)
    {
        this.result -= a;
        return this.result;
    }
 
    public void Print()
    {
        Console.WriteLine("Result: " + this.result);
    }
 
    public CalculatorMemento CreateMemento()
    {
        CalculatorMemento calcMemento = new CalculatorMemento();
        calcMemento.SetState(this.result);
        return calcMemento;
    }
 
    public void SetMemento(CalculatorMemento memento)
    {
        this.result = memento.GetState();
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
        System.Console.WriteLine(calc.result);
        calc.Add(4);        // result 4
        calc.Add(3);        // result 7
        calc.Subtract(1);   // result 6
  calc.Print();       // print 7
  CalculatorMemento checkpoint = calc.CreateMemento();
  System.Console.WriteLine("memento created");
  calc.Add(10);
  calc.Print();
  System.Console.WriteLine("****");
  calc.SetMemento(checkpoint);
  System.Console.WriteLine("memento set:");
  calc.Print();
        // CalculatorMemento checkPoint1 = calc.CreateMemento();
        // calc.Add(1);        // result 7
        // calc.Print();       // print 7
 
        // calc.SetMemento(checkPoint1);
        // calc.Print();       // result 6
    }
}
}
