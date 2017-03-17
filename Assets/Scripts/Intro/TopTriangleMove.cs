using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TopTriangleMove : MonoBehaviour {

	private int clicks = 0;
	Animator anim;
	public GameObject frontLetter;
	public Sprite top;
    SpriteRenderer sp;
	// Use this for initialization
	void Start () {
		sp = GetComponent<SpriteRenderer>();
		anim = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
		

	void OnMouseDown(){
		switch (clicks) {
		case 0:
			if (!frontLetter.activeInHierarchy) {
				anim.SetTrigger ("Open");
				anim.SetBool ("Opened", true);
				++clicks;
				break;
			}
			break;
		case 1:
			if (anim.GetCurrentAnimatorStateInfo (0).IsName ("idleTop")) {
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