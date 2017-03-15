using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToiletPandaController : MonoBehaviour {
	Animator anim;
	Rigidbody2D rb;
	bool walkIn = true;

	public GameObject face;
	public float speed;
	public GameObject screenPrompt;


	// Use this for initialization
	void Start () {
		walkIn = true;
		anim = GetComponent<Animator>();
		rb = GetComponent<Rigidbody2D>();

		
	}
	
	// Update is called once per frame
	void Update () {

		anim.SetFloat("Speed", rb.velocity.x);

		if (walkIn) {
			Debug.Log ("adding velocity");
			rb.velocity = Vector2.left * speed;
			walkFace ();

		}

		if (transform.localPosition.x <= 2.4f) {
			rb.velocity = new Vector2 (0, 0);
			walkIn = false;
			awakeFace ();
			screenPrompt.SetActive (true);
	
		}
	}

	/**
	 * methods to change panda face to diffrent states 
	 */
	void awakeFace(){
		face.GetComponent<Animator> ().SetBool ("Happy", false);
		face.GetComponent<Animator> ().SetBool ("Walking", false);
	}
	void walkFace(){
		face.GetComponent<Animator> ().SetBool ("Happy", false);
		face.GetComponent<Animator> ().SetBool ("Walking", true);
	}
	void happyFace(){
		face.GetComponent<Animator> ().SetBool ("Happy", true);
		face.GetComponent<Animator> ().SetBool ("Walking", false);
	}
	public void moveUp(){
		Debug.Log ("moveUP called");
		transform.position = new Vector3 (transform.localPosition.x, transform.localPosition.y+1.0f, transform.localPosition.z);
	}
		
}
