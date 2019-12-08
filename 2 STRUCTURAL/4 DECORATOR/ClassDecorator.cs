using System;
using System.Collections.Generic;
using System.Linq;

//add aditional dynamic behavior to by placing them in an object inside a special wrapper

namespace ClassDecorator
{
    public class Class
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }

    //Component

    public  abstract class BasicClass
    {
        public List<Class> basicClass = new List<Class>
        {
               new Class{Id=1, Name = "student 1"}, 
               new Class{Id=2, Name = "student 2"}, 
               new Class{Id=3, Name = "student 3"}, 
               new Class{Id=4, Name = "student 4"}, 

        };
         public abstract int StudentCount();
    }

    //concretecomponent: component

    public class ClassSetup: BasicClass 
    {
        public override int StudentCount()
        {
            return basicClass.Count();
        }
    } 

    //decorator

    public class ClassDecorator:BasicClass
    {
        BasicClass _basicClass;

        public ClassDecorator(BasicClass basicClass)
        {
            this._basicClass = basicClass;
        }
        
        public override int StudentCount()
        {
            return _basicClass.StudentCount();
        }

    }

    //concretedecorator: decorator

    public class ConcreteAditionalClass:ClassDecorator
    {
            public ConcreteAditionalClass(BasicClass basicClass):base(basicClass)
            {                
            }

            public override int StudentCount()
            {
                var additional = base.StudentCount();
                return additional + 5;
            }
        }
    // client

    public class Client
    {
        public Client()
        {
            var clsp = new ClassSetup();
            System.Console.WriteLine(clsp.StudentCount());
            var cac = new ConcreteAditionalClass(clsp);
            System.Console.WriteLine("*****");
            System.Console.WriteLine(cac.StudentCount());


            
        }


    }





}

