using System;
using System.Text;

namespace StarMemento
{
    public class Star
    {
        private string starResult = "";

        public void AddStar()
        {
            starResult += "*";
        }

        public void Print()
        {
            System.Console.WriteLine(starResult);
        }

        public Memento CreateMemento()
        {
            Memento m = new Memento();
            m.SetState(starResult);
            return m;
        }

        public void SetMemento(Memento memento)
        {
            this.starResult = memento.GetState();
        }

        
    }

    public class Memento
    {
        private string state;
       public string GetState()
       {
          return this.state;
       }

       public void SetState(string state)
       {
           this.state = state;
       }


    }
    
    public class Client
    {
        public Client()
        {
            Star s = new Star();
            s.AddStar();
            s.AddStar();
            s.AddStar();
            s.AddStar();
            s.AddStar();
            s.Print();
            System.Console.WriteLine("** ** memento set");
            var m =  s.CreateMemento();
            s.AddStar();
            s.AddStar();
            s.AddStar();
            s.AddStar();
            s.AddStar();
            System.Console.WriteLine("NEW ELEMENTS");
            s.Print();
            s.SetMemento(m);
            System.Console.WriteLine("MEMENTO : UNDO");
            s.Print();


        }
    }
    
}
