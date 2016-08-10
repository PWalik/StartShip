using UnityEngine;
using System.Collections;

public class Suicide : MonoBehaviour {

	void OnTriggerEnter2D(Collider2D col) {
		if (col.transform.tag == "Player") {
			col.GetComponent<Player> ().HP -= 15;
			this.transform.parent.GetComponent<EnemyMovement> ().HP = 0;
		}
	}
}
