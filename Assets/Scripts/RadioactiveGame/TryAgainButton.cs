﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.Assertions;

//Button that enables you to restart the game
public class TryAgainButton : MonoBehaviour {

	void Start () {
		gameObject.SetActive (false);
		Button btn = gameObject.GetComponent<Button>();
		btn.onClick.AddListener(TaskOnClick);
		Assert.IsFalse(gameObject.activeInHierarchy, "TryAgainButton is active, but should not be.");
	}

	void TaskOnClick(){
		Assert.IsTrue(gameObject.activeInHierarchy, "TryAgainButton is not active.");
		SceneManager.LoadScene ("CatchRadiationGame");
	}
}