using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ContinueButton : MonoBehaviour {

	void Start () {
		gameObject.SetActive (false);
		Button btn = gameObject.GetComponent<Button>();
		btn.GetComponentInChildren<Text>().text = "Continue";
		btn.onClick.AddListener(TaskOnClick);
	}

	void TaskOnClick(){
		Application.LoadLevel (Application.loadedLevel);
	}
}
