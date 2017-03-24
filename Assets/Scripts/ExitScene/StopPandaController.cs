﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class StopPandaController : MonoBehaviour {

	public float speed;
	public GameObject face;
	public GameObject speechBubble;
	public GameObject canvas;
	public GameObject background;
	float timeLeftforTransition=2;
	float timeLeftHitTrigger=2;
	private bool readyForTransition;

	Animator anim;
	Rigidbody2D rb;

	// Use this for initialization
	void Start () {

		anim = GetComponent<Animator>();
		rb = GetComponent<Rigidbody2D>();
		speechBubble.SetActive (false);
		canvas.SetActive (false);
		var material1 = background.GetComponent<Renderer>().material;
		var color1 = material1.color;
		background.GetComponent<Renderer> ().material.color = new Color (color1.r, color1.g, color1.b, color1.a -color1.a);
		readyForTransition = false;
		
	}
	
	// Update is called once per frame
	void Update () {

		var material = background.GetComponent<Renderer>().material;
		var color = material.color;

		anim.SetFloat("Speed", rb.velocity.x);

		rb.velocity = Vector2.right * speed;
		face.GetComponent<Animator> ().SetBool ("Walking", true);

		if ( transform.localPosition.x > 0 ){ //when panda reaches the center of screen

			rb.velocity = new Vector2 (0, 0);
			face.GetComponent<Animator> ().SetBool ("Walking", false); //stop walking
			speechBubble.SetActive (true); //activate speech bubble
			canvas.SetActive (true);
			anim.SetBool("IsWaving", true); //activate waving animation
			timeLeftHitTrigger -= Time.deltaTime;

		}

		if (timeLeftHitTrigger <= 0) {

			readyForTransition = true;

		}

		if (readyForTransition) {

			background.SetActive (enabled);
			material.color = new Color (color.r, color.g, color.b, color.a + (1f * Time.deltaTime));
			timeLeftforTransition -= Time.deltaTime;

		}

		if (timeLeftforTransition <= 0) {

			SceneManager.LoadScene ("WaitingRoom");

		}
		
	}
}
