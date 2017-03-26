﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetCreationControl : MonoBehaviour {

	// Use this for initialization
	public GameObject redTarget;
	public GameObject greenTarget;
	GameObject redTargetIn;
	GameObject greenTargetIn;
	float timeLeftTillNextSetOfTargets=0; //3 seconds set later
	public GameObject timerKeeper;
	Timer timer;
	public GameObject topRight;
	public GameObject BottomLeft;
	public GameObject topLeft;
	public GameObject BottomRight;

	// Use this for initialization
	void Start () {
		timerKeeper = GameObject.Find ("Canvas/Timer").gameObject;
		timer = timerKeeper.GetComponent<Timer> ();
	}
	
	// Update is called once per frame
	void Update () {

		if (timer.getTime() > 0.5) {
			timeLeftTillNextSetOfTargets -= Time.deltaTime;

			if (timeLeftTillNextSetOfTargets <= 0) {
				int whatColourTargt = Random.Range (0, 4); //red=1 green=0
				double ZValueThatIs0InGame = 28.12524;
				float ZvalueAsFloat = (float)ZValueThatIs0InGame;
				print (whatColourTargt);

				if (whatColourTargt == 1) {
					Vector3 screenPosition = new Vector3 (Random.Range (BottomLeft.transform.localPosition.x, topRight.transform.localPosition.x), Random.Range (BottomLeft.transform.localPosition.y, topRight.transform.localPosition.y), 0);
					redTargetIn=(GameObject) Instantiate(redTarget, screenPosition, redTarget.transform.rotation);
				} else if (whatColourTargt == 0||whatColourTargt == 2||whatColourTargt == 3) {
					Vector3 screenPosition = new Vector3 (Random.Range (BottomLeft.transform.localPosition.x, topRight.transform.localPosition.x), Random.Range (BottomLeft.transform.localPosition.y, topRight.transform.localPosition.y), 0);
					greenTargetIn=(GameObject) Instantiate (greenTarget, screenPosition, redTarget.transform.rotation);
				}

				timeLeftTillNextSetOfTargets = 3;
			}
		}

		else if (timer.getTime()<=0.5){
			Destroy (greenTargetIn);
			Destroy(redTargetIn);
		}
	}


		
}
