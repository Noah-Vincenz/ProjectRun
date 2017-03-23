﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TopTriangleMove : MonoBehaviour {

	private int clicks = 0;
	Animator anim;
	public GameObject frontLetter;
	public Sprite top;
    SpriteRenderer sp;
	private AudioSource source;
	// Use this for initialization
	void Start () {
		sp = GetComponent<SpriteRenderer>();
		anim = GetComponent<Animator>();
		source = GetComponent<AudioSource>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
		

	void OnMouseDown(){
		switch (clicks) {
		case 0:
			if (!frontLetter.activeInHierarchy) {
				source.Play ();
				anim.SetTrigger ("Open");
				anim.SetBool ("Opened", true);
				++clicks;
				break;
			}
			break;
		case 1:
			if (anim.GetCurrentAnimatorStateInfo (0).IsName ("idletoptri")) {
				SceneManager.LoadScene ("OpenedLetter");
				++clicks;
				break;
			}
			break;
		default:
			break;
		}
	}
	void swapTop(){
		sp.sprite = top;

	}

}