using MeadDB;
using System;

namespace MeatAdapter
{

///

/// The new Meat class, which represents details about a particular kind of meat.
/// </summary>
public class Meat
{
    protected string MeatName;
    protected float SafeCookTempFahrenheit;
    protected float SafeCookTempCelsius;
    protected double CaloriesPerOunce;
    protected double ProteinPerOunce;

    // Constructor
    public Meat(string meat)
    {
        this.MeatName = meat;
    }

    public virtual void LoadData()
    {
        Console.WriteLine("\nMeat: {0} ------ ", MeatName);
    }
}

//ADAPTER
/// <summary>
/// The Adapter class, which wraps the Meat class and initializes that class's values.
/// </summary>
/// <code>
/// this is an adapter
/// 
/// </code>
public class Adapter: Meat
{

     private MeatDatabase _meatDatabase;

    // Constructor
    public Adapter(string name)
        : base(name)
    {
    }

     public override void LoadData()
    {
       _meatDatabase = new MeatDatabase();

       SafeCookTempFahrenheit = _meatDatabase.GetSafeCookTemp(MeatName,TemperatureType.Fahrenheit);
      base.LoadData();
        Console.WriteLine(" Safe Cook Temp (F): {0}", SafeCookTempFahrenheit);
    }

}


}