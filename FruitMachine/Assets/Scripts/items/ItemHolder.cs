using UnityEngine;
using System.Collections;

public class ItemHolder : MonoBehaviour {

    public int ID;

    protected ItemDatabase database;
    protected Item item;

	// Use this for initialization
	void Start () 
    {
        database = GameObject.FindGameObjectWithTag("ItemDatabase").GetComponent<ItemDatabase>();

        item = database.getItem(ID);
	}
	
	// Update is called once per frame
	void Update () 
    {
	
	}
}
