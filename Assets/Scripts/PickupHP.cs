using UnityEngine;
using System.Collections;

public class PickupHP : MonoBehaviour {

	void OnTriggerEnter2D(Collider2D col) {
		if (col.transform.tag == "Player" && GameObject.FindWithTag("Player").GetComponent<Player>().move == true) {
			col.GetComponent<Player> ().HP += 25;
			Destroy (gameObject);
		}

	}
}
