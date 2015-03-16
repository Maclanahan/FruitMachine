using UnityEngine;
using System.Collections;

public abstract class CameraZone : MonoBehaviour 
{
    public Camera cameraHolder;
    protected ICameraBehavior behavior;
    public float height;
    public float distance;
    public Vector3 destination;

}
