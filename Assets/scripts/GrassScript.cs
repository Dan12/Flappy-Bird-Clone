using UnityEngine;
using System.Collections;

public class GrassScript : MonoBehaviour {
	public Vector2 grassVelocity = new Vector2();

	void Start(){
		if (BirdScript.bird.isGameStarted ())
			GetComponent<Rigidbody2D> ().velocity = grassVelocity;
	}

	// Update is called once per frame
	void Update () {
		if (BirdScript.bird.isGameStarted ())
			GetComponent<Rigidbody2D> ().velocity = grassVelocity;
		if(BirdScript.bird.isGameOver())
			GetComponent<Rigidbody2D>().velocity = Vector2.zero;
		// checking x position
		if(transform.position.x<-6.4f){
			MainScript.ms.createGrass(6.4f);
			// destroying the pipe and freeing memory and resources
			Destroy(gameObject);
		}
	}
}
