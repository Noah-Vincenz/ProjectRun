using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InjectionControl : MonoBehaviour {
	public Animator anim;
	public float xPos=1; //turned into 0.6 from object Inspector
	public GameObject timerKeeper;
	Timer timer;
	// Use this for initialization
	void Start () {
		timerKeeper = GameObject.Find ("Canvas/Timer").gameObject;
		timer = timerKeeper.GetComponent<Timer> ();
	}
	
	// Update is called once per frame
	void Update() {

		if (timer.getTime ()>0.5) {
			Vector3 mousePos = Camera.main.ScreenToWorldPoint (Input.mousePosition);
			Vector3 mousePosNeed = new Vector3 (mousePos.x + xPos, mousePos.y + 1, mousePos.z);
			mousePosNeed.z = 5f;
			transform.position = mousePosNeed;

			if (Input.GetMouseButtonUp (0)) {
				anim.SetTrigger ("Inject");
				anim.SetTrigger ("refill");

			}

		} 
		else if(timer.getTime () <= 0.5){
			transform.position = transform.position;
		}
			

	


	}


			




}
