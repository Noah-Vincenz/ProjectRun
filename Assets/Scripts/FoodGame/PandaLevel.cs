using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PandaLevel : MonoBehaviour
{
	public double dest;
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
		if ((posX < dest)&&((dest - posX) > 0.1)) {
			double updatedPos = posX + (speed/12);
			transform.position = new Vector2(transform.position.x, (float) updatedPos);
		} 
		else if ((posX > dest)&&((posX-dest) > 0.1)) {
			double updatedPos = posX - (speed/12);
			transform.position = new Vector2(transform.position.x, (float) updatedPos);
		} 
		if (checkKeys) {
			if (Input.GetKey ("w")) {
			
				if (dest == -0.7) {
					dest = 1.6;
				}
				if (dest == -2.8) {
					dest = -0.7;
				}
			}
			if (Input.GetKey ("s")) {
				if (dest == 1.6) {
					dest = -0.7;
				}
				if (dest == -0.7) {
					dest = -2.8;
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
