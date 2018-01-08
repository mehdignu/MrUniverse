using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour 
{
	public Rigidbody rb;

	void Start() 
	{
		rb = GetComponent<Rigidbody> ();
	}

	void FixedUpdate () 
	{
		float moveHorizontal = Input.GetAxis ("Horizontal");
		float moveVertical = Input.GetAxis ("Vertical");
		//we want to move 0.0 for up and down the others are user movements of right and left

		Vector3 movement = new Vector3 (moveHorizontal, 0.0f, moveVertical);
		rb.velocity = movement;
	} 
}﻿

