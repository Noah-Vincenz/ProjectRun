using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlantController : MonoBehaviour {

	public float speed;
	/**
	 * slide right on click 
	 */
	void OnMouseDown(){
		slideRight ();
	}
	/*
	 * mehtod to slide plant to right
	 */
	void slideRight(){
		if (transform.localPosition.x < 7.5f) { // to stop plant going off screen

			Vector3 newPos = new Vector3 (transform.position.x + speed, transform.position.y, transform.position.z); 
			transform.position = Vector3.MoveTowards (transform.position, newPos, speed * Time.deltaTime); // move to new pos 
		}

	}
}
