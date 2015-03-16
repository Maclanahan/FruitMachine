using System;
using UnityEngine;
using System.Collections;


class VerticalCameraZone : CameraZone
{
    public float xPivotPosition;

    public void OnTriggerEnter(Collider other)
    {
        //print("Verticle Area");
        if (other.gameObject.tag == "Hero")
        {
            this.behavior = new VerticalCamera(xPivotPosition, other.gameObject.transform, cameraHolder.transform);

            cameraHolder.GetComponent<HeroFollower>().changeBehavior(this.behavior);
        }
    }

}

