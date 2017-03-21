using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class MoveBedOut : MonoBehaviour {

	private Vector2 aPosition1;
	public GameObject background;
	float timeLeftforTransition=2;
	private bool readyForTransition;
	SceneManagerController procedure;

	void Start () {

		aPosition1 = new Vector2 ( (float) 3, (float) -0.78); //maximum position it can move to

		var material1 = background.GetComponent<Renderer>().material;
		var color1 = material1.color;
		background.GetComponent<Renderer> ().material.color = new Color (color1.r, color1.g, color1.b, color1.a -color1.a);
		readyForTransition = false;

		procedure = GameObject.Find ("SceneManager").GetComponent<SceneManagerController>();

	}

	void Update () {

		var material = background.GetComponent<Renderer>().material;
		var color = material.color;

		transform.position = Vector2.MoveTowards(new Vector2(transform.position.x, transform.position.y), 
			aPosition1, 1 * Time.deltaTime);

		if (transform.position.x >= 3) {

			readyForTransition = true;

		}

		if (readyForTransition) {

			background.SetActive (enabled);
			material.color = new Color (color.r, color.g, color.b, color.a + (1f * Time.deltaTime));
			timeLeftforTransition -= Time.deltaTime;

		}
			
		if (timeLeftforTransition <= 0) {

			switch (procedure.getProcedure ()) { // switch dependant on selected game 

			case "DMSA":
				Debug.Log("LOAD DMSA");
				SceneManager.LoadScene ("EndWaitingRoom"); //Scan after 30 mins
				break;

			case "Meckel":
				Debug.Log("LOAD Meckel");
				SceneManager.LoadScene ("EndWaitingRoom"); //Scan after 45 mins
				break;

			case "RENOGRAMin":
				Debug.Log("LOAD Renogram Indirect");
				SceneManager.LoadScene ("Toilet"); //Scan after 20 mins
				break;

			case "RENOGRAM":
				Debug.Log("LOAD Renogram");
				SceneManager.LoadScene ("ToiletNoScan"); //Scan after 20 mins
				break;

			default:
				Debug.Log ("Bad Tag: " + tag); // should'nt happen 
				break;
			}

		}


	}
}
