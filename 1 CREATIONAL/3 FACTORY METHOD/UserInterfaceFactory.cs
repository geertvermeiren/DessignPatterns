using System;
using System.Collections.Generic;

namespace UserInterfaceFactory
{
    //creator

    public abstract class Dialog
    {
        public abstract IButton CreateButton();
        
    }
    

    //concrete creator

    public class WindowDialog:Dialog
    {
        public override IButton CreateButton()
        {
            return new WindowButton();
        }
    }

    //product

    public class MacDialog:Dialog
    {
        public override IButton CreateButton()
        {
            return new MacButton();
        }
    }

    //concrete product

    public interface IButton
    {
        string Operate();
    }

    public class WindowButton:IButton
    {
        public string Operate()
        {
           return $"this is a  {this.GetType().Name}";
        }
    }

    public class MacButton:IButton
    {
        public string Operate()
        {

           return $"this is a  {this.GetType().Name}";
            
        }
    }
    
    //client class
    public class Client
    {
        
         public Client()
         {
           //  System.Console.ReadLine();
           System.Console.WriteLine("NEW MAC BUTTON");
           Clientcode(new MacDialog());
            
         }

         public void Clientcode(Dialog dialog)
         {
             System.Console.WriteLine($" wat kan ik in de dialog zien? {dialog.CreateButton().Operate()}");

         }
    }
}