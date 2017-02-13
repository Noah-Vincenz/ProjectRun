using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pop : MonoBehaviour {
	
	public GameObject fish = null;
	Rigidbody2D rb;
	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody2D> ();
	}
	
	// Update is called once per frame
	void Update () {
		rb.AddForce (Vector2.up * 1);
		if (fish.transform.position.y > 10)
			Destroy (fish);
	}

	void OnMouseDown(){
		Destroy (fish);

	}
}
