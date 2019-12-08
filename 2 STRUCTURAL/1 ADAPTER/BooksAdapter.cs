using System;
using System.Collections.Generic;
using Arr;

namespace BooksAdap
{
    //itarget
    public interface ITarget
    {
        List<string> GetBooks();        
    }

    //Adaptee = array

    //client = class that cannot be changed
    public class BooksClient
    {       
         ITarget _nameSource;
         public BooksClient(ITarget nameSource)
         {
             _nameSource = nameSource;             
         }

         public void DisplayBooks()
         {
             List<string> favoriteBooks = _nameSource.GetBooks();           
            foreach(var item in favoriteBooks)
            System.Console.WriteLine(item);       
         }


    }


    //Adapter = class that must form a connecter between adaptee and client using itarget


    public class BooksAdapter:MyBooks,ITarget
    {
        public List<string> GetBooks()
        {
            List<string> familyBooks = new List<string>();
            string[] myBooks = GetMyFamilyBooks(); 

            foreach(var items in myBooks)
            {
                familyBooks.Add(items);

            }
            return familyBooks;
        }

    }

    public class AccessClient
    {
         public AccessClient()
        {
            ITarget target = new BooksAdapter();
            var c = new BooksClient(target);
            c.DisplayBooks();

        }
    }


}