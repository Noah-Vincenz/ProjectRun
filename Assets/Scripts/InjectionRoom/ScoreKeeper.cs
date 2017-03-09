using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreKeeper : MonoBehaviour {
	public int Score;
	public Text ScoreBoard;

	// Use this for initialization
	void Start () {
		Score = 0;
	}
	
	// Update is called once per frame
	void Update () {
		ScoreBoard.text = "" + Score;
	}
}
