using System;

namespace ComputerBuilder
{
    //interface
    public interface IBuilder
    {
        void BuildMotherBoard();

        void  BuildMonitor();

        void BuildCase();

        Computer GetComputer();
        
    }

    //concretebuilder

    public class BuildComputer:IBuilder
    {
        Computer _computer = new Computer();

        public void BuildMotherBoard()
        {
            _computer.MotherBoard = "building the motherboard";
        }
        public void BuildMonitor()
        {
            _computer.Monitor = "building the monitor";
        }
        public void BuildCase()
        {
            _computer.Case = "building the case";
        }

        public Computer GetComputer()
        {
            return _computer;
        }
    }

    //product

    public class Computer
    {
        public string MotherBoard { get; set; }
        public string Monitor { get; set; }
        public string Case { get; set; }

        public void showInfo()
        {
            System.Console.WriteLine("motherboard {0}", MotherBoard);
            System.Console.WriteLine("monnitor {0}", Monitor);
            System.Console.WriteLine("cas {0}", Case);

        }
        
    }


    //director

    public class ComputerDirector
    {
        private readonly IBuilder _computer;

        public ComputerDirector(IBuilder computer)
        {
           this._computer = computer;
        }

        public void CreateComputer()
        {
            _computer.BuildCase();
            _computer.BuildMotherBoard();
            _computer.BuildMonitor();

        }

        public Computer GetComputer()
        {
            return _computer.GetComputer();
        }

    }

    //client

    public class ComputerClient
    {
        public ComputerClient()
        {
            var director = new ComputerDirector(new BuildComputer());
            director.CreateComputer();
            var computer = director.GetComputer();
            computer.showInfo();
        }

    }





}