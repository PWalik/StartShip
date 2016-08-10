using UnityEngine;
using System.Collections;

public class SpawnWorld : MonoBehaviour {
	public GameObject aster, easter, rdygo;
	public GameObject body;
	public Sprite sprite;
	bool go = false;
	GameObject player;
	public GameObject spawners;
	public int LevelNumber = 1;
	public float cd = 1f;
	float timer = 0f;
	// Use this for initialization
	void Start () {
		player = GameObject.FindWithTag ("Player");
		Spawn ();
		player.GetComponent<Player>().move = false;
		GameObject obj = Instantiate (rdygo, rdygo.transform.position, rdygo.transform.rotation) as GameObject;
		obj.transform.SetParent (GameObject.FindWithTag ("Canvas").transform, false);
	}
	void Update() {
		CheckForAliens ();
	}
	void Spawn() {
		for (int i = 0; i < Random.Range (LevelNumber + 1, LevelNumber + 3); i++) {
			if (LevelNumber >= 3 && Random.Range (0, 10) > 6) {
				Instantiate (easter, new Vector3 (Random.Range (-40, 40), Random.Range (-40, 40)), Quaternion.identity);
				i += 3;
			}
				else
			Instantiate (aster, new Vector3 (Random.Range (-40, 40), Random.Range (-40, 40)), Quaternion.identity);

		}
	}
	void CheckForAliens() {
		if (GameObject.FindGameObjectsWithTag ("Asteroid").Length == 0 && GameObject.FindGameObjectsWithTag ("Enemy").Length == 0) {
			if (go == false) {
				go = true;
				player.GetComponent<Player> ().move = false;
				player.GetComponent<Rigidbody2D> ().velocity = new Vector2 (0, 0);
			}
			if (go == true) {
				timer += Time.deltaTime;
				if (timer >= cd) {
					LevelNumber++;
					ResetLvl ();
					Spawn ();
					body.GetComponent<Animator> ().SetBool ("NewLvl", true);
					body.GetComponent<Animator> ().SetBool ("Transforming", false);
					body.GetComponent<Animator> ().SetBool ("Transformed", false);
					GameObject obj = Instantiate (rdygo, rdygo.transform.position, rdygo.transform.rotation) as GameObject;
					obj.transform.SetParent (GameObject.FindWithTag ("Canvas").transform, false);
					go = false;
					timer = 0;
				}
			}
		}
	}
	public void ResetLvl() {
		for (int i = 0; i < GameObject.FindGameObjectsWithTag ("Bullet").Length; i++) {
			Destroy (GameObject.FindGameObjectsWithTag ("Bullet") [i]);
		}
		for (int i = 0; i < GameObject.FindGameObjectsWithTag ("HP").Length; i++) {
			Destroy (GameObject.FindGameObjectsWithTag ("HP") [i]);
		}
			player.transform.position = new Vector3 (0, 0, 0);
			player.transform.rotation = Quaternion.identity;
		body.GetComponent<SpriteRenderer> ().sprite = sprite;
			if (spawners.GetComponent<SpawnerController> ().final == true) {
				spawners.GetComponent<SpawnerController> ().final = false;
				player.GetComponent<Player> ().power = player.GetComponent<Player> ().maxPower / 2;
		}

}
}
