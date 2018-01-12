using System.Collections;
using System.Collections.Generic;
using UnityEngine;


using UnityEngine;
using System.Collections;

public class DestroyByContact : MonoBehaviour
{
	public GameObject explosion = null; //explotion of the astroid
	public GameObject playerExplosion = null; //when the player hits an astroid

	//this code is first called when the collider touches the physical collider
	void OnTriggerEnter(Collider other) 
	{
		if (other.tag == "Boundary")
		{
			return;
		}
		Instantiate(explosion, transform.position, transform.rotation);
		if (other.tag == "Player") // show explotions for the player
		{
			Instantiate(playerExplosion, other.transform.position, other.transform.rotation);
	
		}


		Destroy(other.gameObject);
		Destroy(gameObject);//destroy the astroid and all it's children 3:)

	
	}
}