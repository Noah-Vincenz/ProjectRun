using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/*
 * Loads the next scene on mouse down
 * 
 */

public class OpenLetterLoad : MonoBehaviour {

	void OnMouseDown(){
		NextScene ();
		
	}

	public void NextScene(){
		SceneManager.LoadScene("OpenedLetter");

	}
}
