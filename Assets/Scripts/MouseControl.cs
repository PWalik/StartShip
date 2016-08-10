using UnityEngine;
using System.Collections;
public class MouseControl : MonoBehaviour {
	// Update is called once per frame
	float angle;
	void Update () { 
		if ((Input.GetAxis ("JoyRHorizontal") != 0 || Input.GetAxis ("JoyRVertical") != 0) && GameObject.FindWithTag("Player").GetComponent<Player>().move == true) {
		    angle = Mathf.Atan2 (Input.GetAxis ("JoyRHorizontal"), Input.GetAxis ("JoyRVertical")) * Mathf.Rad2Deg;
			transform.rotation = Quaternion.Euler (0, 0, angle);
		}
			
	}
}
