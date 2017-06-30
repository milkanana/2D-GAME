using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragonManager : MonoBehaviour {

	public List<GameObject> platforms;

	public GameObject dragonflyPrefab;
	public float speed;
	public Vector2 startpos;
	public Vector2 range;

	public float xPos;
	public float yPos;
	/*public float posOffSetX;
	public float posOffSetY;*/


	/*ok so what does this b1tch need. it needs to choose a platform thingy, get it's position, and then calculate vector so it moves to it
	when it arrives, it needs to settle on the leaf (which causes another reaction but leaf taht for lat er) which means that it's speed is same as leaves speed... 
	just make it a child?

aso and don't forget to tak e the platform out of its list after you've childed the dragonfly to it....
movement either rigidbody or this vector 3 lerp thingy

	*/


	// Use this for initialization
	void Start () {

		for (int i = 0; i < 1; i++){
		DetermineStartPosition ();
			startpos = new Vector2 (xPos,yPos);
		GameObject dragonfly = (GameObject)Instantiate (dragonflyPrefab, startpos, Quaternion.identity);
		}

		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void DetermineStartPosition (){

		xPos = Random.Range (-range.x, range.x);
		yPos = Random.Range (-range.y, range.y);

		//if onscreen...... re roll......


	
/*		float leftright = Random.Range(0,2); //left = 0, right = 1;

		if (leftright == 0) {
			xPos = -xPos;
			posOffSetX = -posOffSetX;
			float topbottom = Random.Range (0,2); //top = 0, bottom = 1;
			if (topbottom == 0) {
				yPos = yPos;
				posOffSetY = posOffSetY;
			} 
			else if(topbottom == 1) {
				yPos = -yPos;
				posOffSetY = -posOffSetY;
			}
		}
		else {
			xPos = xPos;
			posOffSetX = posOffSetX;
			float topbottom = Random.Range (0,2); //top = 0, bottom = 1;
			if (topbottom == 0) {
				yPos = Random.Range(0,yPos);
				posOffSetY = posOffSetY;
			} 
			else if(topbottom == 1){
				yPos = Random.Range(-yPos,0);
				posOffSetY = -posOffSetY;
			}
		}*/
	}
}
