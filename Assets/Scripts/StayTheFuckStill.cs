using UnityEngine;
using System.Collections;

public class StayTheFuckStill : MonoBehaviour {
	public float howX = 0f;
	public float howY = 1f;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		transform.rotation = Quaternion.identity;
		transform.position = transform.parent.position + new Vector3 (howX*transform.parent.lossyScale.x, howY*transform.parent.lossyScale.y, 0);
	}
}
