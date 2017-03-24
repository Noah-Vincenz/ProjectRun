﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlidingLeftDoor : MonoBehaviour {

	private Vector2 aPosition1;

	// Use this for initialization
	void Start () {

		aPosition1 = new Vector2 ( (float) -6.18, (float) -1.16); //control movement of left door
		
	}
	
	// Update is called once per frame
	void Update () {

		transform.position = Vector2.MoveTowards(new Vector2(transform.position.x, transform.position.y), 
			aPosition1, 3 * Time.deltaTime);
		
	}
}
