using System;
using System.Collections.Generic;

//tree which adds dynamic behavior to objects
namespace CompositeFleet
{
//component

public abstract class Car
{
    public string name;
    public int price;

    public Car(string name,int price)
    {
        this.name = name;
        this.price = price;
    }


    public abstract int CalculatePrice();
}

public interface Icar
{
    void Add(Car car);
    void Remove(Car car);
}


//composite

public class FleetComposite:Car,Icar
{
    private List<Car> _cars;
    public FleetComposite(string name,int price):base(name,price)
    {
        _cars = new List<Car>();
    }

    public void Add(Car car)
    {
        _cars.Add(car);

    }
    public void Remove(Car car)
    {
        _cars.Remove(car);
    }

    public override int CalculatePrice()
    {   int total  = 0; 

        System.Console.WriteLine($"name : {name} price {price} ");

        foreach(var item in _cars)
        {
            total += item.CalculatePrice();
        }   
        return total;
    }     
    
}


//leaf 

public class SingleCar:Car
{
    public SingleCar(string name,int price):base(name,price)
    {

    }

    public override int CalculatePrice()
    {
         System.Console.WriteLine($" the price {price } of {name}");

         return price;
    }
//client

}

public class Client
{
    public Client()
    {
        var sc = new SingleCar("mercedes", 1000);
        System.Console.WriteLine(sc.CalculatePrice());
        var fleet = new FleetComposite("vermeiren",0);
        var range = new SingleCar("range",500);
        fleet.Add(sc);
        fleet.Add(range);
       
         System.Console.WriteLine(fleet.CalculatePrice());
    }
}

}


