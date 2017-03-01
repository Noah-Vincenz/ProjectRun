using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour {
	Text timer;
	float timeLeft=60;
	// Use this for initialization
	void Start () {
		timer = GetComponent<Text> ();
		timer.text = "TIMER: " + timeLeft;
	}
	
	// Update is called once per frame
	void Update () {
		timeLeft -= Time.deltaTime;
		timer.text = "Timer: " + Mathf.Round (timeLeft);
		
	}
}
