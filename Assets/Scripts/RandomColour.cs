using UnityEngine;
using System.Collections;

public class RandomColour : MonoBehaviour {
	// Use this for initialization
	void Start () {
		GetComponent<SpriteRenderer>().color = new Color (Random.value, Random.value, Random.value, 1.0f);
	}

}
