using UnityEngine;
using System.Collections;

public class FireEffect : MonoBehaviour {
	GameObject player;
	public GameObject smoke1, smoke2, smoke3;
	Vector3 pos;
	// Use this for initialization
	void Start () {
		player = GameObject.FindWithTag ("Player");
		pos = player.transform.position;
	}
	
	// Update is called once per frame
	void Update () {
		if (pos != player.transform.position && GameObject.FindWithTag("Player").GetComponent<Player>().move == true) {
			for (int i = 0; i < Random.Range (1, 3); i++) {
				switch (Random.Range (1, 4)) {
				case 1:
					Instantiate (smoke1, transform.position, transform.rotation);
					break;
				case 2:
					Instantiate (smoke2, transform.position, transform.rotation);
					break;
				case 3:
					Instantiate (smoke3, transform.position, transform.rotation);
					break;
				}
			}
		}
		pos = player.transform.position;
	}
}