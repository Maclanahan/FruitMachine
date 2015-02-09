using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class SlotScript : MonoBehaviour, IPointerDownHandler, IPointerEnterHandler, IPointerExitHandler 
{

    public Item item;
    Image itemImage;
    public int slotNumber;
    Inventory inventory;
    

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
        Debug.Log("Clicked");
    }

    public void OnPointerEnter(PointerEventData data)
    {
        if (inventory.Items[slotNumber].name != null)
            inventory.showToolTip(inventory.Slots[slotNumber].GetComponent<RectTransform>().localPosition, inventory.Items[slotNumber]);
    }

    public void OnPointerExit(PointerEventData data)
    {
        if (inventory.Items[slotNumber].name != null)
             inventory.closeToolTip();

    }
    
}
