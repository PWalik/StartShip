using UnityEngine;
using System.Collections;

public class BulletController : MonoBehaviour {
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
	// Update is called once per frame
	void Update () {
		if (GameObject.FindWithTag ("Player").GetComponent<Player> ().move == true) {
			transform.Translate (new Vector3 (0, transform.forward.z * Time.deltaTime * speed, 0));
			time += Time.deltaTime;
			if (time >= timeD) {
				Destroy (gameObject);
			}
		}
	}
	void OnTriggerEnter2D(Collider2D col) {
		if (col.gameObject.tag == "Player" && isEnemy) {
			col.GetComponent<Player> ().HP -= power;
			Destroy (gameObject);
		} else if (col.gameObject.tag == "Enemy" && !isEnemy) {
			col.transform.parent.gameObject.GetComponent<EnemyMovement> ().HP -= power;
			Destroy (gameObject);

		} else if (col.gameObject.tag == "Asteroid" && !isEnemy) {
			col.gameObject.transform.parent.GetComponent<Asteroid> ().HP -= power;
			Destroy (gameObject);

		} else if (col.gameObject.tag == "Bound")
			Destroy (gameObject);
	}
}
