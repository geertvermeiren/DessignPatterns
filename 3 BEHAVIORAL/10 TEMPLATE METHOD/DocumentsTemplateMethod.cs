using System;
using System.Collections.Generic;

namespace DocumentsTemplateMethod
{
    //abstract class
    public abstract class AbstractClass
    {

        public void TemplateMethod()
        {
            this.PointToDocument();
            this.OpenStream();
            this.ReadStream();
            this.DeCryptDocument();
            this.LoadDocument();
            this.Print();

        }
        protected void PointToDocument()
        {
        System.Console.WriteLine("this is the route to the document");
        }
        protected void LoadDocument()
        {
            System.Console.WriteLine("load document in memory");
        }
        protected abstract void OpenStream();

        protected abstract void ReadStream();

        protected virtual void DeCryptDocument()
        {
        }
        protected virtual void Display()
        {
            System.Console.WriteLine("displaying on screen..");
        }

        protected virtual void Print(){}

        

    }

    //concrete1 class
    public class PdfFile:AbstractClass
    {
        protected override void ReadStream()
        {
            System.Console.WriteLine($"{this.GetType().Name}: reading the file ");
        }
        protected override void OpenStream()
        {
            System.Console.WriteLine($"{this.GetType().Name} : opening the file");
        }
       
    } 

    //concrete class 2
    public class WordFile:AbstractClass
    {
        protected override void ReadStream()
        {
            System.Console.WriteLine($"{this.GetType().Name}: reading the file ");
        }
        protected override void OpenStream()
        {
            System.Console.WriteLine($"{this.GetType().Name} : opening the file");
        }

        protected override void Print()
        {
            System.Console.WriteLine("printing ...");
        }

    }

   
   
    //client class
    public class Client
    {
         public Client()
         {
             ClientCode(new PdfFile());
             System.Console.WriteLine("*********");
            ClientCode(new WordFile());
         }
         public void ClientCode(AbstractClass abstractClass)
         {
             abstractClass.TemplateMethod();
         }
    }
}