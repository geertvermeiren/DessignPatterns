using System;
using System.Collections.Generic;

namespace Employee2
{

    public class Empl
    {
        public string[] GetEmpl()
        {
         string[] emp = new string[4];

            for(int i = 0; i < 4; i++)
            { 
                emp[i] = i.ToString();;

            }
          

        return emp;


        }

        public void Display()
        {
            List<string> employeeList = new List<string>();
            string[] employees = GetEmpl();
            foreach(var item in GetEmpl())
            {
               employeeList.Add("test " +item);
            }
            System.Console.WriteLine("display list: ");
            foreach(var item in employeeList)
            {
                System.Console.WriteLine(item);
            }




        }


    }

}