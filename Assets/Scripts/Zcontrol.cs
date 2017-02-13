using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zcontrol : MonoBehaviour {
	
	Rigidbody2D rb;
	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody2D> ();
//		InvokeRepeating ("SpawnZ", spawnTime, spawnTime);
	}
	
	// Update is called once per frame
	void Update () {
		rb.AddForce (Vector2.up * 1);
		if (transform.position.y > 10) {
			Debug.Log ("trying to kill");
			Destroy (this.gameObject);
		}
	}



}
