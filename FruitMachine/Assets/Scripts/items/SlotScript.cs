using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class SlotScript : MonoBehaviour, IDragHandler, IBeginDragHandler, IEndDragHandler, IDropHandler
{
    public Image image;

    private Item item;

    private Selector select;
    
    private int slotNumber;
    
    public void Start()
    {
        image = gameObject.transform.GetChild(0).GetComponent<Image>();
        image.GetComponent<CanvasGroup>().alpha = 0;

    }

    public void setItem(Item _item)
    {
        item = _item;

        if (!item.isItemEmpty())
        {
            //print(item.name);
            image.sprite = item.icon;
            image.GetComponent<CanvasGroup>().alpha = 1;
            //image.enabled = true;
            //print(image.ToString());
        }
    }

    public void setSelector(Selector _select)
    {
        select = _select;
    }

    public void setSlotNumber(int num)
    {
        if(num >= 0)
            slotNumber = num;
    }

    public bool isEmpty()
    {
        return item.isItemEmpty();
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        if(!item.isItemEmpty())
        {
            select.takeItem(item, slotNumber);
        }
    }

    public void OnDrag(PointerEventData eventData)
    {
        
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        select.clear();
    }

    public void OnDrop(PointerEventData eventData)
    {
        Item tempItem = select.setItem();
        if(!tempItem.isItemEmpty() && item.isItemEmpty())
        {
            this.setItem(tempItem);
            //select.swap()
            select.clear();
        }
       
    }
    
    /*
	// Use this for initialization
	void Start () 
    {
        inventory = GameObject.FindGameObjectWithTag("Inventory").GetComponent<Inventory>();
        itemImage = gameObject.transform.GetChild(0).GetComponent<Image>();
	}
	
	// Update is called once per frame
	void Update () 
    {
        if (inventory.Items[slotNumber].name != null)
        {
            itemImage.enabled = true;
            itemImage.sprite = inventory.Items[slotNumber].icon;
        }
        else
            itemImage.enabled = false;

	}

    public void OnPointerDown(PointerEventData data)
    {
        if(inventory.Items[slotNumber].name == null && inventory.draggingItem)
        {
            inventory.Items[slotNumber] = inventory.draggedItem;
            inventory.closedDraggedItem();
        }

        else if (inventory.Items[slotNumber].name != null && inventory.draggingItem)
        {
            inventory.Items[inventory.indexOfDraggedItem] = inventory.Items[slotNumber];
            inventory.Items[slotNumber] = inventory.draggedItem;
            inventory.closedDraggedItem();
        }
    }

    public void OnPointerEnter(PointerEventData data)
    {
        if (inventory.Items[slotNumber].name != null && !inventory.draggingItem)
            inventory.showToolTip(inventory.Slots[slotNumber].GetComponent<RectTransform>().localPosition, inventory.Items[slotNumber]);
    }

    public void OnPointerExit(PointerEventData data)
    {
        if (inventory.Items[slotNumber].name != null)
             inventory.closeToolTip();

    }

    public void OnDrag(PointerEventData data)
    {
        if (inventory.Items[slotNumber].name != null)
        {
            inventory.showDraggedItem(inventory.Items[slotNumber], slotNumber);
            inventory.Items[slotNumber] = new Item();
        }
            
    }

    */
}
