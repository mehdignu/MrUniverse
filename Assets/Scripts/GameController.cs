using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour {



	//sponing the hazards in the game

	private int score;
	public GUIText scoreText;


	public int  Minutes;
	public int  Seconds;
	public GUIText timeText;
	private float   m_leftTime;

	public GameObject[] hazards;
	public Vector3 spawnValues;
	public float spawnWait;
	public float startWait; //how many seconds we give to the player to get ready
	public float waveWait; //we should wait before do hazards to have them in a seperete lines
	public int asteroidCount;
	public int count;


	public GUIText restartText;
	public GUIText gameOverText;

	private bool gameOver;
	private bool restart;


		void Start()
		{

		m_leftTime = GetInitialTime();

		gameOver = false;
		gameOverText.text = "";


		restart = false;
		restartText.text = "";

		score = 0;
		UpdateScore();
		StartCoroutine (SpawnWaves());
		}


	void Update()
	{
		if (m_leftTime > 0f) {
			//  Update countdown clock
			m_leftTime -= Time.deltaTime;
			Minutes = GetLeftMinutes ();
			Seconds = GetLeftSeconds ();

			//  Show current clock
			if (m_leftTime > 0f && !gameOver) {
				timeText.text = "Time : " + Minutes + ":" + Seconds.ToString ("00");
			} else {

				if (!gameOver) {
					//  The countdown clock has finished
					timeText.text = "Time : 0:00";
				}
			}
		}

		if (restart) {
			if (Input.GetKeyDown(KeyCode.R)) {
				Application.LoadLevel(Application.loadedLevel);
			}
		}
	}


	private float GetInitialTime()
	{
		return Minutes * 60f + Seconds;
	}

	public int GetLeftMinutes()
	{
		return Mathf.FloorToInt(m_leftTime / 60f);
	}

	public int GetLeftSeconds()
	{
		return Mathf.FloorToInt(m_leftTime % 60f);
	}

	IEnumerator SpawnWaves() //instantiate the hazards 
	{
		yield return new WaitForSeconds (startWait);
		while (true) { //instantiate many hazards
			for (int i = 0; i < count; i++) { //this loop creates multiple hazards


				GameObject hazard = hazards[Random.Range(0, hazards.Length)];

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

			if (gameOver || timeText.text=="Time : 0:00") {

				if (!gameOver) {
					GameOver2();
				}

				restart = true;
				restartText.text = "Press 'R' to Restart";
				break;
			}
		}
	}

	public void AddScore(int newScoreValue)
	{
		score += newScoreValue;
		UpdateScore();
	}

	void UpdateScore()
	{
		scoreText.text = "Score: " + score.ToString();
	}

	public void GameOver()
	{
		gameOver = true;
		gameOverText.text = "GAME OVER";
	}


	public void GameOver2()
	{
		gameOver = true;
		gameOverText.text = "You Have successfully came to Mars ! \n the fourth planet from the Sun \n and the second-smallest planet in the Solar System";
	}

}
