using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishController : MonoBehaviour {

	private Rigidbody2D rb;
	public GameObject fish;
	public GameObject bubblesPreFab;
	public float swimSpeed=1;

	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody2D> ();
	}
	
	// fish swimming
	void Update () {
		
		rb.AddForce(Vector2.right * swimSpeed); //Fish swimming

	}

	//fish jump and bubble creation
	void OnMouseDown(){
		
		rb.gravityScale = -3;//On click set grafity to negative so that the fish can float
		bubblesPreFab.transform.position= new Vector3(fish.transform.localPosition.x, transform.localPosition.y+1, transform.localPosition.z);//set location of soon to be bubble to location above fish
		Instantiate(bubblesPreFab);//create bubble

	}


	void OnCollisionEnter2D(Collision2D coll)
	{
		//If collsion with collider above fish tank, then set grafity to positive so that fish falls
		if (coll.transform.gameObject.name=="FishTopCollider") {
			rb.gravityScale = 3;
		} 

		//If collision with collider on fish tank floor level, then set gravity to zero so fish will simply swim 
		else if (coll.transform.gameObject.name=="FishBottomCollider") {
			rb.gravityScale = 0;
		} 

		//If collision with sides of tank, flip sprite and negate swim speed so fish will swim the oppsite way
		else {
			swimSpeed = -swimSpeed;
			transform.localScale = new Vector3 (transform.localScale.x * -1, transform.localScale.y, transform.localScale.z);
		}
	}
}
