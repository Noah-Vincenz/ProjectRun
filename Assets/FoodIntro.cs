using System.Collections;
using UnityEngine.UI;
using System.Collections;
using UnityEngine;
using UnityEngine.Events;

public class FoodIntro : MonoBehaviour {

	private int click = 0;
	private Rigidbody2D rb;

	public GameObject speechBub;
	public GameObject text1;
	public GameObject text2;
	public GameObject arrow;
	public GameObject FoodInstructions;
	public GameObject startButton;
	private bool firstClick = true;


	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody2D> ();

	}
//
//	void Clicked(){
//		speechBub.GetComponent<Renderer> ().enabled = true;// renders speech bubble
//		text1.GetComponent<Renderer> ().enabled = false;// renders text 1
//		text2.GetComponent<Renderer> ().enabled = true;
//		arrow.GetComponent<Renderer> ().enabled = true; //renders the arrow
//	}
//
	
	// Update is called once per frame
	void Update () {
		if (Input.GetMouseButtonDown(0) && click == 0){
			Debug.Log("0 button clicked" + firstClick);
			speechBub.GetComponent<Renderer> ().enabled = true;// renders speech bubble
			text1.GetComponent<Renderer> ().enabled = true;// renders text 2
			arrow.GetComponent<Renderer> ().enabled = true; //renders the arrow
			++click;
		}
//		(Input.GetMouseButtonDown (0) && click == 1) {
//			Debug.Log ("Panda Click event 2");
//			firstClick = false;
//			Destroy (text1.gameObject);
//			text2.GetComponent<Renderer> ().enabled = true;// renders text 2
//			++click;
//		}
	}


	void OnMouseDown(){

		Debug.Log ("Clicks:" + click);
		switch (click) {

//		case 0: // show speech bubble 
//			Debug.Log ("Panda Click event 1");
//			speechBub.GetComponent<Renderer> ().enabled = true;// renders speech bubble
//			text1.GetComponent<Renderer> ().enabled = true;// renders text 2
//			arrow.GetComponent<Renderer> ().enabled = true; //renders the arrow
//			++click;
//			break;
		case 1:// show text 
			Debug.Log ("Panda Click event 2");
//			firstClick = false;
			Destroy (text1.gameObject);
			text2.GetComponent<Renderer> ().enabled = true;// renders text 2
			++click;
			break;
		case 2:// show text 
			Debug.Log ("Panda Click event 3");
			//			firstClick = false;
			Destroy (text2.gameObject);
			Destroy (speechBub.gameObject);
			Destroy (arrow.gameObject);
			FoodInstructions.GetComponent<Renderer> ().enabled = true;// renders instructions
			startButton.GetComponent<Renderer>().enabled = true; //renders start button
			++click;
			break;
//
//		default :
//			speechBub.GetComponent<Renderer> ().enabled = true;// renders speech bubble
//			break;

		}


	}

}
