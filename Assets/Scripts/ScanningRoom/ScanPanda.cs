using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScanPanda : MonoBehaviour {

	public float speed;
	public GameObject face;
	public bool canClimb;

	Animator anim;
	Rigidbody2D rb;

	// Use this for initialization
	void Start () {

		anim = GetComponent<Animator>();
		rb = GetComponent<Rigidbody2D>();
		canClimb = false;

	}
		

	// Update is called once per frame
	void Update () {
		
		anim.SetFloat("Speed", rb.velocity.x);

		if (Input.GetMouseButtonDown (0)) {

			rb.velocity = Vector2.left * speed;
			face.GetComponent<Animator>().SetBool("Walking", true);

		}
		if (canClimb){

			rb.velocity = new Vector2(0, 0);
			anim.SetBool("IsClimbing", true);
			face.GetComponent<Animator>().SetBool("Walking", true);

		}
	}

	void OnTriggerEnter2D(Collider2D col){

		canClimb = true;

	}

}