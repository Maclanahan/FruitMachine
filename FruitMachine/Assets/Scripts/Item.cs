using UnityEngine;
using System.Collections;

[System.Serializable]
public class Item 
{
    public string name;
    public int ID;
    public string desc;
    public Texture2D icon;
    public ItemType type;


    public enum ItemType 
    {
        Permanent, Consumable, Quest
    }

    public Item() { }

    public Item(string _name, int _ID, string _description, ItemType _type)
    {
        name = _name;
        ID = _ID;
        desc = _description;
        icon = Resources.Load<Texture2D>("ItemIcons/" + name);
        type = _type;
    }
}
