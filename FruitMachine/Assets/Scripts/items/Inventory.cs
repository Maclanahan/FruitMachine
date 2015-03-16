using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
public class Inventory : MonoBehaviour 
{
    public GameObject slotPrefab;
    public Selector select;

    private ItemDatabase database;
    private List<GameObject> _inventorySlots = new List<GameObject>();


    public void Start()
    {
        database = GameObject.FindGameObjectWithTag("ItemDatabase").GetComponent<ItemDatabase>();
        //select = GameObject.FindGameObjectWithTag("Selector").GetComponent<Selector>();

        setUpSlots();

        //addItem(2);
    }

    private void setUpSlots()
    {
        int slotNum = 0;

        for(int i = 0; i < 5; i++)
        {
            for(int j = 0; j < 5; j++)
            {
                GameObject slot = (GameObject)Instantiate(slotPrefab);
                slot.GetComponent<SlotScript>().setItem(new Item());
                slot.GetComponent<SlotScript>().setSelector(select);
                slot.GetComponent<SlotScript>().setSlotNumber(slotNum);

                slot.transform.parent = this.gameObject.transform;
                slot.name = "slot" + i + ", " + j;
                slot.GetComponent<RectTransform>().localPosition = new Vector3(180 + (60 * i), 160 - (60 * j), 0);

                _inventorySlots.Add(slot);
                slotNum++;
            }
        }
    }

    public bool addItem(int ID)
    {
        for (int i = 0; i < _inventorySlots.Count; i++ )
        {
            if (_inventorySlots[i].GetComponent<SlotScript>().isEmpty())
            {
                //print(ID);
                _inventorySlots[i].GetComponent<SlotScript>().setItem(database.getItem(ID));
                return true;
            }
        }


        return false;
    }

    public List<GameObject> getSlots()
    {
        return _inventorySlots;
    }

