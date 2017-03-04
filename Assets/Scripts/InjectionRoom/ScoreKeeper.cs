using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ScoreKeeper : MonoBehaviour {
	public int Score;
    public static int injectionScore;
	public Text ScoreBoard;

	// Use this for initialization
	void Start () {
		Score = 0;
	}
	
	// Update is called once per frame
	void Update () {
		ScoreBoard.text = "" + Score;
        injectionScore = Score;
	}
}
