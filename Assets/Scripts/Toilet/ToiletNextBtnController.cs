using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToiletNextBtnController : MonoBehaviour {
//	public ToiletPandaController panda;
	public GameObject playerPanda;
	public GameObject text1;
	public GameObject text2;
	public GameObject speechBubble;

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
			text2.SetActive (true);
			speechBubble.SetActive (false);
			++clicks;
			break;
			
		case 1: 
				
				++clicks;
			break;

		default : 
			break;

		}
	}
}
