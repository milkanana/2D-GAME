using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwarmManagerMov : MonoBehaviour {

	public float timer;

	public float interval;
	public float xPos;
	public float ySpeed;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

		timer += Time.deltaTime;
		transform.position = new Vector2 (xPos, transform.position.y - ySpeed);

		if (timer > interval) {
			if(xPos == xPos){
				xPos = -xPos;

			}
			if (xPos == -xPos) {
				xPos = xPos;
			}
			timer = 0;
		}

	}


}
