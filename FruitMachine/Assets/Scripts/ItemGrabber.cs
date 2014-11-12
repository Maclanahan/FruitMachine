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
            inventory.AddItem(other.gameObject.GetComponent<ItemHolder>().ID);
            //inventory.AddItem(1);
            print("added");
            Destroy(other.gameObject);
        }
    }

    public void OnTriggerExit(Collider other)
    {

    }
}
