using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BeltSceneController : MonoBehaviour {

	public GameObject background;
	private int click = 1;
	public Animator animScanner;
	public Animator animBelt;
	public Animator animPanda;
	float timeLeftforTransition=2;
	float timeLeftForMovingScanner=3;
	float timeTillPrompt=3;
	float blinkTextTime=1;
	private bool promptNeeded=true;
	private bool readyToTransition;
	private bool startMovingTimer=false;
	public GameObject prompt;

	// Use this for initialization
	void Start () {
		readyToTransition = false;
		var material1 = background.GetComponent<Renderer>().material;
		var color1 = material1.color;
		background.GetComponent<Renderer> ().material.color = new Color (color1.r, color1.g, color1.b, color1.a -color1.a);
		
	}
	
	// Update is called once per frame
	void Update () {
		var material = background.GetComponent<Renderer> ().material;
		var color = material.color;
		if (readyToTransition) {
			background.SetActive (enabled);
			material.color = new Color (color.r, color.g, color.b, color.a + (1f * Time.deltaTime));
			timeLeftforTransition -= Time.deltaTime;
		}

		if (timeLeftforTransition <= 0) {
			SceneManager.LoadScene ("IntroCatchRadiationGame");
		}

		if (startMovingTimer) {
			timeLeftForMovingScanner -= Time.deltaTime;
			if (timeLeftForMovingScanner <= 0) {
				readyToTransition = true;
				startMovingTimer	 = false;
			}
		}

	
	}

	void OnMouseDown(){

		Debug.Log ("Clicks:" + click);
		switch (click) {

		case 1:// show text 
			animBelt.SetTrigger ("attachBelt");
			++click;
			break;
		case 2:// show text 
			if (animBelt.GetCurrentAnimatorStateInfo (0).IsName ("endIdle")) {
				animPanda.SetTrigger ("happy");
				animScanner.SetTrigger ("IsTimeToMove");
				startMovingTimer = true;
				promptNeeded = false;
				break;
			}
			break;

		}
	}
}

