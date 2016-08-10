using UnityEngine;
using System.Collections;

public class Asteroid : MonoBehaviour {
	public float HP = 200;
	public GameObject HPpack,explosion;
	public GameObject enemy;
	public bool done = false;
	float ttime = 0f;
	public float initcd;
	float cd;
	void Start() {
		HP *= transform.localScale.x;
		done = true;
		cd = initcd;
	}
	// Update is called once per frame
	void Update () {
		ttime += Time.deltaTime;

		if (HP <= 0) {
			GameObject.FindWithTag ("Player").GetComponent<Player> ().power += 25;
			Instantiate (explosion, transform.position, transform.rotation);
			if (Random.Range (0, 10) > 7)
				Instantiate (HPpack, transform.position, Quaternion.identity);
			
			Destroy (gameObject);
		
		}
		if (ttime >= cd && GameObject.FindWithTag("Player").GetComponent<Player>().move == true) {
			SpawnUnit ();
			ttime = 0;
			if(GameObject.FindGameObjectsWithTag("Asteroid").Length == 1)
				cd = Random.Range(initcd/3, initcd);
			else
			cd = Random.Range (initcd / 2, initcd);
		}

	}
		void SpawnUnit() {
		if(enemy != null)
		Instantiate (enemy, transform.position, transform.rotation);

		}
}
