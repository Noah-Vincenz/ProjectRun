using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BubbleController : MonoBehaviour {
	
	public GameObject bubble;
	private Rigidbody2D rb;
	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody2D> ();
	}
	
	// Update is called once per frame
	void Update () {
		rb.AddForce (Vector2.up * 1);
		if (bubble.transform.position.y > 10)
			Destroy (bubble);
	}

	void OnMouseDown(){
		Destroy (bubble);

	}
}
