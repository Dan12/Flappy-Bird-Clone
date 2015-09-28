using UnityEngine;
using System.Collections;

public class CameraScript : MonoBehaviour {

	public Vector3 offset = new Vector3(2f,0f,0f);
	
	// Update is called once per frame
	void Update () {
		if (BirdScript.bird.isGameOver ()) {
			transform.position = new Vector3(BirdScript.bird.transform.position.x+offset.x,0f,-10f);
		}
	}
}
