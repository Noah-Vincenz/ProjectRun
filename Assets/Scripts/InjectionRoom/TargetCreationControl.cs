using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetCreationControl : MonoBehaviour {

	// Use this for initialization
	public GameObject redTarget;
	public GameObject greenTarget;
	float timeLeftTillNextSetOfTargets=0; //3 seconds set later
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		timeLeftTillNextSetOfTargets -= Time.deltaTime;

		if (timeLeftTillNextSetOfTargets <= 0) {
			int whatColourTargt=Random.Range(0,2); //red=1 green=0
			double ZValueThatIs0InGame = 28.12524;
			float ZvalueAsFloat = (float)ZValueThatIs0InGame;
			print (whatColourTargt);

			if (whatColourTargt == 1) {
				Vector3 screenPosition = Camera.main.ScreenToWorldPoint(new Vector3(Random.Range(200,700), Random.Range(200,600), ZvalueAsFloat));
				Instantiate (redTarget, screenPosition, redTarget.transform.rotation);
			} 
			else if (whatColourTargt == 0) {
				Vector3 screenPosition = Camera.main.ScreenToWorldPoint (new Vector3 (Random.Range(200,700), Random.Range(200,500), ZvalueAsFloat));
				Instantiate (greenTarget,screenPosition	, redTarget.transform.rotation);
			}

			timeLeftTillNextSetOfTargets = 3;
		}
	}
}
