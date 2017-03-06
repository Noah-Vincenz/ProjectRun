using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using UnityEngine.SceneManagement;   for loading scene 

public class NextButtonController : MonoBehaviour {

	public GameObject menu;
	public GameObject textOne;
	public GameObject textTwo;
	public GameObject speechBubble;
	public WaitingRoom_Panda_Controller panda;
	string itemTag;
	private int clicks = 0;

	void OnMouseDown(){
		switch (clicks){

		case 0 :// show menu 
			menu.SetActive(true);
			speechBubble.SetActive (false); 
			Destroy (textOne.gameObject);
			++clicks;
			break;
		case 1: // panda leave 
			Debug.Log (tag);
			panda.walkOff ();// call to method to make panda walk away 
			Destroy (textOne.gameObject);
			Destroy (textTwo.gameObject);
			speechBubble.GetComponent<SpriteRenderer> ().enabled = false;
			transform.GetComponent<SpriteRenderer> ().enabled = false;
			break;

		}
	}
	/*
	 * setter for tag value 
	 */
	public void setTag(string _tag){

		itemTag = _tag;
	}
	/**
	 * method to laod new scene.
	 */
	public void loadNext(){

		switch (itemTag) { // switch dependant on selected game 
			
		case "DMSA":
			//TODO Next scene for DMSA branch 
			Debug.Log("LOAD DMSA");
			break;

		case "Meckel":
			Debug.Log("LOAD Meckel");
			//TODO Next scene for Meckel branch 
			break;

		case "RENOGRAMin":
			Debug.Log("LOAD Renogram Indirect");
			//TODO Next scene for Renogram Indirect branch 
			break;

		case "RENOGRAM":
			Debug.Log("LOAD Renogram");
			//TODO Next scene for Renogram branch 
			break;

		default:
			Debug.Log ("Bad Tag: " + tag); // should'nt happen 
			break;
		}

	}
}
