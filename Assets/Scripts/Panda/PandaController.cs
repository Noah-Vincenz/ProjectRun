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
//	public GameObject nextBtn;
	public float spawnTime;
	public float speed; 


	// Use this for initialization
	void Start () 
	{
		rb = GetComponent<Rigidbody2D> ();
		InvokeRepeating ("SpawnZ", 0, spawnTime); // calls the spawnZ method repeatedly
	}
		
	void OnMouseDown()
	{
		Debug.Log ("Panda Clicks:" + click);
		switch(click){
		case 0://wake up panda from sleep state 
			CancelInvoke (); // Stops Z's from spawning
			GameObject[] zObjects = GameObject.FindGameObjectsWithTag("Z"); // array of all z objects
			foreach (GameObject z in zObjects)
			{ 
				Destroy(z.gameObject);  //kill all Z's
			}
			Debug.Log ("Panda Click event-1");
			animator.SetTrigger ("Wake"); // trigger wake animation 
			rb.gravityScale = 1; // set gravity to make object fall 
			++click;
			break;
		case 1://move panda 
			if (animator.GetCurrentAnimatorStateInfo (0).IsName ("Idle-Awake") == true) { // tests if panda is in standing animation 
				rb.gravityScale = 0; // removes gravity 
				Debug.Log ("Panda Click event-2");
				animator.SetTrigger ("Walk"); // triggers walking animation
				velRight (); 
				chair.GetComponent<BoxCollider2D> ().enabled = true; //sets chair colider to acitve 
				++click;
				break;
			} else
				break;
		case 2: // show speech bubble 
			Debug.Log ("Panda Click event-3");
			speechBub.GetComponent<Renderer> ().enabled = true;// renders speech bubble 
			++click;
			break;
		case 3:// show text 
			Debug.Log ("Panda Click event-4");
			text.GetComponent<Renderer> ().enabled = true;// renders text 
//			nextBtn.GetComponent<Renderer> ().enabled = true;
			++click;
			break;
				
		default : // default animation trigger - Swing 
			animator.SetTrigger ("Attack");
				break;

		}
	}
	/**
	 * adds velocity to object to the right .
	 * 
	 **/
	public void velRight()
	{
		rb.velocity=Vector3.right* speed; // adding velocity to the panda.
	}
	/**
	 * Spawns Zs where panda sleeps
	 **/
	void SpawnZ()
	{
		Z.transform.position= new Vector3(transform.localPosition.x+0.75f, transform.localPosition.y+1.25f, transform.localPosition.z); // gets posittion above panda
		GameObject.Instantiate(Z); // create clone of prefab z 
	}
	/**
	 * collision handler to stop object when it collides with wall
	 **/
	void OnCollisionEnter2D(Collision2D coll)
	{
		animator.SetTrigger ("Walk_ends");
		rb.gravityScale = 1; // add gravity to object 
	}
		

}
