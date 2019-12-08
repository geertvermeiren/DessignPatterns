using System;
using System.Text;

namespace PhraseMemento
{
    public class Phrase
    {
        StringBuilder sb = new StringBuilder();
        public void AppendWord(string word)
        {
            sb.Append(" " + word);
        }

        public void Print()
        {
            System.Console.WriteLine($"{sb} ");
        }

        public Memento CreateMemento()
        {
            Memento m = new Memento();
            m.SetState(sb);
            return m;

        }
        public void SetMemento(Memento memento)
        {
          //  this.sb.Clear();
         //   this.sb.Append( "hahah "); 
           
           this.sb = memento.GetState();


           
        }

        
        

    }

    public class Memento
    {
        StringBuilder mementoSb= new StringBuilder();

        public void SetState(StringBuilder sb)
        {
            this.mementoSb.Append(sb);

        }

        public StringBuilder GetState()
        {

            return this.mementoSb;

        }
    }

    public class Client
    {
        public Client()
        {
            Phrase p = new Phrase();
            p.AppendWord("this");
            p.AppendWord("is");
            p.AppendWord("a");
             var memento = p.CreateMemento();
            p.Print();
            System.Console.WriteLine("********");
            p.AppendWord("test");
            p.AppendWord("test");
            p.Print();
            
            System.Console.WriteLine("**memento: **");
            p.SetMemento(memento);
            p.Print();


        }
    }
}
