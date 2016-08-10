using UnityEngine;
using System.Collections;

public class CheckIfTransform : MonoBehaviour {

	public Sprite idle, trans;
	// Update is called once per frame
	void Update () {
		if (GameObject.FindWithTag ("Player").GetComponent<Player> ().final && transform.GetComponent<Animator> ().GetBool ("Transformed") != true && GameObject.FindWithTag("Player").GetComponent<Player>().move == true) {
			transform.GetComponent<Animator> ().SetBool ("Transforming", true);
			transform.GetComponent<Animator> ().SetBool ("Transformed", true);
			transform.GetComponent<SpriteRenderer> ().sprite = trans;
		} else if (!GameObject.FindWithTag ("Player").GetComponent<Player> ().final && transform.GetComponent<Animator> ().GetBool ("Transformed") == true) {
			transform.GetComponent<Animator> ().SetBool ("Transforming", true);
			transform.GetComponent<Animator> ().SetBool ("Transformed", false);
			transform.GetComponent<SpriteRenderer> ().sprite = idle;
		}
	}
}
