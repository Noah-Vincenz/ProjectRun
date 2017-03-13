﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ScoreKeeper : MonoBehaviour {
	public int Score;
    public static int finalScore;
	public Text ScoreBoard;
    public static string recentGame;

	// Use this for initialization
	void Start () {
        recentGame = SceneManager.GetActiveScene().name;
		Score = 0;
	}
	
	// Update is called once per frame
	void Update () {
		ScoreBoard.text = "" + Score;
        finalScore = Score;
        
	}
}
