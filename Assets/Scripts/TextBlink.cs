using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class TextBlink : MonoBehaviour {
	public float cd = 2f;
	float timer = 0f;
	
	// Update is called once per frame
	void Update () {
		timer += Time.deltaTime;
		if (timer >= cd) {
			if (GetComponent<Text> ().text == "")
				GetComponent<Text> ().text = "press START";
			else
				GetComponent<Text> ().text = "";

			timer = 0;
		}
	}
}
