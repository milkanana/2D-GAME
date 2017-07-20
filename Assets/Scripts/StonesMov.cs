﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StonesMov : MonoBehaviour {

	public float yspeed;
	public float xspeed;

	public bool startleft;
	public bool startright;
	public bool starttop;
	public bool startbottom;

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {

		transform.position = new Vector2 (transform.position.x+xspeed,transform.position.y + yspeed);

		if(startleft == true){
			if((transform.position.x-10)> ( Camera.main.transform.position.y + 10)){
				transform.position = new Vector2(transform.position.x - 40 ,transform.position.y);
			}
		}

		if(startright == true){
			if((transform.position.x + 10) < (Camera.main.transform.position.x - 10)){
				transform.position = new Vector2(transform.position.x+40,transform.position.y);
			}
		}
		if(starttop == true){
			if((this.transform.position.y + 6) < (Camera.main.transform.position.y - Camera.main.orthographicSize )){
				transform.position = new Vector2(transform.position.x,transform.position.y + 24f );
			}
		}
		if(startbottom == true){
			if((this.transform.position.y - 6) > (Camera.main.transform.position.y + Camera.main.orthographicSize)){
				//this.transform.position = new Vector2(startPosX,startPosY);
				this.transform.position = new Vector3(this.transform.position.x, (this.transform.position.y - 24f),this.transform.position.z);
			}
		}
		
	}
}
