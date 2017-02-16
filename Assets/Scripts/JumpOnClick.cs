using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpOnClick : MonoBehaviour {

	Rigidbody2D rb;
	public GameObject fish;
	public GameObject bubblesPreFab;
	public float swimSpeed=1;
	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody2D> ();
	}
	
	// Update is called once per frame
	void Update () {
		
		rb.AddForce(Vector2.right * swimSpeed);


	}

	void OnMouseDown(){
		
			rb.gravityScale = -3;

		bubblesPreFab.transform.position= new Vector3(fish.transform.localPosition.x, transform.localPosition.y+1, transform.localPosition.z);
			Instantiate(bubblesPreFab);

	
	}
	void OnCollisionEnter2D(Collision2D coll)
	{
		if (coll.transform.gameObject.name=="FishTopCollider") {
			rb.gravityScale = 3;
			Debug.Log ("yws");
		} 

		else if (coll.transform.gameObject.name=="FishBottomCollider") {
			rb.gravityScale = 0;
		} 

		else {
			swimSpeed = -swimSpeed;
			transform.localScale = new Vector3 (transform.localScale.x * -1, transform.localScale.y, transform.localScale.z);
		}
	}
}
