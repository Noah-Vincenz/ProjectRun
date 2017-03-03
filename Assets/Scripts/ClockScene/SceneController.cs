using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneController : MonoBehaviour {
	public GameObject minuteHand;
	public GameObject hourHand;

	//mode = 0 for moving minute hand, 1 for moving hour hand
	public int mode = 1;
	
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

			if (minuteHand.GetComponent<ClockHand> ().correctPos) {
				mode = 1;
			}

			if (hourHand.GetComponent<ClockHand> ().correctPos) {
				//TODO: LOAD NEXT SCENE
			}
		}
	}
}
