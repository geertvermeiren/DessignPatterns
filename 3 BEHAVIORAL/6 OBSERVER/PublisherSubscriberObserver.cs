using System;
using System.Collections.Generic;


namespace PublisherSubscriberObserver
{
    public class Subject:ISubject
{
  private List<Observer> observers = new List<Observer>();
  private int _int;
  public int Inventory
  {
    get
    {
       return _int;
    }
    set
    {
       // Just to make sure that if there is an increase in inventory then only we are notifying 
        // the observers.
          if (value > _int)
             Notify();
          _int = value;
    }
  }
  public void Subscribe(Observer observer)
  {
     observers.Add(observer);
  }

  public void Unsubscribe(Observer observer)
  {
     observers.Remove(observer);
  }

  public void Notify()
  {
     observers.ForEach(x => x.Update());
  }
}

interface ISubject
{
   void Subscribe(Observer observer);
   void Unsubscribe(Observer observer);
   void Notify();
}
public class Observer:IObserver
{
  public string ObserverName { get;private set; }
  public Observer(string name)
  {
    this.ObserverName = name;
  }
  public void Update()
  {
    Console.WriteLine("{0}: A new product has arrived at the store",this.ObserverName);
  }
}

interface IObserver
{
  void Update();
}

public class Client
{
    public Client()
    {
         Subject subject = new Subject();
        // Observer1 takes a subscription to the store
        Observer observer1 = new Observer("Observer 1");
        subject.Subscribe(observer1);
        // Observer2 also subscribes to the store
        subject.Subscribe(new Observer("Observer 2"));
        subject.Inventory++;
        // Observer1 unsubscribes and Observer3 subscribes to notifications.
        subject.Unsubscribe(observer1);
        subject.Subscribe(new Observer("Observer 3"));
        subject.Inventory++;
        Console.ReadLine();
    }
}


}