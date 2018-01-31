using UnityEngine;
using System.Collections;

public class Enemymover : MonoBehaviour
{

	public GameObject shot;
	private float myTime = 0.0F;
	public float speed;
	public Rigidbody rb;

	private GameController gameController;


	void Update(){



	
	}

	void Start ()
	{

	
		GameObject gameControllerObject = GameObject.FindWithTag("GameController");

		if (gameControllerObject != null) {
			gameController = gameControllerObject.GetComponent<GameController>();
		}

		if (gameControllerObject == null) {
			Debug.Log("Cannot find 'GameController' script");
		}

		Debug.Log (gameController.GetLeftSeconds());
		Debug.Log (gameController.GetLeftMinutes());


		//make the game harder with the time
		if (gameController.GetLeftMinutes() == 1 && gameController.GetLeftSeconds() <= 70) {
			speed =  - 7;
		}

		if (gameController.GetLeftMinutes() == 1 && gameController.GetLeftSeconds() <= 20) {
			speed =  - 10;
		}

		if (gameController.GetLeftMinutes() == 0 && gameController.GetLeftSeconds() <= 70) {
			speed =  - 14;
		}

		rb = GetComponent<Rigidbody>();

		rb.velocity = transform.forward * speed;

	}

}﻿