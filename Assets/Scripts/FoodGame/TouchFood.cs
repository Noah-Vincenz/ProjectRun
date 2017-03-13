using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchFood : MonoBehaviour {

	public int scoreIncrease = 20;
	public float scoreDelay = 2;
	public static int foodScore;
	GameObject pandaFaceEmotionObject;
	GameObject normalFace;
	GameObject sadFace;
	GameObject food;
	float timeLeftAnimation=2;
	GameObject ScoreKeeperScoreBoard;
	ScoreKeeper scoreKeeper;
	Timer timerScript;
	SpriteRenderer spriteRenderer;
	bool sad=false;
	float nTime;

	// Use this for initialization
	void Start () {
		nTime = Time.time;
		pandaFaceEmotionObject = GameObject.Find ("PandaFaceReaction");
		normalFace = pandaFaceEmotionObject.transform.Find ("Normal Face").gameObject;
		sadFace = pandaFaceEmotionObject.transform.Find ("SadFace").gameObject;
		ScoreKeeperScoreBoard = GameObject.Find ("Canvas/ScoreBoard").gameObject;
		timerScript = GameObject.Find ("Canvas/Timer").gameObject.GetComponent<Timer> ();
		scoreKeeper = ScoreKeeperScoreBoard.GetComponent<ScoreKeeper> ();

	}
	
	// Update is called once per frame
	void Update () {
		//Debug.Log (foodScore);
		if (nTime < Time.time && timerScript.getTime() > 1) {
			scoreKeeper.Score += scoreIncrease;
			nTime = Time.time + scoreDelay;
		}

		if (sad) {
			if (timeLeftAnimation >= 1) {
				timeLeftAnimation -= Time.deltaTime;
				normalFace.SetActive (false);
				sadFace.SetActive (true);
			} else {
				timeLeftAnimation = 2;
				sad = false;
				sadFace.SetActive (false);
				normalFace.SetActive (true);
			}
		}
		foodScore = scoreKeeper.Score;
	}

	void OnCollisionEnter2D(Collision2D coll) {

		if(coll.gameObject.tag == "Food" && timerScript.getTime() > 1){
				scoreKeeper.Score -=100;
				sad = true;
			}
			
		}
}
