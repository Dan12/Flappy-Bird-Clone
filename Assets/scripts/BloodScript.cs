using UnityEngine;
using System.Collections;

public class BloodScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
		transform.position = BirdScript.bird.transform.position;
		transform.eulerAngles = BirdScript.bird.transform.eulerAngles;
	}
	
	// Update is called once per frame
	void Update () {
		transform.position = BirdScript.bird.transform.position;
		transform.eulerAngles = BirdScript.bird.transform.eulerAngles;
	}
}
