using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TryAgainButton : MonoBehaviour {

	void Start () {
		gameObject.SetActive (false);
		Button btn = gameObject.GetComponent<Button>();
		btn.GetComponentInChildren<Text>().text = "Try Again";
		btn.onClick.AddListener(TaskOnClick);
	}

	void TaskOnClick(){
		Application.LoadLevel ("CatchRadiationGame");
		Time.timeScale = 1;
	}
}
