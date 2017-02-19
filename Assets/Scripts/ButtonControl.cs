using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonControl : MonoBehaviour {
	private SpriteRenderer sr;
	public Sprite pressed;
	public Sprite normal;
	public GameObject painting;
	// Use this for initialization
	void Start () {
		sr = gameObject.GetComponent<SpriteRenderer> ();
	}
	
	// Update is called once per frame
	void Update () {

		Vector3 vec = Camera.main.ScreenToWorldPoint (Input.mousePosition);
		BoxCollider2D coll = gameObject.GetComponent<BoxCollider2D> ();

		//Checks if click was on object only
		if (coll.OverlapPoint (vec)) {
			if (Input.GetMouseButton (0) ) {
				changeSprite ();
			} else
				sr.sprite = normal;
		
		}
	}
	void changeSprite(){
		Debug.Log("Button pressed");
		sr.sprite = pressed;

		//TODO button stuff

	}
	void OnMouseDown(){
		painting.GetComponent<Rigidbody2D> ().gravityScale = 1;
	}
}
