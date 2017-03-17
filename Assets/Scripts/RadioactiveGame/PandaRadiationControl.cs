using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class PandaRadiationControl : MonoBehaviour {

	bool happy=false;
	bool sad=false;
	GameObject pandaFaceEmotionObject;
	GameObject happyFace;
	GameObject normalFace;
	GameObject sadFace;
	float timeLeftAnimation=2;
	public float speed;
	public GameObject face;
	public int count; 
	public Text countText;
	public Text winText;
	public Text gameOverText;
	public Text timerLabel;
	private float timeLeft;
	public Button tryAgainButton;
	public Button continueButton;
	public Button left;
	public Button right;
	public GameObject fiveCeleb;
	public GameObject fireLoseParticle;
	private GameObject instantiatedObj;
	private GameObject instantiatedObj2;
	float timeLeftTillDestroy=1;
	float timeLeftTillDestroyBomb=1;
	public Spawner spawner;
	private bool gameOver = false;
	private bool collidingleft=false;
	private bool collidingRight = false;
	private bool hitByBomb=false;

	Animator anim;
	Rigidbody2D rb;


	// Use this for initialization
	void Start()
	{
		pandaFaceEmotionObject = GameObject.Find ("PandaFaceReaction");
		happyFace = pandaFaceEmotionObject.transform.Find ("Happy Face").gameObject;
		normalFace = pandaFaceEmotionObject.transform.Find ("Normal Face").gameObject;
		sadFace = pandaFaceEmotionObject.transform.Find ("SadFace").gameObject;
        ScoreKeeper.recentGame = "RadiationGame";
		Time.timeScale = 1;
		timeLeft = 30.0f;
		count = 0;
		SetCountText();
		winText.text = "";
		gameOverText.text = "";
		anim = GetComponent<Animator>();
		rb = GetComponent<Rigidbody2D>();
	}

	// Update is called once per frame
	void Update()
	{
		
		anim.SetFloat ("Speed", rb.velocity.x);
		if (hitByBomb == false) {

			if (Input.GetKeyDown ("left")||Input.GetKeyDown("a")) {
				WalkLeft ();
			}

			if (Input.GetKeyUp ("left")||Input.GetKeyUp("a")) {
				StopMoving ();
			}

			if (Input.GetKeyDown ("right")||Input.GetKeyDown("d")) {
				WalkRight ();
			}

			if (Input.GetKeyUp ("right")||Input.GetKeyUp("d")) {
				StopMoving ();
			}
		}
		if (gameOver == false) {
			timeLeft -= Time.deltaTime;
		}
		timerLabel.text = "Timer: " + Mathf.Round(timeLeft);
		if(timeLeft < 0)
		{
			gameOverText.text = "Time over. Try again?";
			finishGame ();
			//face.GetComponent<Animator> ().SetBool ("Sad", true);

		}

		if (instantiatedObj != null) {
			timeLeftTillDestroy -= Time.deltaTime;
			if (timeLeftTillDestroy <= 0) {
				Destroy (instantiatedObj);
				timeLeftTillDestroy = 1;
			}
		}

		if (instantiatedObj2 != null) {
			timeLeftTillDestroy -= Time.deltaTime;
			if (timeLeftTillDestroyBomb <= 0) {
				Destroy (instantiatedObj2);
				timeLeftTillDestroyBomb = 1;
			}
		}

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
			}
		}

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
			}
		}
	}

	void OnCollisionEnter2D(Collision2D coll) {
		if (coll.transform.gameObject.name == "leftBoundary") {
			collidingleft = true;
			face.GetComponent<Animator> ().SetBool ("Walking", false);
		} else if (coll.transform.gameObject.name == "rightBoundary") {
			face.GetComponent<Animator> ().SetBool ("Walking", false);
			collidingRight = true;
		}

		else {
			
			Destroy (coll.gameObject);
			if(coll.gameObject.tag == "Collectable" && gameOver == false){
				count = count + 100;
				happy = true;
				SetCountText ();
			}

			else if (coll.gameObject.tag == "Bamboo") {
				happy = true;
				Vector3 pandaPos = new Vector3 (gameObject.transform.position.x, gameObject.transform.position.y, -2);
				instantiatedObj= Instantiate(fiveCeleb,pandaPos,fiveCeleb.transform.rotation);
				timeLeft += 5;
			} 

			else if (coll.gameObject.tag == "Cube") {
				sad = true;
				Vector3 bombPos = new Vector3 (coll.gameObject.transform.position.x, coll.gameObject.transform.position.y, -2);
				instantiatedObj2= Instantiate(fireLoseParticle,bombPos,fireLoseParticle.transform.rotation);
				gameOverText.text = "You were hit by a bomb.\nTry again?";
				hitByBomb = true;
				StopMoving ();
				Destroy (left.GetComponent<EventTrigger> ());
				Destroy (right.GetComponent<EventTrigger> ());
				finishGame ();
			}
		}

			
	}

	void SetCountText() 
	{
		countText.text = count.ToString ();
		if (count >= 2000) 
		{
			winText.text = "You win! Captured all radiation!";
			face.GetComponent<Animator> ().SetBool ("Happy", true);
			finishGame ();
		}
	}

	void finishGame() {
		//Time.timeScale = 0.01f;
		gameOver = true;
		spawner.CancelInvoke ();
		tryAgainButton.gameObject.SetActive (true);
		continueButton.gameObject.SetActive (true);
	}

	public void WalkLeft() {
		collidingRight = false;
		rb.velocity = Vector2.left * speed;
		if(collidingleft==false)
		face.GetComponent<Animator> ().SetBool ("Walking", true);
	}

	public void WalkRight() {
		collidingleft = false;
		rb.velocity = Vector2.right * speed;
		if(collidingRight==false)
		face.GetComponent<Animator> ().SetBool ("Walking", true);
	}
	public void StopMoving() {
		rb.velocity = new Vector2 (0, 0);
		face.GetComponent<Animator> ().SetBool ("Walking", false);
	}
	public void StartTimer() {
		timeLeft = 30.0f;
	}

}
	
