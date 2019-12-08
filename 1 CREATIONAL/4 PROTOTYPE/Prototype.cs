using System;

//copy - clone a class withoud code depencency

namespace Proto
{
    public class Person
    {
        public int Age { get; set; }
        public string Name { get; set; }
        public string MyProperty { get; set; }
        public IdInfo IdInfo { get; set; }

        public Person ShallowCopy()
        {
            return (Person) this.MemberwiseClone();

        }

        public Person DeepCopy()
        {
            Person clone = (Person) this.MemberwiseClone();
            clone.IdInfo = new IdInfo(IdInfo._idNumber);
            clone.Name = string.Copy(Name);
            return clone;
        }
    }

    public class IdInfo
    {
        public int _idNumber;

        public IdInfo(int idNumber)
        {
            this._idNumber = idNumber;

        }
    }

}