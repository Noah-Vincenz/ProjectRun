using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneManagerController : MonoBehaviour {
	public static SceneManagerController Instance = null;

	private string procedure ; // saves procedure 

	/**
	 * singleton object- can only ever be one instance of this 
	 */
	void Awake()
	{
		if (Instance == null) { // only have one instance of this object 
			Instance = this;
			DontDestroyOnLoad (gameObject); // game object never destroyed between scenes 
		} else {
			DestroyImmediate (gameObject);
		}
	}
	/**
	 * public mehtod to get the procedure - for loading scenes
	 */
	public string getProcedure(){

		return procedure;
	}
	/**
	 * method to set procedure
	 */
	public void setProcedure(string _procedure){

		procedure = _procedure;
	}

}
