﻿//dafont.com
using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class MainScript : MonoBehaviour {

	// these global variables will be set from the inspector.
	public GameObject pipeObject;	// which prefab will represent the pipe?
	public GameObject birdObject;	// which prefab will represent the bird?	
	public float pipeHole;		// how large is the gap between upper and lower pipes?
	public Text scoreText;
	public Text instructText;

	private int score;

	public static MainScript ms = null;

	private int highScore;

	public AudioClip dingAudio;

	private AudioSource background;

	public GameObject grassObject;
	
	// function to be executed once the script started
	void Start () {
		if (ms == null)
			ms = this;
		else if (ms != this)
			Destroy (gameObject);
		
		highScore = PlayerPrefs.GetInt ("High Score", 0);

		hideScoreText ();

		// placing the bird
		Instantiate(birdObject);
		// calling "CreateObstacle" function after 0 seconds, then each 1.5 seconds, 
		InvokeRepeating("CreateObstacle", 0f, 1.5f);

		score = 0;

		background = GetComponent<AudioSource> ();

		createGrass (-6.4f);
		createGrass (0f);
		createGrass (6.4f);
		createGrass (12.8f);
	}
	
	// function called by InvokeRepeating function
	void CreateObstacle(){
		if (BirdScript.bird.isGameStarted () && !BirdScript.bird.isGameOver()) {
			// generating random upper pipe position
			float randomPos = 4f - (4f - 0.8f - pipeHole) * Random.value;
			// adding upper pipe to stage
			GameObject upperPipe = Instantiate (pipeObject);
			// setting upper pipe position
			upperPipe.transform.position = new Vector2 (4f, randomPos);
			// adding lower pipe to stage
			GameObject lowerPipe = Instantiate (pipeObject);
			// setting lower pipe position
			lowerPipe.transform.position = new Vector2 (4f, randomPos - pipeHole - 4.8f);
			lowerPipe.transform.eulerAngles = new Vector3(180f,0f,0f);
		}
	}

	public void hideScoreText(){
		scoreText.text = "High SCore: " + highScore;
	}
	
	public void showScoreText(){
		scoreText.text = "SCore: " + score/2;
	}

	public void hideInstrucText(){
		instructText.enabled = false;
	}

	public void showInstructText(){
		instructText.enabled = true;
	}

	public void pointUp(){
		background.PlayOneShot (dingAudio);
		score++;
		scoreText.text = "SCore: " + score/2;
	}

	public void dying(){
		background.pitch = 0.5f;
	}

	public void setInstructTextToGameover(){
		instructText.text = "Tap to\ntry again";
	}

	public void setHighScore(){
		//print (highScore);
		if (score/2 > highScore) {
			highScore = score/2;
			PlayerPrefs.SetInt ("High Score", highScore);
			//print (PlayerPrefs.GetInt("High Score"));
		}
	}

	public void createGrass(float pos){
		GameObject grass = Instantiate (grassObject);
		grass.transform.position = new Vector2 (pos, 0f);
	}
}
