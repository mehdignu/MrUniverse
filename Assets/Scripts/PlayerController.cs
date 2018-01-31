using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

[System.Serializable]
public class Boundary
{
	public float xMin, xMax, zMin, zMax;
}


public class PlayerController : MonoBehaviour 
{

	public float speed;
	public float tilt;
	public Boundary boundary;
	private float myTime = 0.0F;
	public GameObject shot;
	public Transform shotSpawn; 
	public float fireRate;
	private Rigidbody rb;
	private float nextFire; 
	private AudioSource audioSource;

	void Start()
	{
		audioSource = GetComponent<AudioSource>();
		rb = GetComponent<Rigidbody>();
	}

	void Update () 
	{


		//fire1 is preset value in the game manager
		if (Input.GetButton("Fire1") && Time.time > nextFire) 
		{

			//we want to instantiate the bolt Object
			GameObject _shot = Instantiate(shot) as GameObject;
			nextFire = Time.time + fireRate;
			//GameObject clone = 
			_shot.transform.position = shotSpawn.transform.position;
			audioSource.Play();
		}


		if (Input.GetKeyDown(KeyCode.Q)) {
			SceneManager.LoadScene(0);
		}



	}
	void FixedUpdate ()
	{
		float moveHorizontal = Input.GetAxis("Horizontal");
		float moveVertical = Input.GetAxis("Vertical");

		Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);
		rb.velocity = movement * speed;

		rb.position = new Vector3(
			Mathf.Clamp(rb.position.x, boundary.xMin, boundary.xMax),
			0.0f,
			Mathf.Clamp(rb.position.z, boundary.zMin, boundary.zMax)
		);

		rb.rotation = Quaternion.Euler(
			0.0f,
			0.0f,
			rb.velocity.x * -tilt
		);
	}

}﻿