using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeCouchColor : MonoBehaviour {

	public Sprite couchcolor1; 
	public Sprite couchcolor2; 
	public Sprite couchcolor3; 
	public Sprite couchcolor4; 
	public GameObject couch;
	SpriteRenderer spriteRenderer;

	// Use this for initialization
	void Start () {
		
		spriteRenderer = gameObject.GetComponent<SpriteRenderer>(); 
	}
		
	//On Mouse click change color of couch...simply changes the sprite depending on previous sprite
	void OnMouseDown(){

		if (spriteRenderer.sprite == couchcolor1)
			spriteRenderer.sprite = couchcolor2;
			
		else if (spriteRenderer.sprite == couchcolor2)
			spriteRenderer.sprite = couchcolor3;
			
		else if (spriteRenderer.sprite == couchcolor3)
			spriteRenderer.sprite = couchcolor4;
			
		else if (spriteRenderer.sprite == couchcolor4)
			spriteRenderer.sprite = couchcolor1;

	}
}
	
