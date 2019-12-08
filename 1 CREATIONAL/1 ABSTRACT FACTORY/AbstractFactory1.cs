using System;
using System.Collections.Generic;

namespace AbstractFactory1
{
    // window , mac, button, checkbox = matrix
        //abstract factory
     public interface IGuiFactory
     {
          IButton CreateButton ();
          ICheckBox CreateCheckBox ();
     }

    //abstract product
     public class WinFactory: IGuiFactory
    {
        public IButton CreateButton()
        {
            return new WindowButton();
        }
        public ICheckBox CreateCheckBox()
        {
            return new WindowsCheckBox();
        }
              
    }

    //abstract product B

    public class MacFactory: IGuiFactory
    {
        public IButton CreateButton()
        {
            return new MacButton();
        }
        public ICheckBox CreateCheckBox()
        {
            return new MacCheckBox();
        }

    }
     //interface product
    public interface IButton
    {
         string Paint();
    }

    //concrete product A
    public class WindowButton:IButton
    {
         public string Paint()
        {
           return $"creating a {this.GetType().Name}";

        }
    }

    public class MacButton:IButton
    {
       
        public string Paint()
        {
           return $"creating a {this.GetType().Name}";

        }
    }

    public interface ICheckBox
    {
         string Paint();     
         
    }
    public class WindowsCheckBox:ICheckBox
    {
        public string Paint()
        {
           return $"creating a {this.GetType().Name}";

        }
    }
    //concrete product B
    public class MacCheckBox:ICheckBox
    {
         public string Paint()
        {
           return $"creating a {this.GetType().Name}";

        }
    }


    public class Application
    {
        private IButton _button;
        private ICheckBox _checkBox;
        private IGuiFactory _factory;

        public Application(IGuiFactory guiFactory)
        {
            this._factory = guiFactory;

        }
        public void CreateUI()
        {
            this._button = _factory.CreateButton();
            this._checkBox = _factory.CreateCheckBox();
            
        }

        public void paint()
        {
            _button.Paint();
            _checkBox.Paint();
        }


    }

    //client class
    public class Client
    {      
         
         
         public Client()
         {
            var winFactory = new WinFactory();

             Application app = new Application(winFactory);
             app.CreateUI();
      
        // ClientMethod(new MacFactory());
         }

         public void ClientMethod(IGuiFactory guiFactory)
         {
             var button = guiFactory.CreateButton();
             var checkBox = guiFactory.CreateCheckBox();

            System.Console.WriteLine(button.Paint());



             

         }
    }
}