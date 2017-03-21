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
	private bool readyToTransition;
	private bool startMovingTimer=false;
	public GameObject prompt;
	bool interacted = false;
	public float wait;
	bool interacted2 = false;
	public float wait2;

	// Use this for initialization
	void Start () {
		readyToTransition = false;
		var material1 = background.GetComponent<Renderer>().material;
		var color1 = material1.color;
		background.GetComponent<Renderer> ().material.color = new Color (color1.r, color1.g, color1.b, color1.a -color1.a);
		StartCoroutine ("prompt_time"); 
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
		
			interacted = true; // stops prompt 
			prompt.SetActive (false);


		switch (click) {

		case 1:// show text 
			StartCoroutine ("prompt2_time"); 
			animBelt.SetTrigger ("attachBelt");
			++click;
			break;
		case 2:// show text 
			if (animBelt.GetCurrentAnimatorStateInfo (0).IsName ("endIdle")) {
				interacted = true; // stops prompt 
				prompt.SetActive (false);
				animPanda.SetTrigger ("happy");
				animScanner.SetTrigger ("IsTimeToMove");
				startMovingTimer = true;
				++click;
				break;
			}
			break;

		}
	}

	IEnumerator prompt_time()
	{
		yield return new WaitForSeconds(wait);
		if (!(interacted)) {
			prompt.SetActive (true);
		}
	}

	IEnumerator prompt2_time() //4 seconds
	{
		yield return new WaitForSeconds(wait2);
		if (!(interacted2)) {
			prompt.SetActive (true);
		}
	}

}

