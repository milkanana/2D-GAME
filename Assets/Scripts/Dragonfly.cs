using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dragonfly : MonoBehaviour {
	public Vector2 goalPos;
	public GameObject manager;
	private float journeyLength;
	private float startTime;
	GameObject goalPlatform;

	public float timer;

	// Use this for initialization
	void Start () {
		
		goalPlatform = GameObject.FindGameObjectsWithTag("Plate")[Random.Range(0,5)];
		startTime = Time.time;

	}
	
	// Update is called once per frame
	void Update () {


		if(this.transform.position != goalPlatform.transform.position){
		goalPos = goalPlatform.transform.position;
		journeyLength = Vector2.Distance(this.transform.position,goalPos);
		float distCovered = (Time.time - startTime)* 0.01f;
		float fracJourney = distCovered / journeyLength;

			this.transform.position = Vector2.Lerp(this.transform.position,goalPos,fracJourney);}

		if (this.transform.position == goalPlatform.transform.position) {
			this.gameObject.transform.SetParent (goalPlatform.transform);
			timer += Time.deltaTime;
			this.transform.position = Vector2.Lerp (this.transform.position, this.transform.position, 0);
			if (timer > 1) {
				transform.parent = null;
			}
			//now take out the platform out of the lists it'S in rip
			//or make method in unit unitsink() where it takes itself out of the lists it's in and then proceeds to destroy itself.
		}


		
	}
}
