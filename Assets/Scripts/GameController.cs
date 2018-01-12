using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour {



	//sponing the hazards in the game



		public GameObject hazard;
		public Vector3 spawnValues;
	public float spawnWait;
	public float startWait; //how many seconds we give to the player to get ready
	public float waveWait; //we should wait before do hazards to have them in a seperete lines

	public int count;

		void Start()
		{
		StartCoroutine (SpawnWaves());
		}

	IEnumerator SpawnWaves() //instantiate the hazards 
	{
		yield return new WaitForSeconds (startWait);
		while (true) { //instantiate many hazards
			for (int i = 0; i < count; i++) { //this loop creates multiple hazards
				//x is a random point 
				Vector3 spawnPosition = new Vector3 (
				//random range has min and max values
					                       Random.Range (-spawnValues.x, spawnValues.x), spawnValues.y, spawnValues.z
				                       );

				//used to represent rotations
				Quaternion spawnRotation = Quaternion.identity;
				Instantiate (hazard, spawnPosition, spawnRotation);
				yield return new WaitForSeconds (spawnWait);
			}

			yield return new WaitForSeconds (waveWait); 
		}
	}

}