    /*
    public List<GameObject> Slots = new List<GameObject>();
    public List<Item> Items = new List<Item>();

    public List<GameObject> SpellSlots = new List<GameObject>();
    public List<Item> SpellItems = new List<Item>();

    ItemDatabase database;
    
    public GameObject slots;
    public GameObject toolTip;
    int x = 180;
    int y = 160;
    private bool isVisible = false;
    public GameObject draggedItemgameObject;
    public bool draggingItem = false;
    public Item draggedItem;
    public int indexOfDraggedItem;
    private int slotAmount = 0;


    void Start()
    {
        database = GameObject.FindGameObjectWithTag("ItemDatabase").GetComponent<ItemDatabase>();

        setUpSpellSlots();
        setupInventory();

        //addItem(1);
    }

    private void setUpSpellSlots()
    {
        //int slotAmount = 0;

        for(int i = 0; i < 3; i++)
        {
            GameObject slot = (GameObject)Instantiate(slots);
            slot.GetComponent<SlotScript>().slotNumber = slotAmount;
            SpellSlots.Add(slot);

            SpellItems.Add(new Item());
            slot.transform.parent = this.gameObject.transform;
            slot.name = "spellslot" + i;
            slot.GetComponent<RectTransform>().localPosition = new Vector3(-280 + (60 * i), y, 0);

            slotAmount++;
        }
    }


    private void setupInventory()
    {
        slotAmount = 0;

        for (int i = 0; i < 6; i++)
        {
            for (int j = 0; j < 5; j++)
            {
                GameObject slot = (GameObject)Instantiate(slots);
                slot.GetComponent<SlotScript>().slotNumber = slotAmount;
                Slots.Add(slot);

                Items.Add(new Item());
                slot.transform.parent = this.gameObject.transform;
                slot.name = "slot" + i + "," + j;
                slot.GetComponent<RectTransform>().localPosition = new Vector3(x + (60 * j), y - (60 * i), 0);

                slotAmount++;
            }
        }
    }

    void Update()
    {
        if (draggingItem)
        {
            Vector3 position = (Input.mousePosition - GameObject.FindGameObjectWithTag("Canvas").GetComponent<RectTransform>().localPosition);
            draggedItemgameObject.GetComponent<RectTransform>().localPosition = new Vector3(position.x + 25, position.y - 25, position.z);
        }

        if (Input.GetButtonDown("Inventory"))
        {
            print("Button Pressed");
            if (isVisible)
            {
                this.gameObject.GetComponent<CanvasGroup>().alpha = 0;
                isVisible = false;
            }

            else
            {
                this.gameObject.GetComponent<CanvasGroup>().alpha = 1;
                isVisible = true;
            }
        }

        
    }

    public void addItem(int id)
    {
        for(int i = 0; i < database.itemDatabase.Count; i++)
        {
            if(database.itemDatabase[i].ID == id)
            {
                Item item = database.itemDatabase[i];
                
                addItemAtEmptySlot(item);
                break;
            }

        }
    }

    private void addItemAtEmptySlot(Item item)
    {
        for(int i = 0; i < Items.Count; i++)
        {
            if(Items[i].name == null)
            {
                Items[i] = item;
                break;
            }

        }
    }

    public void showToolTip(Vector3 toolPosition, Item item)
    {
        toolTip.SetActive(true);
        //toolTip.GetComponent<RectTransform>().localPosition = new Vector3(toolPosition.x, toolPosition.y);
    }

    public void closeToolTip()
    {
        toolTip.SetActive(false);
    }

    public void showDraggedItem(Item item, int slotNumber)
    {
        indexOfDraggedItem = slotNumber;
        //draggedItemgameObject.SetActive(true);
        GameObject.FindGameObjectWithTag("DraggingItem").GetComponent<CanvasGroup>().alpha = 1;
        draggedItem = item;
        draggingItem = true;
        draggedItemgameObject.GetComponent<Image>().sprite = item.icon;
    }

    public void closedDraggedItem()
    {
        draggingItem = false;
        GameObject.FindGameObjectWithTag("DraggingItem").GetComponent<CanvasGroup>().alpha = 0;

    }


    /*
    public List<Item> inventory = new List<Item>();
    
    public int slotsX;
    public int slotsY;

    public GUISkin skin;

    public List<Item> slots = new List<Item>();

    private ItemDatabase database;

    private bool showInvetory = false;
    private bool showToolTip = false;
    private bool draggingItem;
    private Item draggedItem;
    private int previousIndex;


    private string tooltip = "";

	// Use this for initialization
	void Start () 
    {
        for (int i = 0; i < (slotsX * slotsY); i++)
        {
            slots.Add(new Item());
            inventory.Add(new Item());
        }

        database = GameObject.FindGameObjectWithTag("ItemDatabase").GetComponent<ItemDatabase>();
        
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
        tooltip = "";
        GUI.skin = skin;

        if(showInvetory)
        {
            DrawInventory();

            if (showToolTip)
            {
                GUI.Box(new Rect(Event.current.mousePosition.x, Event.current.mousePosition.y, 100, 50), tooltip, skin.GetStyle("ToolTip"));
            }

            
        }

        if (draggingItem && draggedItem.icon)
        {
            GUI.DrawTexture(new Rect(Event.current.mousePosition.x, Event.current.mousePosition.y, 50, 50), draggedItem.icon);
        }
        
        

        
    }

    void DrawInventory()
    {
        Event e = Event.current;

        int i = 0;
        for (int y = 0; y < slotsY; y++)
        {
            for (int x = 0; x < slotsX; x++)
            {
                Rect slotRect = new Rect(x * 60, y * 60, 50, 50);
                GUI.Box(slotRect, ""/*, skin.GetStyle("Slot")*///);
    /*

                slots[i] = inventory[i];

                if (slots[i].ID != null)
                {
                    if (slots[i].icon)
                        GUI.DrawTexture(slotRect, slots[i].icon);

                    if (slotRect.Contains(Event.current.mousePosition) && slots[i].icon != null)
                    {
                        tooltip = CreateToolTip(slots[i]);
                        showToolTip = true;

                        if (e.button == 0 && e.type == EventType.mouseDrag && draggingItem == false)
                        {
                            draggingItem = true;
                            previousIndex = i;
                            draggedItem = slots[i];
                            inventory[i] = new Item();

                        }

                        if (e.type == EventType.mouseUp && draggingItem)
                        {
                            inventory[previousIndex] = inventory[i];
                            inventory[i] = draggedItem;
                            draggingItem = false;
                            draggedItem = null;
                        }
                    }

                    else
                    {
                        if (slotRect.Contains(Event.current.mousePosition))
                        {
                            if (e.type == EventType.mouseUp && draggingItem)
                            {
                                inventory[i] = draggedItem;
                                draggingItem = false;
                                draggedItem = null;
                            }
                        }
                    }
                }

                

                if (tooltip == "")
                {
                    showToolTip = false;
                }

                i++;
            }
        }

        
    }

    string CreateToolTip(Item item)
    {
        tooltip = "<color=#ffffff>" +item.name + "</color>\n";

        return tooltip;
    }

    public void AddItem(int id)
    {
        for (int i = 0; i < inventory.Count; i++)
        {
            if (inventory[i].name == null)
            {
                for (int j = 0; j < database.itemDatabase.Count; j++)
                {
                    if (database.itemDatabase[j].ID == id)
                    {
                        inventory[i] = database.itemDatabase[j];
                    }
                }

                break;
            }
        }
    }

    public void RemoveItem(int id)
    {
        for (int i = 0; i < inventory.Count; i++)
        {
            if (inventory[i].ID == id)
            {
                inventory[i] = new Item();
                break;
            }
        }
    }

    bool InventoryContains(int id)
    {
        bool result = false;

        for (int i = 0; i < inventory.Count; i++)
        {
            result = inventory[i].ID == id;

            if (result)
                break;
        }
            return result;
    }
                                                                  * */

    
}
