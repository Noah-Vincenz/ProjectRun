using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class MoveBedIn : MonoBehaviour {
	
	private Vector2 aPosition1;
	public GameObject background;
	float timeLeftforTransition=2;
	private bool readyForTransition;

	// Use this for initialization
	void Start () {

		aPosition1 = new Vector2 ( (float) -2.5, (float) -0.78);

		var material1 = background.GetComponent<Renderer>().material;
		var color1 = material1.color;
		background.GetComponent<Renderer> ().material.color = new Color (color1.r, color1.g, color1.b, color1.a -color1.a);
		readyForTransition = false;

	}

	// Update is called once per frame
	void Update () {

		var material = background.GetComponent<Renderer>().material;
		var color = material.color;

		transform.position = Vector2.MoveTowards(new Vector2(transform.position.x, transform.position.y), 
			aPosition1, 1 * Time.deltaTime);

		if (transform.position.x <= -2.5) {

			readyForTransition = true;

		}

		if (readyForTransition) {

			background.SetActive (enabled);
			material.color = new Color (color.r, color.g, color.b, color.a + (1f * Time.deltaTime));
			timeLeftforTransition -= Time.deltaTime;

		}

		if (timeLeftforTransition <= 0) {

			SceneManager.LoadScene ("IntroCatchRadiationGame");

		}

	}
}
