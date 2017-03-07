using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndPandaController : MonoBehaviour {

	public float speed;
	public GameObject face;
	public GameObject speechBub;
	public GameObject text;
	int click = 0;
	bool walkOne;
	bool finalMove;

	Animator anim;
	Rigidbody2D rb;

	// Use this for initialization
	void Start()
	{
		anim = GetComponent<Animator>();
		rb = GetComponent<Rigidbody2D>();
		walkOne = true;
	}

	void Update(){
		anim.SetFloat("Speed", rb.velocity.x);
		if (walkOne) { // initial walk 
			Debug.Log ("Inital walk");
			walk ();
		}
		if (transform.position.x >= 0) { // stop walk at centre 
			walkOne = false;
			awakeFace ();
			rb.velocity = new Vector2(0,0);
			anim.SetBool ("Walking", false);
		}
		if (finalMove) {
			Debug.Log ("final Walk");
			walk ();
		}
		if (transform.position.x >= 10.5) { // kill panda off scene 
			Destroy (this.gameObject);
		}

	}
	void OnMouseDown(){
		Debug.Log ("Panda Clicks:" + click);

		switch (click) {// switch for each click on panda 

		case 0: // show speech bubble 
			Debug.Log ("Show speech bubble");
			happyFace ();
			speechBub.SetActive (true);
			++click;
			break;

		case 1: // walk of scene 
			Debug.Log ("Final walk off scene");
			finalMove = true;
			++click;
			break;
		default :
			break;

		}

	}

	/**
	 * methods to change panda face to diffrent states 
	 */
	void awakeFace(){
		face.GetComponent<Animator> ().SetBool ("isSleeping", false);
		face.GetComponent<Animator> ().SetBool ("Happy", false);
		face.GetComponent<Animator> ().SetBool ("Walking", false);
	}
	void walkFace(){
		face.GetComponent<Animator> ().SetBool ("isSleeping", false);
		face.GetComponent<Animator> ().SetBool ("Happy", false);
		face.GetComponent<Animator> ().SetBool ("Walking", true);
	}
	void happyFace(){
		face.GetComponent<Animator> ().SetBool ("isSleeping", false);
		face.GetComponent<Animator> ().SetBool ("Happy", true);
		face.GetComponent<Animator> ().SetBool ("Walking", false);
	}
	void walk(){
		walkFace ();
		rb.velocity = Vector2.right * speed;
	}
	public void finalWalk(){

		finalMove = true;
	}

	void OnDestroy(){
		Debug.Log ("Load next scene");
		//TODO load next scene
	}
}
