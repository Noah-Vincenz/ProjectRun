﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class TopTriangleMove : MonoBehaviour {

	private int clicks = 0;
	Animator anim;
	public GameObject frontLetter;
	public Sprite top;
    SpriteRenderer sp;
	private AudioSource source;
	bool clicked = false; 
	public float wait;
	public GameObject prompt;
	public GameObject prompt2;
	bool open = false;
	// Use this for initialization
	void Start () {
		sp = GetComponent<SpriteRenderer>();
		anim = GetComponent<Animator>();
		source = GetComponent<AudioSource>();
	}
	
	// Update is called once per frame
	void Update () {
		if (!frontLetter.activeInHierarchy && !open) {
			source.Play ();
			clicked = true;
			anim.SetTrigger ("Open");
			anim.SetBool ("Opened", true);
			prompt.SetActive (false);
			clicked = false;
			Destroy (prompt.gameObject);
			StartCoroutine ("prompt_time2");
			open = true;
		}
	}
		

	void OnMouseDown(){
		switch (clicks) {

		case 0:
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
	/**
	 * Enum to wait the given seconds argument before rendering the prompt
	 */
	IEnumerator prompt_time2()
	{
		yield return new WaitForSeconds(wait);
		if (!(clicked)) {
			prompt2.SetActive (true);
		}
	}
}