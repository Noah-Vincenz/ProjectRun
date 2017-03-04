using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour {
	public GameObject prompt;
	public float wait;
	public WaitingRoom_Panda_Controller panda;

	bool clicked = false;

	// Use this for initialization
	void Start () {
		Debug.Log ("START!");
		StartCoroutine ("select_Prompt");
	}

	// Update is called once per frame
	void Update () {
		if (clicked) {
			Debug.Log ("Calling walk off");
			panda.walkOff (); // make panda leave 
		}
	}
	void OnMouseDown(){

		string tag = this.tag;
		Debug.Log (tag);

		switch (tag) {

		case "DMSA":
			clicked = true;
			//TODO Next scene for DMSA branch 
			break;

		case "Meckel" :
			clicked = true;
			//TODO Next scene for Meckel branch 
			break;

		case "RENOGRAMin" :
			clicked = true;
			//TODO Next scene for Renogram Indirect branch 
			break;

		case "Renogram" :
			clicked = true;
			//TODO Next scene for Renogram branch 
			break;

		default:
			Debug.Log ("Bad Tag: " + tag); // should'nt happen 
			break;
		}

	}

	IEnumerator select_Prompt()
	{
		Debug.Log("before wait ");
		yield return new WaitForSeconds(wait);
		Debug.Log("after wait ");
		if (!(clicked)) {
			Debug.Log("Select prompt active");
			prompt.SetActive (true);
		}
	}

}
