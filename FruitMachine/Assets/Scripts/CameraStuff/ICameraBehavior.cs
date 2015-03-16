//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.34209
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
using System;
using UnityEngine;
using System.Collections;

public abstract class ICameraBehavior : MonoBehaviour
{
	protected bool transitioning = false;


    protected Transform cam;
    protected Transform hero;

    protected float height;
    protected float distance;

    public ICameraBehavior(Transform _hero, Transform _camera, float _height = 20.0f, float _distance = 20.0f)
    {
        cam = _camera;
        hero = _hero;
        height = _height;
        distance = _distance;
    }

	abstract public void behave();

}

