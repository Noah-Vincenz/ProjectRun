using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadTest : MonoBehaviour {
	SceneManagerController procedure;
	// Use this for initialization
	void Start () {

		procedure = GameObject.Find ("SceneManager").GetComponent<SceneManagerController>();


		
	}
	
	// Update is called once per frame
	void Update () {
		//for testing 
		Debug.Log (procedure.getProcedure ());
		
	}
}
