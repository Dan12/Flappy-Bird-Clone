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
	
	// function to be executed once the script started
	void Start () {
		if (ms == null)
			ms = this;
		else if (ms != this)
			Destroy (gameObject);

		// placing the bird
		Instantiate(birdObject);
		// calling "CreateObstacle" function after 0 seconds, then each 1.5 seconds, 
		InvokeRepeating("CreateObstacle", 0f, 1.5f);

		score = 0;
	}
	
	// function called by InvokeRepeating function
	void CreateObstacle(){
		if (BirdScript.bird.isGameStarted ()) {
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
		}
	}

	public void hideInstrucText(){
		instructText.enabled = false;
	}

	public void showInstructText(){
		instructText.enabled = true;
	}

	public void pointUp(){
		score++;
		scoreText.text = "Score: " + score/2;
	}
}
