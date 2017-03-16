using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PeePeeScreenController : MonoBehaviour {
	Animator anim;
	public ToiletPandaController panda;
	public GameObject prompt;
	public GameObject prompt2;
	public GameObject speechBubble;
	int clicks;
	// Use this for initialization
	void Start () {
		clicks = 0;
		anim = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnMouseDown(){
		switch (clicks){

		case 0: 
			anim.SetTrigger ("MoveScreen");
			anim.SetBool ("moved", true);
//			panda.moveUp ();
			Destroy (prompt.gameObject);
			GetComponent<BoxCollider2D> ().enabled = false;
			++clicks;
			break;

		case 1:

			anim.SetTrigger ("moveBack");
			anim.SetBool ("moved", false);
			Destroy (prompt2.gameObject);
			GetComponent<BoxCollider2D> ().enabled = false;
			++clicks;
			break;
			
		}
			

	}

	/*
	 * methods called in animation events :)
	 * 
	 */
	void movePanda(){
		Debug.Log ("Call to movePanda");
		panda.moveUp ();
	}

	void movePandaDown(){
		Debug.Log ("Call to movePanda");
		panda.moveDown ();
	}

	void inProgreesText(){
		Debug.Log ("Call to inProgText");
		speechBubble.SetActive (true);
	}
	void activateBubble(){

		speechBubble.SetActive (true);

	}
}
