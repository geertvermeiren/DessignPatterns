using System;
using System.Collections.Generic;

namespace SchoolVisitor
{
    //the element
    public abstract class Element
    {
        public abstract void Accept(IVisitor visitor);
    } 

    //the concrete element

    public class School: Element
    {
        public int Students { get; set; }

        public School(int students)
        {
            this.Students = students;
        }
        public override void Accept(IVisitor visitor)
        {
            visitor.Visit(this);
        }


    }
    //the visitor
    public interface IVisitor
    {
         void Visit (Element element);
    }

    //the concrete visitor

    public class Students:IVisitor
    {
        public void Visit(Element element)
        {
            School school = element as School;
            school.Students += 300;
            System.Console.WriteLine($"there are {school.Students} students ");

        }
    }

    //the object structure 
    public class Schools
    {
        public List<School> _school = new List<School>();
        
        public void Attach(School school)
        {
            _school.Add(school);
        }

        public void Detach(School school)
        {
            _school.Remove(school);
        }

        public void Accept(IVisitor visitor)
        {
            foreach(School s in _school )
            {
                s.Accept(visitor);
            }
        }
    }
    public class PublicSchool:School
    {
        public PublicSchool():base(3000){}
        
    }
    public class PrivateSchool:School
    {
        public PrivateSchool():base(1000){}
    }

    
    //client class
    public class Client
    {
         public Client()
         {
             Schools s = new Schools();
             s.Attach(new PrivateSchool());
             s.Accept(new Students());
         
         }
    }
}