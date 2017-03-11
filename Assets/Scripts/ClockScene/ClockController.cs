using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClockController : MonoBehaviour {
	public GameObject arrowObj;

	public GameObject minuteHand;
	public GameObject hourHand;

	public bool minuteDisabled;
	public bool hourDisabled;

	//ability to set the hour and minute snap from controller code, overrides individual settings
	public float minuteSnap;
	public float hourSnap;
	public float snapAngle;

	//mode = 0 for moving minute hand, 1 for moving hour hand
	private int mode = 0;

	private GameObject minuteHint;
	private GameObject hourHint;

	void Start() {
		minuteHand.GetComponent<ClockHand> ().enabled = false;
		hourHand.GetComponent<ClockHand> ().enabled = false;

		minuteHand.GetComponent<ClockHand> ().correctPos = minuteSnap;
		minuteHand.GetComponent<ClockHand> ().snapAngle = snapAngle;

		minuteHint = Instantiate (arrowObj, new Vector3 ((5 * Mathf.Sin ((minuteSnap - 180) * Mathf.Deg2Rad) + 3), (5 * Mathf.Cos (minuteSnap * Mathf.Deg2Rad)), 0), Quaternion.Euler (0, 0, minuteSnap));

		hourHand.GetComponent<ClockHand> ().correctPos = hourSnap;
		hourHand.GetComponent<ClockHand> ().snapAngle = snapAngle;

		hourHint = Instantiate (arrowObj, new Vector3((5 * Mathf.Sin ((hourSnap - 180) * Mathf.Deg2Rad) + 3),(5*Mathf.Cos(hourSnap * Mathf.Deg2Rad)),0), Quaternion.Euler(0,0,hourSnap));

		minuteHand.GetComponent<ClockHand>().isCorrect = minuteDisabled;
		hourHand.GetComponent<ClockHand>().isCorrect = hourDisabled;

		if (minuteDisabled)
			mode = 1;

		if (mode == 0) {
			minuteHint.active = true;
			hourHint.active = false;
		} else if (mode == 1) {
			minuteHint.active = false;
			hourHint.active = true;
		} else {
			minuteHint.active = false;
			hourHint.active = false;
		}
	}
	
	// Update is called once per frame
	void Update () {
		//if the mouse button is held down
		if (Input.GetMouseButtonDown (0)) {
			//move the appropriate clock hand to face the mouse
			if (mode == 0) {
				hourHand.GetComponent<ClockHand> ().enabled = false;
				minuteHand.GetComponent<ClockHand> ().enabled = true;
			} else if (mode == 1) {
				hourHand.GetComponent<ClockHand> ().enabled = true;
				minuteHand.GetComponent<ClockHand> ().enabled = false;
			}
		}

		//if the mouse button is released
		if (Input.GetMouseButtonUp (0)) {
			//disable the movement of the hands
			hourHand.GetComponent<ClockHand> ().enabled = false;
			minuteHand.GetComponent<ClockHand> ().enabled = false;

			//if the minute hand is correct, move to the second hand
			if (minuteHand.GetComponent<ClockHand> ().isCorrect) {
				mode = 1;
				minuteHint.active = false;
				hourHint.active = true;
			}

			//if the hour hand is correct, the clock is satisfied
			if (hourHand.GetComponent<ClockHand> ().isCorrect) {
				//TODO: LOAD NEXT SCENE
				Debug.Log("Clock in satisfied state");
				minuteHint.active = false;
				hourHint.active = false;
				mode = 3;
			}
		}
	}
}
