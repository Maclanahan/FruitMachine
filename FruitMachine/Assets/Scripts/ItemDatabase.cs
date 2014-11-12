using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ItemDatabase : MonoBehaviour 
{
    public List<Item> itemDatabase = new List<Item>();

    void Start()
    {
        setUpItems();
    }

    private void setUpItems()
    {
        itemDatabase.Add(new Item("guy", 1, "It's a dude.", Item.ItemType.Consumable));

        itemDatabase.Add(new Item("ball", 2, "A naturally nutricious treat!", Item.ItemType.Consumable));
    }


    public Item getItem(int ID)
    {
        for (int i = 0; i < itemDatabase.Count; i++)
        {
            if (itemDatabase[i].ID == ID)
                return itemDatabase[i];
        }

            return null;
    }

    public Item getItem(string Name)
    {
        for (int i = 0; i < itemDatabase.Count; i++)
        {
            if (itemDatabase[i].name.ToLower() == name.ToLower())
                return itemDatabase[i];
        }

        return null;
    }
}
