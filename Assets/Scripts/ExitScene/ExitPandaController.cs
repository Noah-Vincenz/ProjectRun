using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class ExitPandaController : MonoBehaviour {

	public float speed;
	public GameObject face;
	public GameObject leftDoor;

	Animator anim;
	Rigidbody2D rb;

	// Use this for initialization
	void Start () {

		anim = GetComponent<Animator>();
		rb = GetComponent<Rigidbody2D>();
		
	}
	
	// Update is called once per frame
	void Update () {
		anim.SetFloat("Speed", rb.velocity.x);

		if (leftDoor.transform.position.x > -5 ) { //when the left door opens, the panda starts walking

			rb.velocity = Vector2.right * speed;
			face.GetComponent<Animator> ().SetBool ("Walking", true);

		}

		if (transform.position.x > 10.5f ) { // test if panda is off screen to kill 
			
			Destroy (this.gameObject);

		}
		
	}

	void OnDestroy(){

		SceneManager.LoadScene ("ZoomOutExit");

	}
}
