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
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnMouseDown(){
		switch (clicks){

		case 0:// activate panda & disable speech bubble 

			playerPanda.SetActive (true);
			Destroy (text1.gameObject);
			speechBubble.SetActive (false);
			text2.SetActive (true);
			++clicks;
			break;
			
		case 1: 
			Destroy (text2.gameObject);
			speechBubble.SetActive (false);
			text3.SetActive (true);
			prompt2.SetActive (true);
			screen.GetComponent<BoxCollider2D> ().enabled = true;
			++clicks;
			break;

		case 2:
			Destroy (speechBubble.gameObject);
			pandaSC.walkOff ();
			break;
		default : 
			Debug.Log ("Click");
			break;

		}
	}
}
