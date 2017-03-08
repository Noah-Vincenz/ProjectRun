using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TryAgainButton : MonoBehaviour {

	void Start () {
		gameObject.SetActive (false);
		Button btn = gameObject.GetComponent<Button>();
		btn.onClick.AddListener(TaskOnClick);
	}

	void TaskOnClick(){
		SceneManager.LoadScene ("CatchRadiationGame");
		//Application.LoadLevel ("CatchRadiationGame");
		Time.timeScale = 1;
	}


}
