using UnityEngine;
using System.Collections;

public class KeyboardControl : MonoBehaviour {

	public float speed = 10.0f;
	float posx, posy;
	void Update() {
		if(GameObject.FindWithTag("Player").GetComponent<Player>().move == true)
			GetComponent<Rigidbody2D>().velocity = new Vector2(Input.GetAxis ("JoyLHorizontal") * speed, -Input.GetAxis ("JoyLVertical") * speed);
	}


}
