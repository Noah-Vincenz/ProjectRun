using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlantController : MonoBehaviour {

	private Rigidbody2D rb ;

	public float speed;
	// Use this for initialization
	void Start () {

		rb = transform.GetComponent<Rigidbody2D>();
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnMouseDown(){
		slideRight ();
	}
	/*
	 * mehtod to slide plant to right
	 */
	void slideRight(){
		if (transform.localPosition.x < 7.13f) { // to stop plant going off screen

			Vector3 newPos = new Vector3 (transform.position.x + speed, transform.position.y, transform.position.z);
			transform.position = Vector3.MoveTowards (transform.position, newPos, speed * Time.deltaTime);
		}

	}
}
