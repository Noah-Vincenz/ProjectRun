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
	GameObject sadFace;
	float timeLeftAnimation=2;
	float timeLeftTillDestroy=5;
	GameObject ScoreKeeperScoreBoard;
	ScoreKeeper scoreKeeper;
	SpriteRenderer spriteRenderer;
	CircleCollider2D coll;
	public GameObject starCelebration;
	private GameObject instantiatedObj;
	public AudioSource source;

	void Start () {
		pandaFaceEmotionObject = GameObject.Find ("PandaFaceReaction");
		happyFace = pandaFaceEmotionObject.transform.Find ("Happy Face").gameObject;
		normalFace = pandaFaceEmotionObject.transform.Find ("Normal Face").gameObject;
		sadFace = pandaFaceEmotionObject.transform.Find ("SadFace").gameObject;
		ScoreKeeperScoreBoard = GameObject.Find ("Canvas/ScoreBoard").gameObject;
		scoreKeeper = ScoreKeeperScoreBoard.GetComponent<ScoreKeeper> ();
		spriteRenderer = gameObject.GetComponent<SpriteRenderer>(); 
		coll = gameObject.GetComponent<CircleCollider2D> ();
		source = GetComponent<AudioSource>();
	}
	
	// Update is called once per frame
	void Update () {
		timeLeftTillDestroy -= Time.deltaTime;
		if (happy) {
			if (timeLeftAnimation >= 1) {
				timeLeftAnimation -= Time.deltaTime;
				sadFace.SetActive (false);
				normalFace.SetActive (false);
				happyFace.SetActive (true);
			} 
			else {
				timeLeftAnimation = 2;
				happy= false;
				sadFace.SetActive (false);
				normalFace.SetActive (true);
				happyFace.SetActive (false);
				Destroy (instantiatedObj);
				Destroy (gameObject);
			}
		}

		if (timeLeftTillDestroy <= 0) {
			scoreKeeper.Score -=100;
			Destroy (gameObject);
		}

		
	}
	void OnMouseDown(){
		source.Play ();
		scoreKeeper.Score +=100;
		happy = true;
		spriteRenderer.enabled = false;	
		coll.enabled = false;
		instantiatedObj= Instantiate(starCelebration,gameObject.transform.position,starCelebration.transform.rotation);
	}
		
}
