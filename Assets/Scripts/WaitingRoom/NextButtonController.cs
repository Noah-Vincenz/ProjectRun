using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NextButtonController : MonoBehaviour {

	public GameObject button1;
	public GameObject button2;
	public GameObject button3;
	public GameObject button4;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	void OnMouseDown(){

		ShowMenu ();

	}

	void ShowMenu(){

		button1.GetComponent<Renderer> ().enabled = true;
		button2.GetComponent<Renderer> ().enabled = true;
		button3.GetComponent<Renderer> ().enabled = true;
		button4.GetComponent<Renderer> ().enabled = true;

	}
}
