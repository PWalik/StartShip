using UnityEngine;
using System.Collections;

public class Fire : MonoBehaviour {

	public float speed = 1f;
	public float timeD = 0.1f;
	public float power = 10;
	public float spread = 2;
	public bool isEnemy = false;
	float time = 0f;
	void Start() {
		transform.Rotate(new Vector3(0,0, Random.Range(-spread, spread)));
		float scale = Random.Range(0.01f/spread, 1/spread);
		transform.localScale += new Vector3 (scale, scale);
	}
	void Update () {

			transform.Translate (new Vector3 (0, transform.forward.z * Time.deltaTime * speed, 0));
			time += Time.deltaTime;
			if (time >= timeD) {
				Destroy (gameObject);
		}
	}
}
