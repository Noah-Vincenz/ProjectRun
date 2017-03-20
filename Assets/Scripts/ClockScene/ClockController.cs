using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class ClockController : MonoBehaviour {
	public string sceneToLoad;

	public GameObject wellDone;

	public GameObject background;

	public GameObject arrowObj;

	public GameObject minuteHand;
	public GameObject hourHand;

	public bool minuteDisabled;
	public bool hourDisabled;

	//ability to set the hour and minute snap from controller code, overrides individual settings
	public float minuteSnap = 0;
	public float hourSnap = 0;
	public float snapAngle = 20;

	//mode = 0 for moving minute hand, 1 for moving hour hand
	private int mode = 0;

	private GameObject minuteHint;
	private GameObject hourHint;

	private float waitUntil;
	private float timeLeftForTransition;
	private Material material;
	private Color color;

	void Start() {
		//fade code
		Material material1 = background.GetComponent<Renderer>().material;
		Color color1 = material1.color;
		background.GetComponent<Renderer> ().material.color = new Color (color1.r, color1.g, color1.b, color1.a -color1.a);

		//setting up the child hand objects
		minuteHand.GetComponent<ClockHand> ().correctPos = minuteSnap;
		minuteHand.GetComponent<ClockHand> ().snapAngle = snapAngle;

		minuteHint = Instantiate (arrowObj, new Vector3 ((float) (4.2 * Mathf.Sin ((minuteSnap - 180) * Mathf.Deg2Rad) + 3), (float) (4 * Mathf.Cos (minuteSnap * Mathf.Deg2Rad)), 0), Quaternion.Euler (0, 0, minuteSnap));

		hourHand.GetComponent<ClockHand> ().correctPos = hourSnap;
		hourHand.GetComponent<ClockHand> ().snapAngle = snapAngle;

		hourHint = Instantiate (arrowObj, new Vector3((float) (4.2 * Mathf.Sin ((hourSnap - 180) * Mathf.Deg2Rad) + 3), (float) (4*Mathf.Cos(hourSnap * Mathf.Deg2Rad)),0), Quaternion.Euler(0,0,hourSnap));

		minuteHand.GetComponent<ClockHand>().isCorrect = minuteDisabled;
		hourHand.GetComponent<ClockHand>().isCorrect = hourDisabled;

		minuteHand.GetComponent<ClockHand> ().enabled = true;
		hourHand.GetComponent<ClockHand> ().enabled = true;

		if (minuteDisabled)
			mode = 1;

		if (mode == 0) {
			minuteHint.SetActive(true);
			hourHint.SetActive(false);
		} else if (mode == 1) {
			minuteHint.SetActive(false);
			hourHint.SetActive(true);
		} else {
			minuteHint.SetActive(false);
			hourHint.SetActive(false);
		}
	}
	
	// Update is called once per frame
	void Update () {
		//if the mouse button is held down
		if (Input.GetMouseButtonDown (0)) {
			//move the appropriate clock hand to face the mouse
			if (mode == 0) {
				hourHand.GetComponent<ClockHand> ().canMove = false;
				minuteHand.GetComponent<ClockHand> ().canMove = true;
			} else if (mode == 1) {
				hourHand.GetComponent<ClockHand> ().canMove = true;
				minuteHand.GetComponent<ClockHand> ().canMove = false;
			}
		}

		//if the mouse button is released
		if (Input.GetMouseButtonUp (0)) {
			//disable the movement of the hands
			hourHand.GetComponent<ClockHand> ().canMove = false;
			minuteHand.GetComponent<ClockHand> ().canMove = false;

			//if the minute hand is correct, move to the second hand
			if (minuteHand.GetComponent<ClockHand> ().isCorrect) {
				mode = 1;
				minuteHint.SetActive(false);
				hourHint.SetActive(true);
			}

			//if the hour hand is correct, the clock is satisfied
			if (hourHand.GetComponent<ClockHand> ().isCorrect && minuteHand.GetComponent<ClockHand>().isCorrect) {
				Debug.Log("Clock in satisfied state");
				minuteHint.SetActive(false);
				hourHint.SetActive(false);
				waitUntil = Time.time + 4;
				wellDone.GetComponent<SpriteRenderer> ().enabled = true;
				mode = 3;
			}
		}

		//scene end code
		if (mode == 3 && Time.time > waitUntil) {
			material = background.GetComponent<Renderer>().material;
			color = material.color;
			timeLeftForTransition -= Time.deltaTime;
			if (timeLeftForTransition <= 2) {
				background.SetActive (true);
				material.color = new Color (color.r, color.g, color.b, color.a + (1f * Time.deltaTime));
			}

			if (timeLeftForTransition <= 0) {
				SceneManager.LoadScene (sceneToLoad);
			}
		}
	}
}
