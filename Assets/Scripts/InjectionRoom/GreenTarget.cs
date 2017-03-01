using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GreenTarget : MonoBehaviour {

	// Use this for initialization

	bool happy=false;
	GameObject pandaFaceEmotionObject;
	GameObject happyFace;
	GameObject normalFace;
	float timeLeftAnimation=2;
	float timeLeftTillDestroy=5;
	GameObject ScoreKeeperScoreBoard;
	ScoreKeeper scoreKeeper;
	SpriteRenderer spriteRenderer;
	CircleCollider2D coll;
	public Sprite star; 

	void Start () {
		pandaFaceEmotionObject = GameObject.Find ("PandaFaceReaction");
		happyFace = pandaFaceEmotionObject.transform.Find ("Happy Face").gameObject;
		normalFace = pandaFaceEmotionObject.transform.Find ("Normal Face").gameObject;
		ScoreKeeperScoreBoard = GameObject.Find ("Canvas/ScoreBoard").gameObject;
		scoreKeeper = ScoreKeeperScoreBoard.GetComponent<ScoreKeeper> ();
		spriteRenderer = gameObject.GetComponent<SpriteRenderer>(); 
		coll = gameObject.GetComponent<CircleCollider2D> ();
	}
	
	// Update is called once per frame
	void Update () {
		timeLeftTillDestroy -= Time.deltaTime;
		if (happy) {
			if (timeLeftAnimation >= 1) {
				timeLeftAnimation -= Time.deltaTime;
				normalFace.SetActive (false);
				happyFace.SetActive (true);
			} 
			else {
				timeLeftAnimation = 2;
				happy= false;
				normalFace.SetActive (true);
				happyFace.SetActive (false);
				Destroy (gameObject);
			}
		}

		if (timeLeftTillDestroy <= 0) {
			scoreKeeper.Score -=100;
			Destroy (gameObject);
		}

		
	}
	void OnMouseDown(){
		Debug.Log ("s");
		scoreKeeper.Score +=100;
		happy = true;
		gameObject.transform.localScale = new Vector3 (0.02f, 0.02f, 0.02f);
		spriteRenderer.sprite = star;
		coll.enabled = false;

	}
		
}
