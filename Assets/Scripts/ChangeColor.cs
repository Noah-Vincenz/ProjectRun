using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeColor : MonoBehaviour {

	public Sprite sprite1; // Drag your first sprite here
	public Sprite sprite2; // Drag your second sprite here
	public Sprite sprite3; // Drag your first sprite here
	public Sprite sprite4; // Drag your second sprite here
	public GameObject fish = null;
	SpriteRenderer spriteRenderer; //Get the renderer via GetComponent or have it cached previously

	// Use this for initialization
	void Start () {
		
		spriteRenderer = gameObject.GetComponent<SpriteRenderer>(); 
	}

	// Update is called once per frame
	void Update () {




	}

	void OnMouseDown(){
		Vector3 vec = Camera.main.ScreenToWorldPoint (Input.mousePosition);
		BoxCollider2D col2d = fish.GetComponent<BoxCollider2D> ();
		if (col2d.OverlapPoint (vec)) {
			


			if (spriteRenderer.sprite == sprite1)
				spriteRenderer.sprite = sprite2;
			
			else if (spriteRenderer.sprite == sprite2)
				spriteRenderer.sprite = sprite3;
			
			else if (spriteRenderer.sprite == sprite3)
				spriteRenderer.sprite = sprite4;
			
			else if (spriteRenderer.sprite == sprite4)
				spriteRenderer.sprite = sprite1;
			
			transform.Rotate(new Vector3(0,180,0)); 
		}

	}
}
	
