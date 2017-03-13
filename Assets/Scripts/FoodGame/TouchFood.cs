using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchFood : MonoBehaviour {

	GameObject pandaFaceEmotionObject;
	GameObject normalFace;
	GameObject sadFace;
	float timeLeftAnimation=2;
	GameObject ScoreKeeperScoreBoard;
	ScoreKeeper scoreKeeper;
	SpriteRenderer spriteRenderer;
	bool sad=false;

	// Use this for initialization
	void Start () {
		pandaFaceEmotionObject = GameObject.Find ("PandaFaceReaction");
		normalFace = pandaFaceEmotionObject.transform.Find ("Normal Face").gameObject;
		sadFace = pandaFaceEmotionObject.transform.Find ("SadFace").gameObject;
		ScoreKeeperScoreBoard = GameObject.Find ("Canvas/ScoreBoard").gameObject;
		scoreKeeper = ScoreKeeperScoreBoard.GetComponent<ScoreKeeper> ();
		
	}
	
	// Update is called once per frame
	void Update () {
		if (sad) {
			if (timeLeftAnimation >= 1) {
				timeLeftAnimation -= Time.deltaTime;
				normalFace.SetActive (false);
				sadFace.SetActive (true);
			} 
			else {
				timeLeftAnimation = 2;
				sad= false;
				sadFace.SetActive (false);
				normalFace.SetActive (true);
			}
		}
		
	}

	void OnCollisionEnter2D(Collision2D coll) {

			if(coll.gameObject.tag == "Food"){
				scoreKeeper.Score -=100;
				sad = true;
			}
			
		}
}
