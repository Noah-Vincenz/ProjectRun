using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodMovementScript : MonoBehaviour {

	public double speed;
	// Update is called once per frame
	void Update () {
		double posX = transform.position.x;
		double updatedPos = posX - (speed/10);
		transform.position = new Vector2((float) updatedPos, transform.position.y);
	}

	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.gameObject.CompareTag ("FoodEndpoint"))
		{
			float newYPos = 0;
			float rInteger = Random.value;
			if (rInteger > 0.66) {
				newYPos = 1;
			} else if (rInteger > 0.33) {
				newYPos = -2;
			} else {
				newYPos = (float) -4.9;
			}
			transform.position = new Vector2(66, newYPos);
			//print ("Collided");
		}
	}
}
