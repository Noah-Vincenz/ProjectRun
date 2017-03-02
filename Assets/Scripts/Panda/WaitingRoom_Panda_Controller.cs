using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaitingRoom_Panda_Controller : MonoBehaviour {

	private int click = 0; 
	public float speed;
	public GameObject face;
	public GameObject Z;
	public GameObject speechBub;
	public GameObject text;
	public GameObject nextBtn;
	public GameObject chair;
	public GameObject prompt;
	public float spawnTime;
	public float wait;
	Animator anim;
	Rigidbody2D rb;
	bool needToMove = false;
	bool waveClick = false;
	private bool interacted = false;




	// Use this for initialization
	void Start()
	{
		anim = GetComponent<Animator>();
		rb = GetComponent<Rigidbody2D>();
		anim.SetBool("IsSleep", true);
		face.GetComponent<Animator>().SetBool("isSleeping", true);
		InvokeRepeating ("SpawnZ", 0, spawnTime); // calls the spawnZ method repeatedly
		StartCoroutine("prompt_time");
	}

	void Update(){
		anim.SetFloat("Speed", rb.velocity.x);
//		Debug.Log (needToMove); 
		if (needToMove) {
			Debug.Log ("Moving.."); 
			rb.velocity = Vector2.right * speed;
			face.GetComponent<Animator>().SetBool("Walking", true);

		}
		if (transform.localPosition.x >= 1.3f) {
			needToMove = false;
			rb.velocity = new Vector2 (0, 0);
			face.GetComponent<Animator> ().SetBool ("Walking", false);
			}

		if (Input.GetMouseButtonDown(0) && waveClick) {
			anim.SetBool("IsWaving", true);
		}

		if (Input.GetMouseButtonUp(0)&& waveClick) {
			anim.SetBool("IsWaving", false);
			waveClick = false;
		}

	}
	void OnMouseDown(){
		Debug.Log ("Panda Clicks:" + click);
		switch (click) {
		case 0://wake up panda from sleep state 
			CancelInvoke (); // Stops Z's from spawning
			GameObject[] zObjects = GameObject.FindGameObjectsWithTag ("Z"); // array of all z objects
			foreach (GameObject z in zObjects) { 
				Destroy (z.gameObject);  //kill all Z's
			}
			Debug.Log ("Panda Click event-1");
//			waking = true;
			anim.SetBool ("IsSleep", false);
//			anim.SetBool ("awakeing", true);
			anim.SetTrigger ("Wake");
			interacted = true;
			transform.position = new Vector3 (transform.localPosition.x, transform.localPosition.y + 1f, transform.localPosition.z);
			Destroy (prompt.gameObject);
			++click;
			break;

		case 1: 
			Debug.Log ("Panda Click event-2");
			needToMove = true;
			anim.SetBool("noIdle", false);
			chair.GetComponent<BoxCollider2D> ().enabled = true; //sets chair colider to acitve 
			++click;
			break;
		case 2: // show speech bubble 
			if (anim.GetCurrentAnimatorStateInfo (0).IsName ("Idle") == true) {
				Debug.Log ("Panda Click event-3");
				speechBub.GetComponent<Renderer> ().enabled = true;// renders speech bubble 
				happyFace();
				++click;
			}
			break;
		case 3:// show text 
			Debug.Log ("Panda Click event-4");
			text.GetComponent<Renderer> ().enabled = true;// renders text 
			nextBtn.GetComponent<Renderer> ().enabled = true;
			++click;
			break;

		default :
			waveClick = true;
			break;

		}
		
	}
	void OnCollisionEnter (Collision col)
	{
		Debug.Log ("HIT");
		Destroy (this.gameObject);
	}

	/**
	 * Spawns Zs where panda sleeps
	 **/
	void SpawnZ()
	{
		Z.transform.position= new Vector3(transform.localPosition.x+0.75f, transform.localPosition.y+1.25f, transform.localPosition.z); // gets posittion above panda
		GameObject.Instantiate(Z); // create clone of prefab z 
	}
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
	IEnumerator prompt_time()
	{
		Debug.Log("before wait ");
		yield return new WaitForSeconds(wait);
		Debug.Log("after wait ");
		if (!(interacted)) {
			prompt.GetComponent<SpriteRenderer> ().enabled = true;
		}
	}
}

