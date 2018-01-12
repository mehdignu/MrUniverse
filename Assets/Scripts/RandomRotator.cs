using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomRotator : MonoBehaviour {

	public float tumble;

	void Start (){

		Rigidbody rb;
		rb = GetComponent<Rigidbody> ();

		//angularVelocity is how fast the astroid is rotating and i want to give it a random value
		rb.angularVelocity = Random.insideUnitSphere * tumble;
	}


}
