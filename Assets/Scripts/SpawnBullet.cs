using UnityEngine;
using System.Collections;

public class SpawnBullet : MonoBehaviour {
	public GameObject nBullet, lBullet;
	public void spawnNormalBullet() {
		Instantiate (nBullet, transform.position, transform.rotation);
	}
	public void spawnLaser() {
		Instantiate (lBullet, transform.position, transform.rotation);
	}
}
