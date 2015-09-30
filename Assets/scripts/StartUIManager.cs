using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class StartUIManager : MonoBehaviour {

	public Text playButton;
	public float colorSpeed = 4f;

	private float[] rgb = new float[3];
	private int indexAt = 1;
	private float increaseAmmt = 1/(float)255;

	void Start(){
		rgb = new float[]{playButton.color.r, playButton.color.g, playButton.color.b};
		increaseAmmt *= colorSpeed;
	}
	
	// Update is called once per frame
	void Update () {
		playButton.color = new Color (rgb[0], rgb[1], rgb[2], 1f);
		//print (rgb[0]+","+rgb[1]+","+rgb[2]);
		//print (indexAt);
		rgb [indexAt]+=increaseAmmt;
		bool changed = false;
		if (rgb [indexAt] > 1f) {
			rgb[indexAt] = 1f;
			indexAt++;
			changed = true;
		} else if (rgb [indexAt] < 0f) {
			rgb[indexAt] = 0f;
			indexAt++;
			changed = true;
		}
		if (changed) {
			if (indexAt >= 3)
				indexAt = 0;
			increaseAmmt *= -1;
			if (rgb [indexAt] == 0 && increaseAmmt < 0f)
				increaseAmmt *= -1;
		}
	}
}