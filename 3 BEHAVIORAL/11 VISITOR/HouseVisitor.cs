using System;
using System.Collections.Generic;

namespace HouseVisitor
{

    // element abstract class

    public abstract class Element
    {
        public abstract void Accept(IVisitor visitor);
    }
     public class House:Element
    {
        public int Rooms { get; set; }

        public House(int rooms)
        {
            this.Rooms = rooms;
        }

        public override void Accept(IVisitor visitor)
        {
            visitor.Visit(this);
        } 
     
     
    }

    //visitor interface

    public interface IVisitor
    {
         void Visit (Element element);
    }

    // concrete visitor
    public class RoomsVisitor:IVisitor
    {
        public void Visit(Element element)
        {
             House house = element as House;
             house.Rooms += 1;
             System.Console.WriteLine($"the {this.GetType().Name} has {house.Rooms} rooms");
             
        }

        
    }

    public class Houses
    {
        public List<House> _house = new List<House>();
        public void Attach(House house)
        {
            _house.Add(house);

        }
        public void Detach(House house)
        {
            _house.Remove(house);
        }
        public void Accept(IVisitor visitor)
        {
            foreach(House e in _house )
            {
                e.Accept(visitor);
            }
            Console.WriteLine();
        }

    }

    public class Villa:House
    {
        public Villa():base(10)
        {

        }
    }

    public class TownHouse:House
    {
        public TownHouse():base(6){}
    }

    public class Mansion:House
    {
        public Mansion():base(50)
        {

        }
    }


    //client class
    public class Client
    {
         public Client()
         {
             Houses houses = new Houses();
             houses.Attach(new Villa());
             houses.Attach(new TownHouse());
             houses.Attach(new Mansion());

             houses.Accept(new RoomsVisitor());
         
         }
    }
}