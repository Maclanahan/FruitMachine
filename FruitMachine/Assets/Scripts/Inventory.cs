using UnityEngine;
using System.Collections;
using System.Collections.Generic;
public class Inventory : MonoBehaviour 
{
    public List<Item> inventory = new List<Item>();
    
    public int slotsX;
    public int slotsY;

    public GUISkin skin;

    public List<Item> slots = new List<Item>();

    private ItemDatabase database;

    private bool showInvetory = false;

	// Use this for initialization
	void Start () 
    {
        for (int i = 0; i < (slotsX * slotsY); i++)
        {
            slots.Add(new Item());
            inventory.Add(new Item());
        }

        database = GameObject.FindGameObjectWithTag("ItemDatabase").GetComponent<ItemDatabase>();

        inventory[0] = database.itemDatabase[0];
        inventory[1] = database.itemDatabase[1];
        
	}

    void Update()
    {
        if(Input.GetButtonDown("Inventory"))
        {
            showInvetory = !showInvetory;

        }
    }

    void OnGUI()
    {
        GUI.skin = skin;

        if(showInvetory)
        {
            DrawInventory();
        }

       
    }

    void DrawInventory()
    {
        int i = 0;
        for (int y = 0; y < slotsY; y++)
        {
            for (int x = 0; x < slotsX; x++)
            {
                Rect slotRect = new Rect(x * 60, y * 60, 50, 50);
                GUI.Box(slotRect, "", skin.GetStyle("Slot"));

                slots[i] = inventory[i];

                if(slots[i].ID != null)
                {
                    GUI.DrawTexture(slotRect, slots[i].icon);
                }


                i++;
            }
        }
    }
}
