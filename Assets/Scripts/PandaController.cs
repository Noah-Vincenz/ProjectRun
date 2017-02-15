using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PandaController : MonoBehaviour {
	SpriteRenderer spriteRenderer;
	BoxCollider2D bc;
	int click = 0; 
	bool moving = false;
	Rigidbody2D rb;

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
		spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
		bc = gameObject.GetComponent<BoxCollider2D>();
		rb = GetComponent<Rigidbody2D> ();
		InvokeRepeating ("SpawnZ", 0, spawnTime);
	}
	
	// Update is called once per frame
	void Update () 
	{
		
	}

	void OnMouseDown()
	{
		switch(click){
		case 0://wake up panda
			CancelInvoke ();
			Debug.Log ("Panda Click event-1");
			animator.SetTrigger ("Wake");
			rb.gravityScale = 1;
			++click;
			break;
		case 1://move to centre 
			Debug.Log ("Panda Click event-2");
			animator.SetTrigger ("Walk");
			moveToPos (new Vector3(1.5f,-3.00f,0.00f)); // move to centre 
			chair.GetComponent<BoxCollider2D>().enabled = true;
			++click;
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
	public void moveToPos(Vector3 newPos)
	{

		// need to animate
		rb.AddForce(Vector2.right * speed);
		//transform.position = Vector3.Lerp(transform.position, newPos, speed);
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
		Debug.Log("hit");
	}

	private IEnumerator WaitForAnimation (Animation animation)
	{
		do
		{
			yield return null;
		} while (animation.isPlaying);
	}

}
