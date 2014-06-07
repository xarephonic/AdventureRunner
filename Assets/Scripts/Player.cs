using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using fk.adventureRunner;

public class Player : MonoBehaviour {

	public static GameObject player;
	public static Player playerRef;
	public PlayerObject pObj = new PlayerObject();
	// Use this for initialization
	void Awake () {
		player = this.gameObject;
		playerRef = this;

	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
