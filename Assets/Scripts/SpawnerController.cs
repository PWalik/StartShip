using UnityEngine;
using System.Collections;

public class SpawnerController : MonoBehaviour {
	public GameObject RGun, LGun, finalBullet;
	public string fireN, fireL;
	public AudioClip fireNor, fireLas, fireSpe;
	GameObject player;
	public float cooldown = 0.5f;
	float time = 0f;
	bool cd = false;
	bool gun = false;
	public bool final = false;
	bool anim = false;
	float Ly, Ry;
	void Start() {
		player = GameObject.FindWithTag ("Player");
		Ly = LGun.transform.localPosition.y;
		Ry = RGun.transform.localPosition.y;
	}
	void Update() {
		if (GameObject.FindWithTag ("Player").GetComponent<Player> ().move == true) {
			if (Input.GetAxis (fireL) == 1 && Input.GetAxis (fireN) == 1
			   && player.GetComponent<Player> ().power == player.GetComponent<Player> ().maxPower && final != true) {
				final = true;
				player.GetComponent<Player> ().final = true;
				GetComponent<AudioSource> ().clip = fireSpe;
			} else if (Input.GetAxis (fireN) == 1 && cd == false && Input.GetAxis (fireL) == 0 && final != true) {
				GetComponent<AudioSource> ().clip = fireNor;
				GetComponent<AudioSource> ().Play ();
				if (gun == false) {
					LGun.GetComponent<SpawnBullet> ().spawnNormalBullet ();
					gun = true;
					LGun.transform.localPosition = new Vector3 (LGun.transform.localPosition.x, LGun.transform.localPosition.y + 0.05f);
					RGun.transform.localPosition = new Vector3 (RGun.transform.localPosition.x, Ry);
				} else {
					RGun.GetComponent<SpawnBullet> ().spawnNormalBullet ();
					RGun.transform.localPosition = new Vector3 (RGun.transform.localPosition.x, RGun.transform.localPosition.y + 0.05f);
					LGun.transform.localPosition = new Vector3 (LGun.transform.localPosition.x, Ly);
					gun = false;
				}
				cd = true;
				time = 0f;
			} else if (Input.GetAxis (fireL) == 1 && GameObject.FindWithTag ("Player").GetComponent<Player> ().power > 0 && final != true) {
				GetComponent<AudioSource> ().clip = fireLas;
				GetComponent<AudioSource> ().Play ();
				LGun.GetComponent<SpawnBullet> ().spawnLaser ();
				RGun.GetComponent<SpawnBullet> ().spawnLaser ();
				if (anim == true) {
					RGun.transform.localPosition = new Vector3 (RGun.transform.localPosition.x, Ly);
					LGun.transform.localPosition = new Vector3 (LGun.transform.localPosition.x, Ly);
					anim = false;
				} else {
					RGun.transform.localPosition = new Vector3 (RGun.transform.localPosition.x, RGun.transform.localPosition.y + 0.05f);
					LGun.transform.localPosition = new Vector3 (LGun.transform.localPosition.x, LGun.transform.localPosition.y + 0.05f);
					anim = true;
				}
				GameObject.FindWithTag ("Player").GetComponent<Player> ().power -= 0.3f;
				time = 0;
			}
			if (cd == true) {
				time += Time.deltaTime;
			}
			if (time >= cooldown) {
				cd = false;
			}
			if (final == true) {
				if (GameObject.FindWithTag ("Player").GetComponent<Player> ().power <= 0) {
					final = false;
					player.GetComponent<Player> ().final = false;
				} else {
					spawnFinal ();
					GameObject.FindWithTag ("Player").GetComponent<Player> ().power--;
					GetComponent<AudioSource> ().Play ();
				}
			}
		}
	}
	public void spawnFinal() {
		Instantiate (finalBullet, transform.position, this.transform.rotation); 
		time = 0;

	}
}
