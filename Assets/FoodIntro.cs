using System.Collections;
using UnityEngine.UI;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;


public class FoodIntro : MonoBehaviour {

	private int click = 0;
	private Rigidbody2D rb;

	public GameObject speechBub;
	public GameObject text1;
	public GameObject text2;
	public GameObject arrow;
	public GameObject FoodInstructions;
	public GameObject startBtn;
	private bool firstClick = true;
	public GameObject background;
	float timeLeftforTransition=2;
	private bool readyToTransition;


	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody2D> ();
		readyToTransition = false;
		var material1 = background.GetComponent<Renderer>().material;
		var color1 = material1.color;
		//background.GetComponent<Renderer> ().material.color = new Color (color1.r, color1.g, color1.b, color1.a -color1.a);fz

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
		var material = background.GetComponent<Renderer>().material;
		var color = material.color;
		if (readyToTransition) {
			Debug.Log ("ds");
			background.SetActive (enabled);
			material.color = new Color (color.r, color.g, color.b, color.a + (1f * Time.deltaTime));
			timeLeftforTransition -= Time.deltaTime;
		}

		if (timeLeftforTransition <= 0) {
			SceneManager.LoadScene ("FoodGame");
		}

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
			FoodInstructions.GetComponent<Renderer> ().enabled = true;// renders instructions
			arrow.GetComponent<Renderer> ().enabled = false;
			startBtn.GetComponent<SpriteRenderer> ().enabled = true;
			startBtn.GetComponent<StartBtnScript> ().enabled = true;
			++click;
			break;
//
//		default :
//			speechBub.GetComponent<Renderer> ().enabled = true;// renders speech bubble
//			break;

		}


	}

	void TaskOnClick()
	{
		Debug.Log ("d");
		readyToTransition = true;
	}

}
