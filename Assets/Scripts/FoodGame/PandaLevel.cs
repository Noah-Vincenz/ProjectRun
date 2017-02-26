using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PandaLevel : MonoBehaviour
{
	public float dest;
	public float speed;
	public bool checkKeys;
	private int count;
	//Rigidbody2D rb;
	void Start(){
		count = 0;
	}
	// Update is called once per frame
	void Update()
	{
		double posX = transform.position.y;
		if (posX < dest) {
			double updatedPos = posX + (speed/12);
			transform.position = new Vector2(transform.position.x, (float) updatedPos);
		} 
		else if (posX > dest) {
			double updatedPos = posX - (speed/12);
			transform.position = new Vector2(transform.position.x, (float) updatedPos);
		} 
		if (checkKeys) {
			if (Input.GetKey ("w")) {
			
				if (dest == 0) {
					dest = 3;
				}
				if (dest == -3) {
					dest = 0;
				}
			}
			if (Input.GetKey ("s")) {
				if (dest == 3) {
					dest = 0;
				}
				if (dest == 0) {
					dest = -3;
				}

			}
			checkKeys = false;
		} 
		else {
			if (count == 3) {
				checkKeys = true;
				count = 0;
			} else {
				count++;
			}
		}
		
	}
}
