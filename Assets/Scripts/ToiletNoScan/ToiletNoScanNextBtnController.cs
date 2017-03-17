using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToiletNoScanNextBtnController : MonoBehaviour {

	public ToiletPandaController pandaSC;
	public GameObject playerPanda;
	public GameObject text1;
	public GameObject text2;
	public GameObject speechBubble;
	public GameObject screen;

	int clicks;


	// Use this for initialization
	void Start () {
		clicks = 0; 
	}


	void OnMouseDown(){
		switch (clicks){

		case 0:// activate panda & disable speech bubble 

			playerPanda.SetActive (true);
			Destroy (text1.gameObject);
			speechBubble.SetActive (false);
			++clicks;
			break;

		case 1: // end scene walk off
			Destroy (speechBubble.gameObject);
			pandaSC.walkOff ();
			break;
		default : 
			Debug.Log ("Click");
			break;

		}
	}
}
