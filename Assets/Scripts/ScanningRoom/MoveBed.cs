using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveBed : MonoBehaviour {

	private bool dirRight;
	public float speed;
	public float leftPos;
	public float rightPos;

	// Use this for initialization
	void Start () {

		dirRight = true;
		speed = 2.0f;

	}
	
	// Update is called once per frame
	void Update () {

		if (dirRight)
			transform.Translate (Vector2.right * speed * Time.deltaTime);
		else
			transform.Translate (-Vector2.right * speed * Time.deltaTime);

		if(transform.position.x >= rightPos) {
			dirRight = false;
		}

		if(transform.position.x <= leftPos) {
			dirRight = true;
		}
		
	}
}
