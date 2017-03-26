﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;

public class TargetCreationControl : MonoBehaviour {

	// Use this for initialization
	public GameObject redTarget;
	public GameObject greenTarget;
	GameObject redTargetIn;
	GameObject greenTargetIn;
	float timeLeftTillNextSetOfTargets=0; //3 seconds set later
	public GameObject timerKeeper;
	Timer timer;

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
					Vector3 screenPosition = Camera.main.ScreenToWorldPoint (new Vector3 (Random.Range (300, 700), Random.Range (50, 400), ZvalueAsFloat));
					redTargetIn=(GameObject) Instantiate(redTarget, screenPosition, redTarget.transform.rotation);
				} else if (whatColourTargt == 0||whatColourTargt == 2||whatColourTargt == 3) {
					Vector3 screenPosition = Camera.main.ScreenToWorldPoint (new Vector3 (Random.Range (300, 700), Random.Range (50, 400), ZvalueAsFloat));
					greenTargetIn=(GameObject) Instantiate (greenTarget, screenPosition, redTarget.transform.rotation);
				}

                //testTargetCreation();
                timeLeftTillNextSetOfTargets = 3;
			}
		}

		else if (timer.getTime()<=0.5){
			Destroy (greenTargetIn);
			Destroy(redTargetIn);
		}
	}

    void testTargetCreation()
    {
        if (timeLeftTillNextSetOfTargets <= 0)
        {
            Assert.IsTrue((redTargetIn!=null)||(greenTargetIn!=null));
        }
    }

		
}
