using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NextButtonController : MonoBehaviour {

	public GameObject menu;

	public GameObject speechBubble;


	private int clicks = 0; 


	// Use this for initialization
	void Start () {

	}

	// Update is called once per frame
	void Update () {

	}
	void OnMouseDown(){
		
		Debug.Log ("Next button pressed! (1) ");
		menu.SetActive(true);
		speechBubble.SetActive (false);
		Destroy (speechBubble.gameObject);
	}
}
