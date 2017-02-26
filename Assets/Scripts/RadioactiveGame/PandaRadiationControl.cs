using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PandaRadiationControl : MonoBehaviour {

	public float speed;
	public GameObject face;
	public int count; 
	public Text countText;
	public Text winText;
	public Text gameOverText;
	public Text timerLabel;
	private float timeLeft;

	Animator anim;
	Rigidbody2D rb;

	// Use this for initialization
	void Start()
	{
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
		//transform.position += new Vector3 (Input.GetAxis ("Horizontal"), 0, 0);
	
		if (Input.GetKeyDown ("a")) {
			rb.velocity = Vector2.left * speed;
			face.GetComponent<Animator> ().SetBool ("Walking", true);

		}

		if (Input.GetKeyUp ("a")) {
			rb.velocity = new Vector2 (0, 0);
			face.GetComponent<Animator> ().SetBool ("Walking", false);
		}

		if (Input.GetKeyDown ("d")) {
			rb.velocity = Vector2.right * speed;
			face.GetComponent<Animator> ().SetBool ("Walking", true);
		}

		if (Input.GetKeyUp ("d")) {
			rb.velocity = new Vector2 (0, 0);
			face.GetComponent<Animator> ().SetBool ("Walking", false);
		}

		if (Input.GetKey ("w"))
			face.GetComponent<Animator> ().SetBool ("Happy", true);

		if (Input.GetKey ("s"))
			face.GetComponent<Animator> ().SetBool ("Happy", false);

		timeLeft -= Time.deltaTime;
		timerLabel.text = "Time Left: " + Mathf.Round(timeLeft) + " secs";
		if(timeLeft < 0)
		{
			gameOverText.text = "Game Over. Try again!";
			Time.timeScale = 0;
		}
	}

	void OnCollisionEnter2D(Collision2D coll) {
		count = count + 1;
		Destroy(coll.gameObject);
		SetCountText ();
		if (coll.gameObject.tag == "Bamboo") {
			timeLeft += 5;
		}
		else if (coll.gameObject.tag == "Cube") {
			gameOverText.text = "Game Over. Try again!";
			Time.timeScale = 0;
		}

			
	}

	void SetCountText() 
	{
		countText.text = "Count: " + count.ToString ();
		if (count >= 20) 
		{
			winText.text = "You win! Captured all radiation!";
			face.GetComponent<Animator> ().SetBool ("Happy", true);
			//anim.SetBool ("isWaving", true);
			Time.timeScale = 0;
		}
	}

}
