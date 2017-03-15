using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PeePeeScreenController : MonoBehaviour {
	Animator anim;
	public ToiletPandaController panda;
	int clicks;
	// Use this for initialization
	void Start () {
		clicks = 0;
		anim = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnMouseDown(){
		switch (clicks){

		case 0: 
			anim.SetTrigger ("MoveScreen");
			anim.SetBool ("moved", true);
			++clicks;
			break;
		}
			

	}
	void movePanda(){
		Debug.Log ("Call to movePanda");
		panda.moveUp ();
	}
}
