using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Platform : MonoBehaviour {

	Rigidbody2D rigid;
	float speed = 1;
	float value = 0.02f;
	int randomInt;

	// Use this for initialization
	void Start () {
		rigid = GetComponent <Rigidbody2D> ();
		randomInt = Random.Range (0, 4);
	}
	
	// Update is called once per frame
	void Update () {
		speed = speed + value;

		if (speed >= 1.25f) {
			value = -0.04f;
		}
		if (speed <= -1.25f) {
			value = 0.04f;
		}

		//random movement
		/*if (randomInt == 0) {
			MoveHorizontal ();
		}*/
	/*	if (randomInt == 1) {
			MoveVertical ();
		}*/
		if (randomInt == 2) {
			RotationLeft ();
		}
		if (randomInt == 3) {
			RotationRight ();
		}
		
	}

	void MoveHorizontal () {
		rigid.velocity = new Vector2 (rigid.velocity.x * speed, rigid.velocity.y);
	}
/*	void MoveVertical () {
		rigid.velocity = new Vector2 (rigid.velocity.x, rigid.velocity.y * speed);
	}*/
	void RotationLeft()
	{
		transform.Rotate(Vector3.forward, Time.deltaTime * 15);		
	}
	void RotationRight()
	{
		transform.Rotate(Vector3.back, Time.deltaTime * 15);		
	}
}
