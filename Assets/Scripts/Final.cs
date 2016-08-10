using UnityEngine;
using System.Collections;

public class Final : MonoBehaviour {

	
	// Update is called once per frame
	void Update () {
		GameObject.FindWithTag ("Player").GetComponent<Player> ().power --;
		if (GameObject.FindWithTag ("Player").GetComponent<Player> ().power <= 0) {
			this.transform.parent.GetComponent<SpawnerController> ().final = false;
			Destroy (gameObject);
		}
	}
}
