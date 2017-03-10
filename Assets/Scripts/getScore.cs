using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class getScore : MonoBehaviour {
    public Text scoreText = null;
    public Sprite[] backgrounds;
    public GameObject background;
	void Start () {

        background = GameObject.Find("Background");
        if (countdown.gameName == "InjectionGame")
        {
            background.GetComponent<SpriteRenderer>().sprite = backgrounds[0];
            scoreText.text = "Your score is : " + ScoreKeeper.injectionScore;
            ScoreKeeper.injectionScore = 0;
        }
	}

}
