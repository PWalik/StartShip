using UnityEngine;
using System.Collections;

public class aHPBar : MonoBehaviour {

	Vector3 startScale;
	float startValue, currValue;
	public GameObject objectz;
	// Use this for initialization
	void Start () {
		startScale = transform.localScale;
		startValue = objectz.GetComponent<Asteroid> ().HP;
		if (!objectz.GetComponent<Asteroid> ().done)
			startValue *= objectz.transform.lossyScale.y;
	}

	// Update is called once per frame
	void Update () {
		if (objectz.GetComponent<Asteroid> ().HP != currValue) {
			currValue = objectz.GetComponent<Asteroid> ().HP;
			transform.localScale = new Vector3(startScale.x * currValue / startValue, transform.localScale.y, transform.localScale.z);
		}
	}
}
