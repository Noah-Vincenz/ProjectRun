using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PandaController : MonoBehaviour {

	private int click = 0; 
	private Rigidbody2D rb;

	public Animator animator;
	public GameObject speechBub;
	public GameObject text;
	public GameObject chair;
	public GameObject Z;
	public GameObject nextBtn;
	public float spawnTime;
	public float speed; 


	// Use this for initialization
	void Start () 
	{
		rb = GetComponent<Rigidbody2D> ();
		InvokeRepeating ("SpawnZ", 0, spawnTime);
	}
		
	void OnMouseDown()
	{
		Debug.Log ("Panda Clicks:" + click);
		switch(click){
		case 0://wake up panda
			CancelInvoke ();
			Debug.Log ("Panda Click event-1");
			animator.SetTrigger ("Wake");
			rb.gravityScale = 1;
			++click;
			break;
		case 1://move to centre 
			if (animator.GetCurrentAnimatorStateInfo (0).IsName ("Idle-Awake") == true) {
				rb.gravityScale = 0;
				Debug.Log ("Panda Click event-2");
				animator.SetTrigger ("Walk");
				moveToPos (); // move to centre 
				chair.GetComponent<BoxCollider2D> ().enabled = true;
				++click;
				break;
			} else
				break;
		case 2: // show speech bubble 
			Debug.Log ("Panda Click event-3");
			speechBub.GetComponent<Renderer> ().enabled = true;
			++click;
			break;
		case 3:// show text 
			Debug.Log ("Panda Click event-4");
			text.GetComponent<Renderer> ().enabled = true;
			nextBtn.GetComponent<Renderer> ().enabled = true;
			++click;
			break;
				
		default : // default animation
			animator.SetTrigger ("Attack");
				break;

		}
	}
	/**
	 * move Gameobject to new position.
	 * 
	 **/
	public void moveToPos()
	{

		// need to animate
		rb.velocity=Vector3.right* speed;	
	}
	/**
	 * Spawns Zs where panda sleeps
	 **/
	void SpawnZ()
	{
		var newZ = GameObject.Instantiate(Z);
	}
	void OnCollisionEnter2D(Collision2D coll)
	{
		animator.SetTrigger ("Walk_ends");
		rb.gravityScale = 1;
	}
		

}
