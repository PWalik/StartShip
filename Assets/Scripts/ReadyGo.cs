using UnityEngine;
using System.Collections;

public class ReadyGo : MonoBehaviour {
	public float dur = 2f;
	bool isSpawned = false;
	public GameObject ready, go;
	float timer = 0f;
	void Start() {
		GameObject obj = Instantiate (ready, transform.position, transform.rotation) as GameObject;
		obj.transform.parent = transform;
			}
	// Update is called once per frame
	void Update () {
		timer += Time.deltaTime;
		if (timer >= dur * 3 / 4 && isSpawned == false) {
			GameObject obj = Instantiate (go, go.transform.position, transform.rotation) as GameObject;
			obj.transform.SetParent (transform, false);
			isSpawned = true;
		}
		if (timer >= dur)
			Destroy (gameObject);
	}
}
