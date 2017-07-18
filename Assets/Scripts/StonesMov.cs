using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StonesMov : MonoBehaviour {

	public float yspeed;
	public float xspeed;

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {

		transform.position = new Vector2 (transform.position.x+xspeed,transform.position.y + yspeed);
		
	}
}
