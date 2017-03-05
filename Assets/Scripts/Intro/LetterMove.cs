using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;



public class LetterMove : MonoBehaviour {

    Animator anim;
	SpriteRenderer sp;
	public Sprite back;
	private int clicks = 0;
	public Sprite openLet;
	public GameObject swapBottom;
	public GameObject swapTop;

	// Use this for initialization
	void Start () {
		anim = GetComponent<Animator>();
		anim.SetTrigger("Drop");
		anim.SetBool("Dropped",true);
		sp = GetComponent<SpriteRenderer>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	
	void ChangeSprite(){
		sp.sprite = back;
	}

	void OnMouseDown(){
		switch (clicks){
		case 0:
			anim.SetTrigger ("flip");
			anim.SetBool ("flipped", true);
			++clicks;
			break;
		//case 1:
			//sp.sprite = openLet;
			//++clicks;
			//break;

		 default:
			break;
		}
    }

	void swapobjects(){
		swapBottom.GetComponent<SpriteRenderer> ().enabled=true;
		swapTop.GetComponent<SpriteRenderer> ().enabled = true;
		Destroy (this.gameObject);

	}

}
