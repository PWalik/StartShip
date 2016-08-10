using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class Player : MonoBehaviour {
	public bool move = true;
	public float power = 0f;
	public float maxPower = 100f;
	public float maxHP = 100f;
	public float HP;
	public GameObject playerExplosion,body, LGun, RGun,rdygo;
	public Sprite bodys, LGuns, RGuns;
	public float timer = 0f;
	public bool final = false;
	public float lives = 3;
	public float deathwait = 2f;
	public Slider pslide,hslide;
	float ttime = 0f;
	void Start() {
		HP = maxHP;
		pslide.maxValue = maxPower;
		hslide.maxValue = maxHP;
	}
	void Update() {
		pslide.value = power;
		hslide.value = HP;
		transform.localRotation = Quaternion.identity;
		if (power > 100)
			power = 100;
		if (power <= 0) {
			power = 0;
		}
		ttime += Time.deltaTime;
		if (ttime >= 5f) {
			power += 10;
			ttime = 0;
		}
		if (HP >= 100)
			HP = 100;
		
		if (HP <= 0 && move == true) {
			GetComponent<AudioSource> ().Play ();
			Instantiate (playerExplosion, transform.position, transform.rotation);
			LGun.GetComponent<SpriteRenderer> ().sprite = null;
			RGun.GetComponent<SpriteRenderer> ().sprite = null;
			move = false;
			final = false;
			lives--;
			GetComponent<Rigidbody2D> ().velocity = new Vector2 (0, 0);
			body.GetComponent<Animator> ().SetBool ("ScrewThat", true);
		}
		if(move == false) {
			timer += Time.deltaTime;
			if (timer >= deathwait) {
				if (lives <= 0)
					Application.LoadLevel (0);
				else {
					if (HP <= 0) {
						
						GameObject.FindWithTag ("World").GetComponent<SpawnWorld> ().ResetLvl ();
						body.GetComponent<Animator> ().SetBool ("ScrewThat", false);
						body.GetComponent<Animator> ().SetBool ("NewLvl", true);
						body.GetComponent<Animator> ().SetBool ("Transforming", false);
						body.GetComponent<Animator> ().SetBool ("Transformed", false);
						final = false;
						GameObject obj = Instantiate (rdygo, rdygo.transform.position, rdygo.transform.rotation) as GameObject;
						obj.transform.SetParent (GameObject.FindWithTag ("Canvas").transform, false);
						LGun.GetComponent<SpriteRenderer> ().sprite = LGuns;
						RGun.GetComponent<SpriteRenderer> ().sprite = RGuns;
						HP = maxHP;
						timer = 0;
					} else {
						final = false;
						body.GetComponent<Animator> ().SetBool ("NewLvl", false);
						move = true;
						body.GetComponent<Animator> ().SetBool ("Transforming", false);
						body.GetComponent<Animator> ().SetBool ("Transformed", false);
						timer = 0;
					}
				}
			}
	
		}
}
}
