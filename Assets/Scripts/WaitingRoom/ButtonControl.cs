using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonControl : MonoBehaviour {
	private SpriteRenderer sr;
	private SpriteRenderer sunSR;
	public Sprite pressed;
	public Sprite normal;
	public Sprite moon;
	public Sprite sun;
	public GameObject sunObj;
	public GameObject Sky;	

	private int click = 0; 
	private float fadeSpeed = 0.5f;
	private bool isPressed;
	private Animator anim;


	// Use this for initializa	tion
	void Start () {
		isPressed = false;
		sr = gameObject.GetComponent<SpriteRenderer> ();
		sunSR = sunObj.GetComponent<SpriteRenderer> ();
		anim = sunObj.GetComponent<Animator> ();
	}
	
	// Update is called once per frame
	void Update () {
		var material = Sky.GetComponent<Renderer>().material;
		var color = material.color;

		if (click == 2) { // fade sky to transparent to show night sky
			if(color.a>=0)
				material.color = new Color(color.r, color.g, color.b, color.a - (fadeSpeed * Time.deltaTime));

		}

		if (click == 0) { // bring back day sky 
			if(color.a<=1)
				material.color = new Color(color.r, color.g, color.b, color.a+ (fadeSpeed * Time.deltaTime) );
		}

		if (isPressed){ // change sprite for red button pressed 
			sr.sprite = pressed;
		}
		else
			sr.sprite = normal;
	}

	void OnMouseDown(){
		isPressed =true; // change button sprite 
		switch (click) {

		case 0: // sun rise 
			if(anim.GetCurrentAnimatorStateInfo (0).IsName ("Idle_Down")){
				sunSR.sprite = sun;
				riseAnim();
				++click;
			}
			break;
		case 1: // sun set 
			if (anim.GetCurrentAnimatorStateInfo (0).IsName ("Idle_Up")) {
				setAnim ();
				++click;
			}
			break;
		
		case 2: // moon rise 
			if (anim.GetCurrentAnimatorStateInfo (0).IsName ("Idle_Down")) {
				sunSR.sprite = moon;
				riseAnim ();
				++click;
			}
			break;
		
		case 3: // moon set 
			if (anim.GetCurrentAnimatorStateInfo (0).IsName ("Idle_Up")) {
				setAnim ();
				click = 0;
			}
			break;
		}

	
	}
	/**
	 * method to trigger rise animation 
	 */
	void setAnim(){
		anim.SetTrigger ("Set");
		anim.SetBool ("Up", false);
		anim.SetBool ("Down", true);
	}
	/**
	 * mehtod to trigger set animation
	 */
	void riseAnim(){
		anim.SetTrigger ("Rise");
		anim.SetBool ("Up", true);
		anim.SetBool ("Down", false);

	}
	void OnMouseUp(){
		isPressed = false;
	}
}
