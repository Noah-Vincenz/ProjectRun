using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToiletNoScanPeePeeScreenController : MonoBehaviour {

	Animator anim;
	public ToiletPandaController panda;
	public GameObject prompt;
	public GameObject prompt2;
	public GameObject speechBubble;
	public GameObject finalText;
	public float wait;
	int clicks;
	// Use this for initialization
	void Start () {
		clicks = 0;
		anim = GetComponent<Animator>();
	}

	void OnMouseDown(){
		switch (clicks){

		case 0:  // move screen over panda
			anim.SetTrigger ("MoveScreen");
			anim.SetBool ("moved", true);
			StartCoroutine("scanWait");
			Destroy (prompt.gameObject);
			GetComponent<BoxCollider2D> ().enabled = false; // stops double click
			++clicks;
			break;

		case 1: // moves screen back to original position
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
		//		speechBubble.SetActive (true);
	}
	void activateBubble(){

		speechBubble.SetActive (true);

	}

	/**
	 * wait method 
	 */
	IEnumerator scanWait()
	{
		yield return new WaitForSeconds(wait);
		GetComponent<BoxCollider2D> ().enabled = true;
		prompt2.SetActive (true);
		finalText.SetActive (true);
	}
}
