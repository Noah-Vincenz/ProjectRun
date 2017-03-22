using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToiletNextBtnController : MonoBehaviour {
	public ToiletPandaController pandaSC;
	public GameObject playerPanda;
	public GameObject text1;
	public GameObject text2;
	public GameObject text3;
	public GameObject speechBubble;
	public GameObject prompt2;
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
//			text2.SetActive (true);
			++clicks;
			break;

		case 1: // end scene walk off
			Destroy (speechBubble.gameObject);
			Destroy (text3.gameObject);
			pandaSC.walkOff ();
			break;
		default : 
			Debug.Log ("Click");
			break;

		}
	}
}
