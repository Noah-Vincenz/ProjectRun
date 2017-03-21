using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneManagerController : MonoBehaviour {
	public static SceneManagerController Instance = null;

	private string procedure ;

	void Awake()
	{
		if (Instance == null) { // only have one instance of this object 
			Instance = this;
			DontDestroyOnLoad (gameObject);
		} else {
			DestroyImmediate (gameObject);
		}
	}
	public string getProcedure(){

		return procedure;
	}
	public void setProcedure(string _procedure){

		procedure = _procedure;
	}

}
