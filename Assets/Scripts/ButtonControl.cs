using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonControl : MonoBehaviour {
	private SpriteRenderer sr;
	public Sprite pressed;
	public Sprite normal;
	public GameObject sun;
	public GameObject moon;
	public float gravitySpeed;
	private int click = 0; 
	public GameObject Sky;	
	private float fadeSpeed = 0.5f;
	private Rigidbody2D rbMoon;
	private Rigidbody2D rbSun;
	private bool isPressed;


	// Use this for initializa	tion
	void Start () {
		isPressed = false;
		rbSun = sun.GetComponent<Rigidbody2D> ();
		rbMoon = moon.GetComponent<Rigidbody2D> ();
		sr = gameObject.GetComponent<SpriteRenderer> ();
	}
	
	// Update is called once per frame
	void Update () {
		var material = Sky.GetComponent<Renderer>().material;
		var color = material.color;

		Vector3 vec = Camera.main.ScreenToWorldPoint (Input.mousePosition);
		BoxCollider2D coll = gameObject.GetComponent<BoxCollider2D> ();

		//Checks if click was on object only


		if (click == 2) {
			if(color.a>=0)
			material.color = new Color(color.r, color.g, color.b, color.a - (fadeSpeed * Time.deltaTime));
			
		}

		if (click == 0) {
			if(color.a<=1)
			material.color = new Color(color.r, color.g, color.b, color.a+ (fadeSpeed * Time.deltaTime) );
		}

		if (isPressed){
			sr.sprite = pressed;
			if (rbSun.IsSleeping () && rbMoon.IsSleeping ()) {
				isPressed = false;
			}
		}
		else
			sr.sprite = normal;
	}

	void OnMouseDown(){
		isPressed =true;
		switch (click) {
		case 0:
			if (rbSun.IsSleeping() && rbMoon.IsSleeping()) {
				
				sun.GetComponent<Rigidbody2D> ().gravityScale = -gravitySpeed;
				++click;
				break;

			} else
				break;
		case 1:
			
			if (rbSun.IsSleeping() && rbMoon.IsSleeping()) {
				
				sun.GetComponent<Rigidbody2D> ().gravityScale = gravitySpeed;
				++click;
				break;
			} 
			else
				break;
		
		case 2:
			if (rbSun.IsSleeping() && rbMoon.IsSleeping()) {
				
				moon.GetComponent<Rigidbody2D> ().gravityScale = -gravitySpeed;
				++click;
				break;
			} else
				break;
		
		case 3:
			if (rbSun.IsSleeping()&& rbMoon.IsSleeping()) {
				
				moon.GetComponent<Rigidbody2D> ().gravityScale = gravitySpeed;
				click = 0;
				break;
			} else
				break;

		}

	}
}
