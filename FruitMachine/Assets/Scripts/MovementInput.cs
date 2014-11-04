using UnityEngine;
using System.Collections;


[RequireComponent(typeof(CharacterController))]
public class MovementInput : MonoBehaviour {

	public float speed;
    public float jumpSpeed = 8.0f;
    public float gravity = 20.0f;
    public Camera camera;

	private Vector3 moveDirection = Vector3.zero;
	
	// Update is called once per frame
	void LateUpdate () 
	{
        CharacterController controller = GetComponent<CharacterController>();

        if (controller.isGrounded)
        {
            moveDirection = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
            
            transform.LookAt(new Vector3(transform.position.x + Input.GetAxis("Horizontal"), transform.position.y, transform.position.z + Input.GetAxis("Vertical")));
           
            moveDirection *= speed;

            if (Input.GetButton("Jump"))
                moveDirection.y = jumpSpeed;
  
        }

        
        moveDirection.y -= gravity * Time.deltaTime;
        controller.Move(moveDirection * Time.deltaTime);

	}
}
