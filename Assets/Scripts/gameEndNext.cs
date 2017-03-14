using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class gameEndNext : MonoBehaviour {

    public bool clicked = false;
	// Use this for initialization
	void Start () {
        if (ScoreKeeper.recentGame == "FoodGame")
        {
            SceneManager.LoadScene("Injection");
        }
        else
        if (ScoreKeeper.recentGame == "InjectionGame")
        {
            SceneManager.LoadScene("ScanningRoom");
        }
    }
}

   
