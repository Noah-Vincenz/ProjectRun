using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankBubble : MonoBehaviour {

	public GameObject tank;
	public GameObject bubblesPreFab;

	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnMouseDown(){
		Vector3 vec = Camera.main.ScreenToWorldPoint (Input.mousePosition);
		BoxCollider2D col2d = tank.GetComponent<BoxCollider2D> ();
		if (col2d.OverlapPoint (vec)) {
			Instantiate(bubblesPreFab);
		}	}
}
