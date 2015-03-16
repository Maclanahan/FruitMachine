using UnityEngine;
using System.Collections;

public class ItemGrabber : MonoBehaviour {


    public Collider area;
    protected Inventory inventory;

	// Use this for initialization
	void Start () 
    {
        inventory = GameObject.FindGameObjectWithTag("Inventory").GetComponent<Inventory>();

	}
	
	// Update is called once per frame
	void Update () 
    {
	    
	}

    public void OnTriggerEnter(Collider other)
    {
        //if(other.gameObject.tag == "Item")
        print(other.gameObject.tag);
    }

    public void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Item" && Input.GetButtonDown("Grab"))
        {
            inventory.addItem(other.gameObject.GetComponent<ItemHolder>().ID);
            //inventory.addItemAtEmptySlot(item);
            //print("added");
            Destroy(other.gameObject);
        }
    }

    public void OnTriggerExit(Collider other)
    {

    }
}
