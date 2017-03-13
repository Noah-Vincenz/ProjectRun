using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PandaLevel : MonoBehaviour
{
	public double dest;
	public float speed;
	public bool checkKeys;
	private int count;

	private bool upPressed, downPressed;
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
//		if (checkKeys) {
			if (Input.GetKey ("w") && !upPressed) {
				upPressed = true;

				if (dest == -0.7) {
					dest = 1.6;
				}
				else if (dest == -2.8) {
					dest = -0.7;
				}
			}
			if (Input.GetKey ("s") && !downPressed) {
				downPressed = true;

				if (dest == 1.6) {
					dest = -0.7;
				}
				else if (dest == -0.7) {
					dest = -2.8;
				}

			}
//			checkKeys = false;
//		} 

		if (Input.GetKeyUp ("w")) {
			upPressed = false;
		}
		if (Input.GetKeyUp ("s")) {
			downPressed = false;
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

	public void WalkUp() {
		if (dest == -0.7) {
			dest = 1.6;
		}
		else if (dest == -2.8) {
			dest = -0.7;
		}

	}

	public void WalkDown() {
		if (dest == 1.6) {
			dest = -0.7;
		}
		else if (dest == -0.7) {
			dest = -2.8;
		}

	}

}
