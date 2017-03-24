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
        if (ScoreKeeper.recentGame== "InjectionGame")
        {
            background.GetComponent<SpriteRenderer>().sprite = backgrounds[0];
            scoreText.text = "Your score is : " + ScoreKeeper.finalScore;
            ScoreKeeper.finalScore = 0;
        } else
        if (ScoreKeeper.recentGame == "FoodGame")
        {
            background.GetComponent<SpriteRenderer>().sprite = backgrounds[2];
            scoreText.text = "Your score is : " + ScoreKeeper.finalScore;
            ScoreKeeper.finalScore = 0;
        }
	}

}
