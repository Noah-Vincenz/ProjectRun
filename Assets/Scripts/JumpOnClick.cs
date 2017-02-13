using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpOnClick : MonoBehaviour {

	Animator anim;
	Rigidbody2D rb;
	public GameObject fish = null;

	// Use this for initialization
	void Start () {
		anim = GetComponent<Animator>();
		rb = GetComponent<Rigidbody2D> ();
	}
	
	// Update is called once per frame
	void Update () {
		



	}

	void OnMouseDown(){
			Vector3 vec = Camera.main.ScreenToWorldPoint (Input.mousePosition);
			CapsuleCollider2D col2d = fish.GetComponent<CapsuleCollider2D> ();

			if (col2d.OverlapPoint(vec))
			{
			
			rb.AddForce(Vector2.up * 500);
			}

	
	}
	void OnCollisionEnter2D(Collision2D coll)
	{
		Debug.Log (coll);
		rb.AddForce (Vector2.down * 100);
	}
}
