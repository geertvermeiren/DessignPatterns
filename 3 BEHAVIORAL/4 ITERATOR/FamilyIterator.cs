using System;
using System.Collections.Generic;

namespace FamilyIterator
{
    //iterator
    public interface IFamily
    {
       int Add(string position, string name);

       int Add(Family family);
       Family GetMember(int index);
        List<Family> GetAllMembers();

        
    }

    //concrete iterator

    public class FamilyIterator:IFamily
    {
        private readonly List<Family> familyList = new List<Family>();

        public int Add(string position, string name)
        {
            familyList.Add(new Family(position,name));
            return familyList.Count;
        } 

        public int Add(Family family)
        {
            familyList.Add(family);
            return familyList.Count;
        }

        public Family GetMember(int index)
        {
            if(index < familyList.Count)
            {
                return familyList[index];
            }else
            {
                return null;
            }

        }
        public List<Family> GetAllMembers()
        {
            return familyList;
        }
    }


    //aggrregator

    public class Family
    {
        public string _position;
        public string _name;

        public Family(string position,string name)
        {
            _position = position;
            _name = name;
            
        }

    }

    ///concrete aggregator

    public class Client
    {
        public Client()
        {
            FamilyIterator fi = new FamilyIterator();
            fi.Add(new Family("father", "luc"));
            fi.Add(new Family("mother", "lilian"));
            fi.Add(new Family("son", "max"));
            fi.Add(new Family("daughter", "eveline"));
            fi.Add(new Family("uncle", "john"));

            FamilyIterator fi2 = new FamilyIterator();
            fi2.Add(new Family("uncle", "keith"));
            fi2.Add(new Family("uncle", "lowel"));
            
            System.Console.WriteLine("**getallmembers**");
            var items =  fi.GetAllMembers();
            foreach(var item in items)
            {
                System.Console.WriteLine(item._name + " " + item._position);
            }

        }
    }
}
