using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwarmManager : MonoBehaviour {

	public GameObject manager;
	public Vector3 range = new Vector3 (5, 5, 5);
	public List<GameObject> swarmList;
	public GameObject playerP;
	public GameObject prefab;

	public int numUnits;
	public float rangeOffSet;

	[Range(0,200)] //range slider yo and its range thingy yea i'm learning things o0o .:+*!
	public int neighbourRange = 50; //anyone outside this range is not. your neighbour ~

	[Range(0,200)]
	public int minimumDistance = 5;

	//if we don'T want them slingslotting, although it could be used in a good way
	[Range(0,2)]
	public float maxforce = 50;

	[Range(0,5)]
	public float maxvelocity = 2.0f;

	// Use this for initialization

	void Start () {
		swarmList = new List<GameObject>(numUnits);
		Create ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}


	void Create(){

		for (int i = 0; i < numUnits; i++) {
			Vector3 unitPos = new Vector3 (-2*range.x +i*range.x, range.y, range.z);

			swarmList.Add (Instantiate (prefab, this.transform.position + new Vector3 (0, rangeOffSet, 0) + unitPos, Quaternion.identity) as GameObject);
			swarmList [i].GetComponent<UnitSwarm> ().manager = this.gameObject;

		}
	}
}
