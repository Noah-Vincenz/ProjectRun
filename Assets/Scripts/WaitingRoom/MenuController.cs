using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	void OnMouseDown(){
		
		string tag = this.tag;
		Debug.Log (tag);

		switch (tag) {

		case "DMSA" :
			//TODO Next scene for DMSA branch 
			break;

		case "Meckel" :
			//TODO Next scene for Meckel branch 
			break;

		case "RENOGRAMin" :
			//TODO Next scene for Renogram Indirect branch 
			break;

		case "Renogram" :
			//TODO Next scene for Renogram branch 
			break;

		default:
			Debug.Log ("Bad Tag: " + tag); // should'nt happen 
			break;
		}


	}
}
