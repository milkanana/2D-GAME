using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {
	public GameObject manager;

	public GameObject prefab; // uniunitmanager
	public GameObject dfmanager; //dragonfly manager prefab
	public List<GameObject> swarmManagerList;
	public List<GameObject> unitList; //all the platform leaves
	// Use this for initialization
	void Start () {

		GameObject swarmManager = (GameObject)Instantiate (prefab, this.transform.position, Quaternion.identity);
		//GameObject dragonmanager = (GameObject)Instantiate (dfmanager, this.transform.position, Quaternion.identity);

		swarmManagerList.Add (swarmManager);


	}

	// Update is called once per frame
	void Update () {
	}

}