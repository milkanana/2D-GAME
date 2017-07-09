using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitSwarm : MonoBehaviour {

	public GameObject gameManager;
	public GameObject [] unitsList;
	public List<GameObject> prefabs;
	public int numUnits;
	public Vector3 range = new Vector3 (5, 5, 5); //first appearance space basically, z is not necessary ... just use vector 2

	public bool seekGoal = true;
	public bool obedient = true; //follow the flocking rules
	public bool willful = false; //will choose to go off another direction regardless of flocking
	public float distancetoneighbour;

	public Rigidbody2D rigid;
	public GameObject manager; 
	public Vector2 location = Vector2.zero;
	public Vector2 velocity;
	public Vector2 goalPos = Vector2.zero;
	public Vector2 currentForce;


	[Range(0,200)] //range slider yo and its range thingy yea i'm learning things o0o .:+*!
	public int neighbourRange = 50; //anyone outside this range is not. your neighbour ~

	[Range(0,200)]
	public int minimumDistance = 5;

	//if we don'T want them slingslotting, although it could be used in a good way
	[Range(0,2)]
	public float maxforce = 50;

	[Range(0,5)]
	public float maxvelocity = 2.0f;




	void OnDrawGizmosSelected(){
		Gizmos.color = Color.yellow; //range
		Gizmos.DrawWireCube (this.transform.position, range * 2);
		Gizmos.color = Color.green; 
		Gizmos.DrawWireSphere (this.transform.position, 2.0f);
	}
	// Use this for initialization

	void Start () {

		gameManager = GameObject.Find ("GameManager");

		rigid = this.GetComponent<Rigidbody2D> ();

		unitsList = new GameObject[numUnits];

		for (int i = 0; i < numUnits; i++) {
			int indexnum = Random.Range (0, prefabs.Count);
			Vector3 unitPos = new Vector3 (Random.Range (-range.x, range.x),
				Random.Range (-range.y, range.y), 
				Random.Range (-range.z, range.z));

			unitsList [i] = Instantiate (prefabs[indexnum], this.transform.position + unitPos, Quaternion.identity) as GameObject;
			unitsList [i].GetComponent<Unit> ().manager = this.gameObject;
			unitsList [i].transform.SetParent (this.transform);
			gameManager.GetComponent<GameManager> ().unitList.Add (unitsList[i]);

		}
	}

	// Update is called once per frame
	void Update () {
		GetComponent<UnitSwarmMov>().flock (this);
		goalPos = manager.GetComponent<SwarmManager>().transform.position;

		if (this.transform.position.y < manager.gameObject.GetComponent<SwarmManager>().transform.position.y + 6) {
			manager.gameObject.GetComponent<SwarmManager> ().swarmList.Remove (this.gameObject);
			foreach (GameObject unit in unitsList) {
				gameManager.GetComponent<GameManager> ().unitList.Remove (unit);
			}
			Destroy (this.gameObject);
		}

	}

	/*public GameObject GetFirstObject(){
		if(units != null){
			return units [0];
		}
		return null;
	}*/ //AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA


}


