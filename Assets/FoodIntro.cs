using System.Collections;
using UnityEngine.UI;
using System.Collections;
using UnityEngine;

public class FoodIntro : MonoBehaviour {

	private int click = 0;
	public ButtonControl nextButton;

	public GameObject speechBub;
	public GameObject text1;
	public GameObject text2;
	public GameObject arrow;


	// Use this for initialization
	void Start () {
//		ButtonControl btn = nextButton.GetComponent<Button> ();
//		btn.onClick.AddListener (Clicked);

	}

	void Clicked(){
		speechBub.GetComponent<Renderer> ().enabled = true;// renders speech bubble
		text1.GetComponent<Renderer> ().enabled = false;// renders text 1
		text2.GetComponent<Renderer> ().enabled = true;
		arrow.GetComponent<Renderer> ().enabled = true; //renders the arrow
	}

	
	// Update is called once per frame
	void Update () {
		if (Input.GetMouseButtonDown(0)){
		Debug.Log("0 button clicked");
			speechBub.GetComponent<Renderer> ().enabled = true;// renders speech bubble
			text1.GetComponent<Renderer> ().enabled = true;// renders text 2
			arrow.GetComponent<Renderer> ().enabled = true; //renders the arrow
			++click;
		}

	}

	void onMouseDown(){

		Debug.Log ("Clicks:" + click);
		switch (click) {

		case 0: // show speech bubble 
			Debug.Log ("Panda Click event 1");
			speechBub.GetComponent<Renderer> ().enabled = true;// renders speech bubble
			text1.GetComponent<Renderer> ().enabled = true;// renders text 2
			arrow.GetComponent<Renderer> ().enabled = true; //renders the arrow
			++click;
			break;
//		case 1:// show text 
//			Debug.Log ("Panda Click event 2");
//			text2.GetComponent<Renderer> ().enabled = true;// renders text 2
//			++click;
//			break;

		default :
			speechBub.GetComponent<Renderer> ().enabled = true;// renders speech bubble
			break;

		}


	}

}
