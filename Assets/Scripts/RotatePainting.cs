using UnityEngine;
using System.Collections;

public class RotatePainting : MonoBehaviour {

	private Camera myCam;
	private Vector3 screenPos;
	private float   angleOffset;
	private Vector3 vec;
	private CapsuleCollider2D coll; //collider on object
	SpriteRenderer spriteRenderer;
	public Sprite normalPainting;
	public Sprite eggPainting;

	void Start () {
		
		myCam=Camera.main;
		spriteRenderer = gameObject.GetComponent<SpriteRenderer>(); 
	}

	//in charge or painting Rotation
	void Update () { 
		vec = Camera.main.ScreenToWorldPoint (Input.mousePosition);
		coll = gameObject.GetComponent<CapsuleCollider2D> ();

		//Checks if click was on object only
		if (coll.OverlapPoint (vec)) {
				
			//This fires only on the frame the button is clicked
			if (Input.GetMouseButtonDown (0)) {
				Debug.Log (myCam);
				screenPos = myCam.WorldToScreenPoint (transform.position);
				Vector3 v3 = Input.mousePosition - screenPos;
				angleOffset = (Mathf.Atan2 (transform.right.y, transform.right.x) - Mathf.Atan2 (v3.y, v3.x)) * Mathf.Rad2Deg;
			}
			//This fires while the button is pressed down
			if (Input.GetMouseButton (0)) {
				Vector3 v3 = Input.mousePosition - screenPos;
				float angle = Mathf.Atan2 (v3.y, v3.x) * Mathf.Rad2Deg;
				transform.eulerAngles = new Vector3 (0, 0, angle+angleOffset );
			}

	}
		if (transform.localRotation.z >= 0.999f && transform.localRotation.z < 1f) { // painting easter egg :)
			Debug.Log ("painting egg");
			spriteRenderer.sprite = eggPainting; // changes painting when upside down
		} else
			spriteRenderer.sprite = normalPainting; // 

	}


}