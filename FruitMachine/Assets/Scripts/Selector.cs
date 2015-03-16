using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class Selector : MonoBehaviour 
{
    private List<GameObject> _inventorySlots = new List<GameObject>();
    private Inventory inventory;

    private Item heldItem;
    private int itemStartSlot;
    private Image dragIcon;

	// Use this for initialization
	void Start () 
    {
        inventory = GameObject.FindGameObjectWithTag("Inventory").GetComponent<Inventory>();
        dragIcon = this.gameObject.GetComponent<Image>();

        _inventorySlots = inventory.getSlots();
	}

    void Update()
    {
        if(dragIcon.GetComponent<CanvasGroup>().alpha == 1)
        {
            dragIcon.GetComponent<RectTransform>().position = new Vector3(Input.mousePosition.x + 25, Input.mousePosition.y - 25, 0);
        }
    }
	
    public void takeItem(Item item, int slotNum)
    {
        heldItem = item;
        itemStartSlot = slotNum;
        dragIcon.sprite = heldItem.icon;
        dragIcon.GetComponent<CanvasGroup>().alpha = 1;
    }

    public Item setItem()
    {
        if (!heldItem.isItemEmpty())
            return heldItem;

        else
            return new Item();
    }

    public int setNumber()
    {
        if (!heldItem.isItemEmpty())
            return itemStartSlot;
        else
            return -1;
    }

    public void clear()
    {
        heldItem = new Item();
        itemStartSlot = -1;
        dragIcon.GetComponent<CanvasGroup>().alpha = 0;

    }
}
