using UnityEngine;
using System.Collections;

public class Mover : MonoBehaviour
{

	public GameObject shot;

	public float speed;
	public Rigidbody rb;
	void Start ()
	{
		rb = GetComponent<Rigidbody>();
		rb.velocity = new Vector3 (0.0f, 0.0f, speed);

	}





}﻿