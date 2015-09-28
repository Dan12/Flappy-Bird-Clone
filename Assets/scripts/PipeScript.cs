using UnityEngine;
using System.Collections;

public class PipeScript : MonoBehaviour {

	// this global variable will be set from the inspector. Represents pipe velocity
	public Vector2 pipeVelocity = new Vector2();

	private bool addedScore = false;
	
	// function to be executed once the pipe is created
	void Start () {
		// setting the velocity of the rigid body component attached to the pipe
		GetComponent<Rigidbody2D>().velocity = pipeVelocity;
	}
	
	// function to be executed at each frame
	void Update () {
		if(BirdScript.bird.isGameOver())
			GetComponent<Rigidbody2D>().velocity = Vector2.zero;
		// checking x position
		if(transform.position.x<-4){
			// destroying the pipe and freeing memory and resources
			Destroy(gameObject);
		}

		if (transform.position.x < -2.5 && !addedScore) {
			MainScript.ms.pointUp ();
			addedScore = true;
		}
	}
}
