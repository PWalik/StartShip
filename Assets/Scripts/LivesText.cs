using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class LivesText : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		GetComponent<Text> ().text = "Lives: " + GameObject.FindWithTag ("Player").GetComponent<Player>().lives;
	}
}
