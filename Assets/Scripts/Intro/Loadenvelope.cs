using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Loadenvelope : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	
	void OnMouseDown(){
		NextScene();
	}
    
	public void NextScene(){
		SceneManager.LoadScene("envelope");
	}
	
}
