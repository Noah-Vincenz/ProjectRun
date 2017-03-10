using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Timer : MonoBehaviour {
	Text timer;
	public float timeLeft=5;
	float timeLeftforTransition=4;
	public GameObject background;
	public GameObject endText;
	public Text scoreText;

	// Use this for initialization
	void Start () {
		timer = GetComponent<Text> ();
		timer.text = "TIMER: " + timeLeft;
		var material1 = background.GetComponent<Renderer>().material;
		var color1 = material1.color;
		background.GetComponent<Renderer> ().material.color = new Color (color1.r, color1.g, color1.b, color1.a -color1.a);
	}
	
	// Update is called once per frame
	void Update () {
		var material = background.GetComponent<Renderer>().material;
		var color = material.color;

		if(Mathf.Round(timeLeft)>0){
		timeLeft -= Time.deltaTime;
		timer.text = "Timer: " + Mathf.Round (timeLeft);
		}

		else
        {
			endText.SetActive (enabled);
			timeLeftforTransition -= Time.deltaTime;
			if (timeLeftforTransition <= 2) {
				background.SetActive (enabled);
				material.color = new Color (color.r, color.g, color.b, color.a + (1f * Time.deltaTime));
			}

			if (timeLeftforTransition <= 0) {
				SceneManager.LoadScene ("gameEnd");
			}
        }
	}

	public float getTime(){
		return timeLeft;
	}
}
