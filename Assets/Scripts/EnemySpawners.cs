using UnityEngine;
using System.Collections;

public class EnemySpawners : MonoBehaviour {

	public float cooldown = 0.5f;
	float time = 0f;
	bool cd = false;
	bool gun = false;
	public GameObject LGun,RGun;
	// Update is called once per frame
	void Update () {
		if (transform.parent.GetComponent<Renderer> ().isVisible && GameObject.FindWithTag("Player").GetComponent<Player>().move == true) {
			if (cd == false) {
				if (gun == false) {
					LGun.GetComponent<SpawnBullet> ().spawnNormalBullet ();
					gun = true;
				} else {
					RGun.GetComponent<SpawnBullet> ().spawnNormalBullet ();
					gun = false;
				}
				cd = true;
				time = 0f;
			}

			if (cd == true) {
				time += Time.deltaTime;
			}
			if (time >= cooldown) {
				cd = false;
			}
		}
	}
}
