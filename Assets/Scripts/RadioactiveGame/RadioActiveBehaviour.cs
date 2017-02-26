using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RadioActiveBehaviour : MonoBehaviour {

	private Rigidbody2D rb;

	void Start() {
		rb = GetComponent<Rigidbody2D>();
		rb.velocity = new Vector3(0, 0, 0);
	}

	// Update is called once per frame
	void Update () {
		if (transform.position.y <= -10) {
			Destroy (gameObject);
		}
	}
}
