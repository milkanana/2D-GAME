using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitSwarmMov : MonoBehaviour {

	// Use this for initialization
	void Start () {

	}


	Vector2 seek(Vector2 target,Vector2 location){
		return(target - location);
	} //just works your direction to target location

	void applyForce(Vector2 f, UnitSwarm script){
		Vector3 force = new Vector3 (f.x, f.y, 0);

		if(force.magnitude > script.manager.GetComponent<SwarmManager>().maxforce) { //constraints...

			force = force.normalized;
			force *= script.manager.GetComponent<SwarmManager>().maxforce;
		}

		script.rigid.AddForce (force);

		if(script.rigid.velocity.magnitude > script.manager.GetComponent<SwarmManager>().maxvelocity) {
			script.rigid.velocity = script.rigid.velocity.normalized;
			script.rigid.velocity *= script.manager.GetComponent<SwarmManager>().maxvelocity;
		}
		Debug.DrawRay (this.transform.position, force, Color.white);

	}

	Vector2 align(UnitSwarm script) {
		float neighbourdistance = script.manager.GetComponent<SwarmManager> ().neighbourRange;
		Vector2 sum = Vector2.zero; // we gon take this and divide by count, for average ???
		int count = 0;

		foreach (GameObject other in script.manager.GetComponent<SwarmManager>().swarmList) { //for every obj in that unit list
			if (other == this.gameObject) continue;
			if (other.GetComponent<UnitSwarm> () != null) {
				float d = Vector2.Distance (script.location, other.GetComponent<UnitSwarm> ().location); //ye it's doing the point A- point B thingy for us

				if (d < neighbourdistance) { //now if it's smaller than the neighbourdistance (range), then it's a neighbour! congrats
					sum += other.GetComponent<UnitSwarm> ().velocity; //we want that for the average velocities, it's just adding the velocities for the top part
					count++; //you have one neighbour more, add him to the count ye >>>>>> sum/count = average thing
				}
			}
		}

		if (count > 0) {
			sum /= count;
			Vector2 steer = sum - script.velocity; //average group heading - our current velocity

			/*so friend. your thingy wants to move a certain direction. but it's in a group, so
		it needs to adjust its steering direction. basically you're adding two vectors to create
		a compromise kind of direction*/

			return steer;
		}

		return Vector2.zero;
	}


	Vector2 cohesion(UnitSwarm script) { //stick to your group yeeee
		float neighbourdistance = script.manager.GetComponent<SwarmManager>().neighbourRange;
		Vector2 sum = Vector2.zero;
		int count = 0;

		foreach (GameObject other in script.manager.GetComponent<SwarmManager>().swarmList) {
			if (other == this.gameObject)
				continue;

			float d = Vector2.Distance (script.location, other.GetComponent<UnitSwarm> ().location);

			if (d < neighbourdistance) {
				sum += GetComponent<UnitSwarm> ().location; //here'S the difference, rather than average directoin, you get average location
				count ++;
			}

			if (count < 0) {
				sum /= count;
				return seek (sum, script.location);
			}
		}
		return Vector2.zero;
	}


	public void flock(UnitSwarm script){

		script.location = this.transform.position;
		script.velocity = script.rigid.velocity;

		Vector2 ali = align(script);
		Vector2 coh = cohesion(script);
		Vector2 goalloc;

		goalloc = seek (script.goalPos,script.location); //calculates local position - goalPos, A-B thingy for a vector for direction
		script.currentForce = goalloc + ali + coh;
			

		script.currentForce = script.currentForce.normalized;
		applyForce (script.currentForce, script);

	}


// Update is called once per frame
void Update () {

}
}
