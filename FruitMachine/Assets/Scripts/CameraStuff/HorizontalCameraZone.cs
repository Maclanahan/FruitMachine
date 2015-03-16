using System;
using UnityEngine;
using System.Collections;


class HorizontalCameraZone : CameraZone
{
    public float zPivotPosition;

    void OnTriggerEnter(Collider other)
    {
        //print("Horizontal Area");
        if (other.gameObject.tag == "Hero")
        {
            this.behavior = new HorizontalCamera(zPivotPosition, other.gameObject.transform, cameraHolder.transform);

            cameraHolder.GetComponent<HeroFollower>().changeBehavior(this.behavior);
        }
    }

}

