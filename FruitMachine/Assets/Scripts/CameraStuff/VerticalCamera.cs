using System;
using UnityEngine;
using System.Collections;

	class VerticalCamera : ICameraBehavior
	{
		public float xPosition;

        public VerticalCamera(float _xPivot, Transform _hero, Transform _camera, float _height = 10.0f, float _distance = -20.0f)
        : base(_hero, _camera, _height, _distance)
        {
			xPosition = _xPivot;
        }

        override public void behave()
        {
            float speed = 20f;
            //cam.position = hero.position + new Vector3(0, this.height, 0);
            //cam.position = new Vector3(xPosition, this.height, hero.position.z + this.distance);
            cam.position = Vector3.MoveTowards(cam.position, new Vector3(xPosition, this.height, hero.position.z + this.distance), ( speed * Time.deltaTime) );
        }
	}

