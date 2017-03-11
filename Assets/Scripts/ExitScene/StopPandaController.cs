using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StopPandaController : MonoBehaviour {

	public float speed;
	public GameObject face;
	public GameObject speechBubble;

	Animator anim;
	Rigidbody2D rb;

	// Use this for initialization
	void Start () {

		anim = GetComponent<Animator>();
		rb = GetComponent<Rigidbody2D>();
		speechBubble.SetActive (false);
		
	}
	
	// Update is called once per frame
	void Update () {

		anim.SetFloat("Speed", rb.velocity.x);

		rb.velocity = Vector2.right * speed;
		face.GetComponent<Animator> ().SetBool ("Walking", true);

		if ( transform.localPosition.x > 0 ){

			rb.velocity = new Vector2 (0, 0);
			face.GetComponent<Animator> ().SetBool ("Walking", false);
			speechBubble.SetActive (true);
			anim.SetBool("IsWaving", true);

		}
		
	}
}
