using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class getScore : MonoBehaviour {
    public Text scoreText = null;
	void Start () {
		if (SceneManager.GetActiveScene().name == "InjectionEnd")
        {
            scoreText.text = "Your score is : " + ScoreKeeper.injectionScore;
            ScoreKeeper.injectionScore = 0;
        }
	}

}
