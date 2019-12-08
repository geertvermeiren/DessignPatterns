using System;
using System.Collections.Generic;

//dynamic tree structure

namespace FamilyComposite
{
    //component
    public abstract class Family
    {
        public string name;
        public int age;

        public Family(string name,int age)
        {
            this.name = name;
            this.age = age;
        }

        public abstract int CalculateAge();
    }


    public interface IFamilyOperation
    {
        void Add(Family family);
        void Remove(Family family);
    }
    //composite
    public class CompositeFamily: Family,IFamilyOperation
    {
        public List<Family> _family;

        public CompositeFamily(string name,int age):base(name,age)
        {
            _family = new List<Family>();
            
        }

        public void Add(Family family)
        {
            _family.Add(family);

        }
        public void Remove(Family family)
        {
            _family.Remove(family);

        }
        public override int CalculateAge()
        {
        int total = 0;

        foreach(var item in _family)
        {
            total += item.CalculateAge();

        }

        return total;

        }
    } 

    //leaf

    public class SingleFamilyMember:Family
    {
        public SingleFamilyMember(string name,int age):base(name,age){}

        public override int CalculateAge()
        {
            System.Console.WriteLine($" the  age is : {age} and is the name is :{name}");
        
            return age;
        }

    }

    //client

    public class Client
    {
        public Client()
        {
            var geert = new SingleFamilyMember("geert",47);
            System.Console.WriteLine(geert.CalculateAge());

            var cf = new CompositeFamily("vermeiren", 0);
            var patrizia = new SingleFamilyMember("patrizia",44);
            var gael = new SingleFamilyMember("gael",11);
            var max = new SingleFamilyMember("max", 8);
            var olivier = new SingleFamilyMember("olivier", 8);

            cf.Add(patrizia);
            cf.Add(gael);
            cf.Add(geert);
            cf.Add(max);
            cf.Add(olivier);
           

            System.Console.WriteLine("total age : " + cf.CalculateAge());

        }
    }


}
