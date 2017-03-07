using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaitingRoom_Panda_Controller : MonoBehaviour {

	public float speed;
	public GameObject face;
	public GameObject Z;
	public GameObject speechBub;
	public GameObject text;
	public NextButtonController nextBtnScript;
	public GameObject nextBtn;
	public GameObject chair;
	public GameObject prompt;
	public float spawnTime;
	public float wait;

	Animator anim;
	Rigidbody2D rb;
	bool endOfWake = false;
	bool needToMove = false;
	bool waveClick = false;
	bool interacted = false;
	bool finalMove = false;
	int click = 0; 

	// Use this for initialization
	void Start()
	{
		anim = GetComponent<Animator>();
		rb = GetComponent<Rigidbody2D>();
		anim.SetBool("IsSleep", true);
		face.GetComponent<Animator>().SetBool("isSleeping", true);
		InvokeRepeating ("SpawnZ", 0, spawnTime); // calls the spawnZ method repeatedly
		StartCoroutine("prompt_time"); // start Coroutine for click me prompt 
	}

	void Update(){
		anim.SetFloat("Speed", rb.velocity.x);
//		Debug.Log (needToMove); 
		if (needToMove) { // bool for first walk (right)
			Debug.Log ("Moving.."); 
			rb.velocity = Vector2.right * speed;
			face.GetComponent<Animator>().SetBool("Walking", true);

		}
		if (transform.localPosition.x >= 1.3f && !finalMove) { // stop first walk to right 
			needToMove = false;
			rb.velocity = new Vector2 (0, 0);
			face.GetComponent<Animator> ().SetBool ("Walking", false);
			}

		if (Input.GetMouseButtonDown(0) && waveClick) { // check if panda is clicked for wave 
			anim.SetBool("IsWaving", true);
		}

		if (Input.GetMouseButtonUp(0)&& waveClick) { // check if click (wave) has ended 
			anim.SetBool("IsWaving", false);
			waveClick = false;
		}
		if (finalMove) { // final move test, after game select 
			Debug.Log ("FinalMove"); 
			rb.velocity = Vector2.left * speed;
			face.GetComponent<Animator>().SetBool("Walking", true);
		}
		if (transform.position.x < -10.5f) { // test if panda is off screen to kill 
			Destroy (this.gameObject);
		}


	}
	void OnMouseDown(){
		Debug.Log ("Panda Clicks:" + click);

		switch (click) {// switch for each click on panda 

		case 0://wake up panda from sleep state 
			CancelInvoke (); // Stops Z's from spawning
			GameObject[] zObjects = GameObject.FindGameObjectsWithTag ("Z"); // array of all z objects
			foreach (GameObject z in zObjects) { 
				Destroy (z.gameObject);  //kill all Z's
			}
			Debug.Log ("Panda Click event-1");
			anim.SetBool ("IsSleep", false);// stop sleep animation 
			anim.SetTrigger ("Wake"); // start wake animation 
			interacted = true; // stops prompt 
			transform.position = new Vector3 (transform.localPosition.x, transform.localPosition.y + 1f, transform.localPosition.z);
			Destroy (prompt.gameObject); 
			++click;
			break;

		case 1: // walk to right 
			if (endOfWake) { // if wake animation has completed 
				Debug.Log ("Panda Click event-2");
				needToMove = true;
				anim.SetBool ("noIdle", false);
				chair.GetComponent<BoxCollider2D> ().enabled = true; //sets chair colider to acitve 
				++click;
			}
			break;
		case 2: // show speech bubble 
			if (anim.GetCurrentAnimatorStateInfo (0).IsName ("Idle")) {
				Debug.Log ("Panda Click event-3");
				speechBub.SetActive(true);// renders speech bubble 
				happyFace(); // method to make panda happy 
				++click;
			}
			break;

		default : // panda wave 
			waveClick = true;
			break;

		}
		
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
	 * methods to change panda face to diffrent states 
	 */
	void awakeFace(){
		face.GetComponent<Animator> ().SetBool ("isSleeping", false);
		face.GetComponent<Animator> ().SetBool ("Happy", false);
		face.GetComponent<Animator> ().SetBool ("Walking", false);
	}
	void walkFace(){
		face.GetComponent<Animator> ().SetBool ("isSleeping", false);
		face.GetComponent<Animator> ().SetBool ("Happy", false);
		face.GetComponent<Animator> ().SetBool ("Walking", true);
	}
	void happyFace(){
		face.GetComponent<Animator> ().SetBool ("isSleeping", false);
		face.GetComponent<Animator> ().SetBool ("Happy", true);
		face.GetComponent<Animator> ().SetBool ("Walking", false);
	}
	/**
	 * method to set bool to true after wake animation
	 */
	void endWake() {
		endOfWake = true;
	}
	/**
	 * method to call function in nextBtn script to load the next scene.
	 */
	void OnDestroy(){
		nextBtnScript.loadNext (); // calls method to load next scene
	}
	/**
	 * Enum to wait the given seconds argument before rendering the prompt
	 */
	IEnumerator prompt_time()
	{
		yield return new WaitForSeconds(wait);
		if (!(interacted)) {
			prompt.SetActive (true);
		}
	}
	/**
	 * public method to make the panda walk off tp the Left
	 */
	public void walkOff(){
		Debug.Log ("Walkoff called");
		finalMove = true;
	}


}

