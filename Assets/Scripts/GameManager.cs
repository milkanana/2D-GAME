using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

	public GameObject prefab; // uniunitmanager
	public GameObject dfmanager; //dragonfly manager prefab
	public List<GameObject> swarmManagerList;
	public List<GameObject> unitList; //all the platform leaves

	public float minDistance;
	public float pushForce;
	public int numUnits; //amount of units to be spawned
	public float respawnPoint;
	GameObject highestUnit;

/*	void OnDrawGizmos(){
		Gizmos.color = Color.cyan;
		Gizmos.DrawWireSphere (highestUnit.transform.position, 2.0f);
	}*/

	// Use this for initialization
	void Start () {
		highestUnit = this.gameObject;

		for (int i = 0; i < numUnits; i++){

		//GameObject dragonmanager = (GameObject)Instantiate (dfmanager, this.transform.position, Quaternion.identity);
			swarmManagerList.Add (Instantiate (prefab, this.transform.position, Quaternion.identity));
			swarmManagerList [i].GetComponent<SwarmManager>().manager = this.gameObject;
		}
	}

	// Update is called once per frame
	void Update () {
		foreach(GameObject nugget in unitList){
			if(nugget.transform.position.y > highestUnit.transform.position.y ){
				highestUnit = nugget;
			}
		}
		Debug.DrawLine (highestUnit.transform.position, highestUnit.transform.position + new Vector3(2,0,0),Color.green,0.2f );

		if (highestUnit.transform.position.y < respawnPoint && highestUnit != this.gameObject) {
			swarmManagerList.Add (Instantiate (prefab, this.transform.position, Quaternion.identity));
		}
	}

	public Vector2 CheckDistance(GameObject  unitToCheck){
		Vector2 forceDirection = Vector2.zero;
		foreach (GameObject otherUnit in unitList) {
			if(otherUnit != unitToCheck){
				float distance = Vector3.Distance (unitToCheck.transform.position, otherUnit.transform.position);
				if (distance < minDistance) {
					Vector2 forceDirectionTemp = (Vector2)unitToCheck.transform.position - (Vector2)otherUnit.transform.position;
					forceDirection += forceDirectionTemp.normalized;
				}
			}
		}
		return forceDirection.normalized;
	}
}