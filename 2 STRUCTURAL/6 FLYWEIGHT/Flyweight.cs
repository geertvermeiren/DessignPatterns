using System;
using System.Collections.Generic;

namespace Flyweight
{

    //flyweight
     public class TreeType
    {
        public string _name;
        public string _color;
        public string _texture;

        public TreeType(string name,string color,string texture)
        {
            this._color = color;
            this._name = name;
            this._texture = texture;
        }  

        public void Draw()
        {

            System.Console.WriteLine( $"drawing {_color}");

        }

        
    }
    //flyweight factory






    

    //client class
    public class FlyweightClient
    {
         public FlyweightClient()
         {
         
         }
    }
}