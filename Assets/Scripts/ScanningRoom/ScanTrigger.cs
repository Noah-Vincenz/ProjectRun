using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScanTrigger : MonoBehaviour {

	private Rigidbody2D rb;
	public GameObject currentPanda;
	public GameObject sidePanda;


	// Use this for initialization
	void Start () {

		rb = GetComponent<Rigidbody2D> ();
		sidePanda.SetActive (false);
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter2D(Collider2D col){

		if (col.gameObject.name == "scanner") {

			Debug.Log ("Entered trigger area");
			currentPanda.SetActive (false);
			sidePanda.SetActive (true);

		}

	}
		
		
}
