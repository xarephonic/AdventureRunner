using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using fk.adventureRunner;

public class Player : MonoBehaviour {

	public static GameObject player;
	public PlayerObject pObj;
	// Use this for initialization
	void Awake () {
		player = this.gameObject;

	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
