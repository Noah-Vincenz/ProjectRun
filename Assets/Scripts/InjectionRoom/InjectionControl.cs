using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InjectionControl : MonoBehaviour {
	public Animator anim;
	public float xPos=1; //turned into 0.6 from object Inspector
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update() {
		Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
		Vector3 mousePosNeed = new Vector3 (mousePos.x+xPos, mousePos.y+1, mousePos.z);
		mousePosNeed.z = 5f;
		transform.position = mousePosNeed;

		if (Input.GetMouseButtonUp(0)) {
			anim.SetTrigger ("Inject");
			anim.SetTrigger("refill");

		}

	


	}


			




}
