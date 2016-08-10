using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class LevelText : MonoBehaviour {
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		GetComponent<Text> ().text = "Level: " + GameObject.FindWithTag ("World").GetComponent<SpawnWorld> ().LevelNumber;
	}
}
