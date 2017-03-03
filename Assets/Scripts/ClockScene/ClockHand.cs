using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClockHand : MonoBehaviour {
	public float upperBound;
	public float lowerBound;
	public float snapPos;

	public bool correctPos = false;

	private Vector2 mousePos;
	private Vector2 screenPos;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		mousePos = Input.mousePosition;
		screenPos = Camera.main.ScreenToWorldPoint(new Vector3(mousePos.x, mousePos.y, transform.position.z - Camera.main.transform.position.z));

		transform.rotation = Quaternion.Euler(0,0,Mathf.Atan2((screenPos.y - transform.position.y), (screenPos.x - transform.position.x)) * Mathf.Rad2Deg -90);

		if (transform.eulerAngles.z < upperBound && transform.eulerAngles.z > lowerBound) {
			transform.rotation = Quaternion.Euler (0, 0, snapPos);
			correctPos = true;
		}
	}
}
