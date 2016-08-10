using UnityEngine;
using System.Collections;

public class MenuController : MonoBehaviour {

	// Update is called once per frame
	void Update () {
		if (Input.GetButtonDown ("Submit"))
			Application.LoadLevel (1);
	}
}
