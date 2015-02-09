using UnityEngine;
using System.Collections;
using UnityEngine.UI;

[System.Serializable]
public class Item : MonoBehaviour
{
    public string name;
    public int ID;
    public string desc;
    public Sprite icon;
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
        icon = Resources.Load<Sprite>("ItemIcons/" + name);
        type = _type;
    }
}
