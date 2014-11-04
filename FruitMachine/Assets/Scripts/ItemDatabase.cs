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
}
