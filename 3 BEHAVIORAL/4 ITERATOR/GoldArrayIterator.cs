using System;
using System.Collections.Generic;

namespace GoldArrayIterator
{
    public class GoldArray
{
    private List<ItemContents> goldList = new List<ItemContents>();
    public int Add(string name, string description)
    {
        goldList.Add(new ItemContents(name, description));
        return goldList.Count;
    }
    public int Add(ItemContents itemContents)
    {
        goldList.Add(itemContents);
        return goldList.Count;
    }
    public ItemContents GetItem(int index)
    {
        if (index < goldList.Count)
        {
            return goldList[index];
        }
        else
        {
            return null;
        }
    }
    public List<ItemContents> GetItems()
    {
        return goldList;
    }
    public bool RemoveItem(int index)
    {
        if (index < goldList.Count)
        {
            goldList.RemoveAt(index);
            return true;
        }
        else
        {
            return false;
        }
    }
}

public class ItemContents
{
    public string Name;
    public string Description;
    public ItemContents(string name, string description)
    {
        Name = name;
        Description = description;
    }
    public override string ToString()
    {
        return Name + " - " + Description;
    }
}

public class Client
{
    public Client()
    {
        GoldArray MyGold = new GoldArray();
    MyGold.Add(new ItemContents("Gold Bar", "A shiny golden bar."));
    MyGold.Add(new ItemContents("Golden Coin", "A brand new coin."));
    MyGold.Add(new ItemContents("Golden Statue", "A fine golden figurine."));
    // Using no iterator.
    List<ItemContents> items = MyGold.GetItems();
    foreach (ItemContents item in items)
    {
        Console.WriteLine(item);
    }

    }
}


}
