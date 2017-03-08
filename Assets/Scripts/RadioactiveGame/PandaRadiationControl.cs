﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PandaRadiationControl : MonoBehaviour {

	public float speed;
	public GameObject face;
	public int count; 
	public Text countText;
	public Text winText;
	public Text gameOverText;
	public Text timerLabel;
	private float timeLeft;
	public Button tryAgainButton;
	public Button continueButton;

	Animator anim;
	Rigidbody2D rb;

	// Use this for initialization
	void Start()
	{
		timeLeft = 30.0f;
		count = 0;
		SetCountText();
		winText.text = "";
		gameOverText.text = "";
		anim = GetComponent<Animator>();
		rb = GetComponent<Rigidbody2D>();
	}

	// Update is called once per frame
	void Update()
	{
		anim.SetFloat ("Speed", rb.velocity.x);
	
		if (Input.GetKeyDown ("left")) {
			WalkLeft ();
		}

		if (Input.GetKeyUp ("left")) {
			StopMoving ();
		}

		if (Input.GetKeyDown ("right")) {
			WalkRight ();
		}

		if (Input.GetKeyUp ("right")) {
			StopMoving ();
		}
		timeLeft -= Time.deltaTime;
		timerLabel.text = "Time Left: " + Mathf.Round(timeLeft) + " secs";
		if(timeLeft < 0)
		{
			gameOverText.text = "Time over. Try again?";
			finishGame ();
			//face.GetComponent<Animator> ().SetBool ("Sad", true);

		}
	}

	void OnCollisionEnter2D(Collision2D coll) {
		count = count + 1;
		Destroy(coll.gameObject);
		SetCountText ();
		if (coll.gameObject.tag == "Bamboo") {
			timeLeft += 5;
		}
		else if (coll.gameObject.tag == "Cube") {
			gameOverText.text = "You were hit by a bomb.\nTry again?";
			finishGame ();
			//face.GetComponent<Animator> ().SetBool ("Sad", true);
		}

			
	}

	void SetCountText() 
	{
		countText.text = "Count: " + count.ToString ();
		if (count >= 20) 
		{
			winText.text = "You win! Captured all radiation!";
			face.GetComponent<Animator> ().SetBool ("Happy", true);
			finishGame ();
		}
	}

	void finishGame() {
		Time.timeScale = 0;
		tryAgainButton.gameObject.SetActive (true);
		continueButton.gameObject.SetActive (true);
	}

	public void WalkLeft() {
		rb.velocity = Vector2.left * speed;
		face.GetComponent<Animator> ().SetBool ("Walking", true);
	}

	public void WalkRight() {
		rb.velocity = Vector2.right * speed;
		face.GetComponent<Animator> ().SetBool ("Walking", true);
	}
	public void StopMoving() {
		rb.velocity = new Vector2 (0, 0);
		face.GetComponent<Animator> ().SetBool ("Walking", false);
	}
	public void StartTimer() {
		timeLeft = 30.0f;
	}
}
	
