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
	public GameObject background;
	public GameObject prompt;


	private bool firstClick = true;
	private bool readyToTransition;
	private bool interacted = false;

	public float wait;

	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody2D> ();
		StartCoroutine ("prompt_time");
		speechBub.SetActive (false);

	}
	// Update is called once per frame
	void Update () {
		if (Input.GetMouseButtonDown(0) && click == 0){
			Debug.Log("0 button clicked" + firstClick);
			interacted = true; //stops prompt
			prompt.SetActive (false); //removes the prompt
			speechBub.SetActive(true);
			//speechBub.GetComponent<Renderer> ().enabled = true;// renders speech bubble
			text1.SetActive(true);
			arrow.GetComponent<Renderer> ().enabled = true; //renders the arrow
			++click;
		}
	}


	void OnMouseDown(){

		Debug.Log ("Clicks:" + click);
		switch (click) {
		case 1:// show text 
			Debug.Log ("Panda Click event 2");
//			firstClick = false;
			Destroy (text1.gameObject);
			text2.SetActive (true);
			//text2.GetComponent<Renderer> ().enabled = true;// renders text 2
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

		}


	}

	IEnumerator prompt_time()
	{
		yield return new WaitForSeconds(wait);
		if (!(interacted)) {
			prompt.SetActive (true);
		}
	}

}
