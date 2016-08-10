using UnityEngine;
using System.Collections;

public class EnemyMovement : MonoBehaviour {
	public GameObject body, enemyExplosion;
	Vector3 dir;
	public float speed = 1f;
	public float HP = 100;
	public GameObject HPpack;
	// Use this for initialization
	void Start () {
	}

	// Update is called once per frame
	void Update () {
		if (GameObject.FindWithTag ("Player").GetComponent<Player> ().move == true) {
			dir = GameObject.FindWithTag ("Player").transform.position - transform.position;
			var angle = Mathf.Atan2 (dir.x, dir.y) * Mathf.Rad2Deg;
			transform.rotation = Quaternion.Euler (0, 0, -angle);
			transform.Translate (new Vector3 (0, transform.forward.z * Time.deltaTime * speed, 0));
		}
		if (HP <= 0) {
			Instantiate (enemyExplosion, transform.position, transform.rotation);
			if (Random.Range (0, 15) == 5)
				Instantiate (HPpack, transform.position, Quaternion.identity);
			
			GameObject.FindWithTag ("Player").GetComponent<Player> ().power += 15;
			Destroy (gameObject);

		}
	}
}
