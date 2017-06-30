using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitMov : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	Vector2 seek(Vector2 target,Vector2 location){
		return(target - location);
	} //just works your direction to target location

	void applyForce(Vector2 f,Unit script){
		Vector3 force = new Vector3 (f.x, f.y, 0);

		if(force.magnitude > script.manager.GetComponent<UnitSwarm>().maxforce) { //constrains...

			force = force.normalized;
			force *= script.manager.GetComponent<UnitSwarm>().maxforce;
		}

		script.rigid.AddForce (force);

		if(script.rigid.velocity.magnitude > script.manager.GetComponent<UnitSwarm>().maxvelocity/*rigid.velocity.x.magnitude > manager.GetComponent<UnitSwarm>().maxvelocityX*/) {
			script.rigid.velocity = script.rigid.velocity.normalized;
			script.rigid.velocity *= script.manager.GetComponent<UnitSwarm>().maxvelocity;
		}
		Debug.DrawRay (this.transform.position, force, Color.white);

	}

	//aligning and cohesion with group

	Vector2 align(Unit script) {
		float neighbourdistance = script.manager.GetComponent<UnitSwarm> ().neighbourRange;
		Vector2 sum = Vector2.zero; // we gon take this and divide by count, for average ???
		int count = 0;

		foreach (GameObject other in script.manager.GetComponent<UnitSwarm>().unitsList) { //for every obj in that unit list
			if (other == this.gameObject) continue;

			float d = Vector2.Distance (script.location, other.GetComponent<Unit> ().location); //ye it's doing the point A- point B thingy for us

			if (d < neighbourdistance) { //now if it's smaller than the neighbourdistance (range), then it's a neighbour! congrats
				sum += other.GetComponent<Unit> ().velocity; //we want that for the average velocities, it's just adding the velocities for the top part
				count++; //you have one neighbour more, add him to the count ye >>>>>> sum/count = average thing
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

	Vector2 cohesion(Unit script) { //stick to your group yeeee
		float neighbourdistance = script.manager.GetComponent<UnitSwarm>().neighbourRange;
		Vector2 sum = Vector2.zero;
		int count = 0;

		foreach (GameObject other in script.manager.GetComponent<UnitSwarm>().unitsList) {
			if (other == this.gameObject)
				continue;

			float d = Vector2.Distance (script.location, other.GetComponent<Unit> ().location);

			if (d < neighbourdistance) {
				sum += GetComponent<Unit> ().location; //here'S the difference, rather than average directoin, you get average location
				count ++;
			}

			if (count < 0) {
				sum /= count;
				return seek (sum,script.location);
			}
		}
		return Vector2.zero;
	}




	public void flock(Unit script){

		script.location = this.transform.position;
		script.velocity = script.rigid.velocity;


			Vector2 ali = align( script);
			Vector2 coh = cohesion( script);
			Vector2 goalloc;

			goalloc = seek (script.goalPos,script.location); //calculates local position - goalPos, A-B thingy for a vector for direction
			script.currentForce = goalloc + ali + coh;

			script.currentForce = script.currentForce.normalized;

		Vector2 a = new Vector2 (script.currentForce.x * 3, script.currentForce.y);
		applyForce (a, script);

	} 

	void Update(){
	}
}