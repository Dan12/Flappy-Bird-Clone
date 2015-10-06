using UnityEngine;
using System.Collections;

public class BirdScript : MonoBehaviour {

	// this global variable will be set from the inspector. Represents bird jump force
	public Vector2 jumpForce = new Vector2();

	public float angularSpin = 400f;

	public GameObject blood;

	private float resetDelay = 1f;

	private bool gameover = false;
	private bool startGame = false;

	public static BirdScript bird = null;
	
	// function to be executed once the bird is created
	void Awake () {
		if (bird == null)
			bird = this;
		else if (bird != this)
			Destroy (gameObject);

		// placing the bird
		transform.position = new Vector2(-6f,0f);
	}

	// function to be executed at each frame
	void Update () {
		// getting the real position, in pixels, of the bird on the stage
		Vector2 stagePos = Camera.main.WorldToScreenPoint(transform.position);

		// waiting for mouse input
		if (Input.GetButtonDown("Fire1") && stagePos.y < Screen.height && !gameover) {
			if(!startGame){
				GetComponent<Rigidbody2D>().isKinematic = false;
				MainScript.ms.hideInstrucText();
				MainScript.ms.showScoreText();
				// placing the bird
				transform.position = new Vector2(-2f,0f);
				startGame = true;
			}

			jump ();

			if(transform.eulerAngles.z != 0)
				transform.eulerAngles = new Vector3(0f,0f,transform.eulerAngles.z+90f);

			GetComponent<Rigidbody2D>().angularVelocity = -angularSpin;
		}	

		if (transform.eulerAngles.z > 20 && transform.eulerAngles.z < 180 && !gameover) {
			transform.eulerAngles = new Vector3(0f,0f,0f);
			GetComponent<Rigidbody2D>().angularVelocity = 0f;
		}

		if(stagePos.y > Screen.height)
			// setting bird's rigid body velocity to zero
			GetComponent<Rigidbody2D>().velocity = Vector2.zero;

		// if the bird leaves the stage...
		if (stagePos.y < 0 && GetComponent<Rigidbody2D>().velocity.y < 0){
			jump ();
			// ... call die function
			die();
		}
	}

	void jump(){
		// setting bird's rigid body velocity to zero
		GetComponent<Rigidbody2D>().velocity = Vector2.zero;
		// adding jump force to bird's rigid body
		GetComponent<Rigidbody2D>().AddForce(jumpForce);
	}
	
	// function to be executed once the bird enters in collision with anything
	void OnCollisionEnter2D(){
		// call die function
		die();
	}
	
	void die(){
		if (!gameover) {
			Time.timeScale = 0.5f;
			gameover = true;
			Instantiate(blood, transform.position, Quaternion.Euler(transform.eulerAngles));
			Invoke ("Reset", resetDelay);
		}
	}

	public bool isGameOver(){
		return gameover;
	}

	public bool isGameStarted(){
		return startGame;
	}

	void Reset(){
		MainScript.ms.setHighScore ();
		Time.timeScale = 1f;
		gameover = false;
		startGame = false;
		//MainScript.ms.showInstructText();
		MainScript.ms.hideScoreText ();
		// reload the current scene - actually restart the game
		Application.LoadLevel(Application.loadedLevel);
	}
}
