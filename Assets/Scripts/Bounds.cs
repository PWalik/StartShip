using UnityEngine;
using System.Collections;

public class Bounds : MonoBehaviour {
	public float bound = 49f;
	void Update() {
		if (this.transform.position.x >=bound)
			this.transform.position = new Vector3 (bound, transform.position.y);
		if (this.transform.position.x <= -bound)
			this.transform.position = new Vector3 (-bound, transform.position.y);
		if (this.transform.position.y >= bound)
			this.transform.position = new Vector3 (transform.position.x, bound);
		if (this.transform.position.y <= -bound)
			this.transform.position = new Vector3 (transform.position.x, -bound);

	}
}