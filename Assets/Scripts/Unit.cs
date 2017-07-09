using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Unit : MonoBehaviour { //u wanna have average group position, individual direction,
	public Rigidbody2D rigid;

	public GameObject manager; //goal pos?
	public GameObject gameManager;
	public Vector2 location = Vector2.zero;
	public Vector2 velocity;
	public Vector2 goalPos = Vector2.zero;
	public Vector2 currentForce;

	// Use this for initialization
	void Start () {
		rigid = this.GetComponent<Rigidbody2D> ();
		velocity = new Vector2 (Random.Range (0.01f, 0.1f), Random.Range (0.01f, 0.1f));
		location = new Vector2 (this.gameObject.transform.position.x, this.gameObject.transform.position.y);
		gameManager = GameObject.Find ("GameManager");
	}
		

//	Update is called once per frame
	void Update () {
		GetComponent<UnitMov> ().flock (this);
		goalPos = manager.transform.position;
		gameManager.GetComponent<GameManager> ().CheckDistance (this.gameObject);
	}

}

