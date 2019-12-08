using System;
using System.Collections.Generic;

namespace CompositeArmy
{
    //component

    public abstract class Army
    {
        public string _rank;
        public int _stars;

        public Army(string rank, int stars)
        {
            this._rank = rank;
            this._stars = stars;

        }

        public abstract int TotalStars();
    }

    public interface ArmyOperations
    {
        void Add(Army army);
        void Remove(Army army);
    }

    //composite

    public class ArmyComposite:Army,ArmyOperations
    {
        public List<Army> _army;

        public ArmyComposite(string  rank, int stars):base(rank,stars)
        {
            this._army = new List<Army>();

        }
        public void Add(Army army)
        {
            _army.Add(army);

        }
        public void Remove(Army army)
        {
            _army.Remove(army);

        }

        public override int TotalStars()
        {
            int total = 0; 
            System.Console.WriteLine($"stars : {_stars}  rank  {_rank} ");

            foreach(var item in _army)
            {
                total += item.TotalStars();

            }

            return total;

        }

    }

    //leaf

    public class SingleLevel:Army
    {
        public SingleLevel(string rank,int stars):base(rank,stars)
        {

        }

        public override int TotalStars()
        {
            return _stars;
        }
    }

    //client

    public class Client
    {
        public Client()
        {
            var sl = new SingleLevel("soldier",1);
            System.Console.WriteLine(sl.TotalStars());

            var ac = new ArmyComposite("Belgium", 0);
            var gen = new SingleLevel("genelar",5);
            var maj = new SingleLevel("major", 3);
            ac.Add(gen);
            ac.Add(sl);
            ac.Add(maj);
            System.Console.WriteLine(ac.TotalStars());
            
        }
    }


}
