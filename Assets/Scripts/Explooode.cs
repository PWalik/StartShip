using UnityEngine;
using System.Collections;

public class Explooode : MonoBehaviour {
	public GameObject exp1, exp2, exp3, exp4;
	GameObject exp;
	public int size = 1;
	public int number = 1;
	public float life = 1f;
	float timer = 0f;
	// Use this for initialization
	void Start () {
		for (int i = 0; i < Random.Range (5 *number , 15 *number); i++) {
			exp = Instantiate (exp4, transform.position, Random.rotation) as GameObject;
			exp.GetComponent<Fire> ().speed = Random.Range (5, 35);
			exp.GetComponent<Fire> ().spread = Random.Range (1, 10);
			exp.GetComponent<Fire> ().timeD = Random.Range (0.25f, 1f);
			exp.transform.localScale = new Vector3 (Random.Range (0.05f * size, 0.5f * size), Random.Range (0.05f*size, 0.5f*size ), Random.Range (0.05f*size, 0.5f*size));
		}
		for (int i = 0; i < Random.Range (5 *number, 15*number); i++) {
			switch(Random.Range(1,4)) {
			case 1:
				exp = Instantiate (exp3, transform.position,Random.rotation) as GameObject;
				break;
			case 2:
				exp = Instantiate (exp1, transform.position,Random.rotation) as GameObject;
				break;
			default:
				exp = Instantiate (exp2, transform.position, Random.rotation) as GameObject;
				break;
			}
			exp.GetComponent<Fire> ().speed = Random.Range (5, 35);
			exp.GetComponent<Fire> ().spread = Random.Range (1, 10);
			exp.GetComponent<Fire> ().timeD = Random.Range (0.25f, 1f);
			exp.transform.localScale = new Vector3 (Random.Range (0.05f * size, 0.5f * size), Random.Range (0.05f*size, 0.5f*size ), Random.Range (0.05f*size, 0.5f*size));
		}
	}
	void Update() {
		timer += Time.deltaTime;
		if (timer >= life)
			Destroy (gameObject);
	}
}
