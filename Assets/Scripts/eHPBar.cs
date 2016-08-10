using UnityEngine;
using System.Collections;

public class eHPBar : MonoBehaviour {
	Vector3 startScale;
	float startValue, currValue;
	public GameObject objectz;
	// Use this for initialization
	void Start () {
		startScale = transform.localScale;
		startValue = objectz.GetComponent<EnemyMovement> ().HP;
	}
	
	// Update is called once per frame
	void Update () {
		if (objectz.GetComponent<EnemyMovement> ().HP != currValue) {
			currValue = objectz.GetComponent<EnemyMovement> ().HP;
			transform.localScale = new Vector3(startScale.x * currValue / startValue, transform.localScale.y, transform.localScale.z);
		}
	}
}
