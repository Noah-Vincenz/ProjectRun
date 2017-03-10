using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RedTargetControl : MonoBehaviour {

	// Use this for initialization
	bool sad=false;
	public GameObject pandaFaceEmotionObject;
	public GameObject sadFace;
	public GameObject normalFace;
	GameObject happyFace;
	float timeLeftAnimation=2;
	float timeLeftTillDestroy=3;
	public GameObject ScoreKeeperScoreBoard;
	ScoreKeeper scoreKeeper;
	SpriteRenderer spriteRenderer;
	CircleCollider2D coll;

	void Start () {
		pandaFaceEmotionObject = GameObject.Find ("PandaFaceReaction");
		sadFace = pandaFaceEmotionObject.transform.Find ("SadFace").gameObject;
		normalFace = pandaFaceEmotionObject.transform.Find ("Normal Face").gameObject;
		happyFace = pandaFaceEmotionObject.transform.Find ("Happy Face").gameObject;
		ScoreKeeperScoreBoard = GameObject.Find ("Canvas/ScoreBoard").gameObject;
		scoreKeeper = ScoreKeeperScoreBoard.GetComponent<ScoreKeeper> ();
		spriteRenderer = gameObject.GetComponent<SpriteRenderer>(); 
		coll = gameObject.GetComponent<CircleCollider2D> ();

	}

	// Update is called once per frame
	void Update () {
		timeLeftTillDestroy -= Time.deltaTime;
		if (sad) {
			if (timeLeftAnimation >= 1) {
				timeLeftAnimation -= Time.deltaTime;
				happyFace.SetActive (false);
				normalFace.SetActive (false);
				sadFace.SetActive (true);
			} 
			else {
				timeLeftAnimation = 2;
				sad= false;
				happyFace.SetActive (false);
				normalFace.SetActive (true);
				sadFace.SetActive (false);
				Destroy (gameObject);
			}
		}

		if (timeLeftTillDestroy <= 0) {
			scoreKeeper.Score +=100;
			Destroy (gameObject);
		}

	}
	void OnMouseDown(){
		scoreKeeper.Score -=100;
		sad = true;
		spriteRenderer.enabled=false;
		coll.enabled = false;
	}
}
