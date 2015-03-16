using System;
using UnityEngine;
using System.Collections;

class HorizontalCamera : ICameraBehavior
{
    public float zPosition;

    public HorizontalCamera(float _zPivot,Transform _hero, Transform _camera, float _height = 10.0f, float _distance = -20.0f)
        : base(_hero, _camera, _height, _distance)
    {
		zPosition = _zPivot;
    }

    override public void behave()
    {
        float speed = 20f;
        //cam.position = hero.position + new Vector3(0, this.height, 0);
        //cam.position = new Vector3(hero.position.x, this.height, zPosition);
        cam.position = Vector3.MoveTowards(cam.position, new Vector3(hero.position.x, this.height, zPosition), (speed * Time.deltaTime));
    }
}

