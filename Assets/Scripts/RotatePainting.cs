using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotatePainting : MonoBehaviour {

	Animator anim;
	public GameObject fish = null;
	SpriteRenderer ren; //Get the renderer via GetComponent or have it cached previously

	// Use this for initialization
	void Start () {
		anim = GetComponent<Animator>();
		ren = gameObject.GetComponent<SpriteRenderer>(); 
	}

	// Update is called once per frame
	void Update () {




	}

	void OnMouseDown(){
		Vector3 vec = Camera.main.ScreenToWorldPoint (Input.mousePosition);
		CapsuleCollider2D col2d = fish.GetComponent<CapsuleCollider2D> ();
		if (col2d.OverlapPoint (vec)) {

			var mouse = Input.mousePosition;
			var screenPoint = Camera.main.WorldToScreenPoint(transform.localPosition);
			var offset = new Vector2(mouse.x - screenPoint.x, mouse.y - screenPoint.y);
			var angle = Mathf.Atan2(offset.y, offset.x) * Mathf.Rad2Deg;
			transform.rotation = Quaternion.Euler(0, 0, angle);

		}

	}
}

