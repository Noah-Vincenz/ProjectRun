﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class MoveBed : MonoBehaviour {

	private bool dirRight;
	private float speed;
	public float leftPos;
	public float rightPos;
	float timeLeftforTransition=1;
	float count = 0;
	private bool readyForTransition;
	public GameObject background;

	// Use this for initialization
	void Start () {

		dirRight = true;
		speed = 1.0f;

		var material1 = background.GetComponent<Renderer>().material;
		var color1 = material1.color;
		background.GetComponent<Renderer> ().material.color = new Color (color1.r, color1.g, color1.b, color1.a -color1.a);
		readyForTransition = false;

	}
	
	// Update is called once per frame
	void Update () {

		var material = background.GetComponent<Renderer>().material;
		var color = material.color;

		if (dirRight) {
			transform.Translate (Vector2.right * speed * Time.deltaTime);
		} 
		else {
			transform.Translate (-Vector2.right * speed * Time.deltaTime);
		}

		if(transform.position.x >= rightPos) {
			dirRight = false; //move to the left when it's bigger or equal to the right maximum position

		}

		if(transform.position.x <= leftPos) {			
			dirRight = true;
			count++;
		}

		if (count >= 2) {
			readyForTransition = true; //move to the right when it's bigger or equal to the left maximum position
		}

		if (readyForTransition) {

			background.SetActive (enabled);
			material.color = new Color (color.r, color.g, color.b, color.a + (1f * Time.deltaTime));
			timeLeftforTransition -= Time.deltaTime;

		}

		if (timeLeftforTransition <= 0) {

			SceneManager.LoadScene ("EndWaitingRoom"); //load this once the timer hits 0

		}
		
	}
}
