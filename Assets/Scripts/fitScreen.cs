using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fitScreen : MonoBehaviour {

	// Use this for initialization
	void Start () {
        SpriteRenderer renderer = GetComponent<SpriteRenderer>();

        float worldScreenHeight = Camera.main.orthographicSize * 2;
        float worldScreenWidth = worldScreenHeight / Screen.height * Screen.width;

        transform.localScale = new Vector3(worldScreenWidth / renderer.sprite.bounds.size.x, worldScreenHeight / renderer.sprite.bounds.size.y, 1);
    }
	
	
}
