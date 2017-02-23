﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bubble_Z_Controller : MonoBehaviour {
	
	private Rigidbody2D rb;
	public int speed=1;
	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody2D> ();
	}
	
	// Update is called once per frame
	void Update () {
		rb.AddForce (Vector2.up * speed);
		if (gameObject.transform.position.y > 10)
			Destroy (gameObject);
	}

	void OnMouseDown(){
		if (gameObject.CompareTag("Bubble")) 
			Destroy (gameObject); // destroy if bubble 

	}
}