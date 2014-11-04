using UnityEngine;
using System.Collections;

public class HeroFollower : MonoBehaviour {

	public Transform stalkee;
	//public float distance;
	public float height;
    protected ICameraBehavior behavior;
	//public string movementBehavior;

	// Use this for initialization
	void Start () 
	{
        behavior = new HorizontalCamera(-20, stalkee, this.transform, height);
	}
	
	// Update is called once per frame
	void LateUpdate () 
	{
        behavior.behave();
	}

    public void changeBehavior(ICameraBehavior _newBehavior)
    {
        behavior = _newBehavior;
    }
}
