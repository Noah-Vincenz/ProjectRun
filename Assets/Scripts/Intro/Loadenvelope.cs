using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/**
 * This script loads the scene envelope when the screen is clicked. 
 * loads next screen on mouse down.
 * 
 */

public class Loadenvelope : MonoBehaviour {

	void OnMouseDown(){
		NextScene();
	}
    
	public void NextScene(){
		SceneManager.LoadScene("envelope");
	}
	
}
