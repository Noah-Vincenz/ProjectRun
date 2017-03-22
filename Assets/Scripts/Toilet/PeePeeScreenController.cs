﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PeePeeScreenController : MonoBehaviour {
	Animator anim;
	public ToiletPandaController panda;
	public GameObject prompt;
	public GameObject prompt2;
	public GameObject speechBubble;
	public GameObject scanTxt;
	public GameObject finalText;
	public float wait;
	int clicks;
	public AudioSource roll;
	public AudioSource pee;
	public AudioSource flush;

	// Use this for initialization
	void Start () {
		clicks = 0;
		anim = GetComponent<Animator>();
		roll.time = 1f;
	}

	void Update () {
		if (roll.time >= 2.5f)
			roll.Stop ();
	}

	void OnMouseDown(){
		switch (clicks){

		case 0:  // move screen over panda
			roll.Play ();
			anim.SetTrigger ("MoveScreen");
			anim.SetBool ("moved", true);
			StartCoroutine("scanWait");
			Destroy (prompt.gameObject);
			GetComponent<BoxCollider2D> ().enabled = false; // stops double click
			++clicks;
			break;

		case 1: // moves screen back to original position
			roll.Play ();
			flush.Play ();
			anim.SetTrigger ("moveBack");
			anim.SetBool ("moved", false);
			Destroy (prompt2.gameObject);
			GetComponent<BoxCollider2D> ().enabled = false;
			++clicks;
			break;
			
		}
			

	}

	/*
	 * methods called in animation events :)
	 * 
	 */
	void movePanda(){
		Debug.Log ("Call to movePanda");
		panda.moveUp ();
	}

	void movePandaDown(){
		Debug.Log ("Call to movePanda");
		panda.moveDown ();
	}

	void inProgreesText(){
		Debug.Log ("Call to inProgText");
//		speechBubble.SetActive (true);
		scanTxt.SetActive(true);
	}
	void activateBubble(){

		speechBubble.SetActive (true);
		finalText.SetActive (true);

	}

	/**
	 * wait method 
	 */
	IEnumerator scanWait()
	{
		pee.Play ();
		yield return new WaitForSeconds(wait);
		GetComponent<BoxCollider2D> ().enabled = true;
		prompt2.SetActive (true);
		Destroy (scanTxt.gameObject);
		//finalText.SetActive (true);
	}
}
