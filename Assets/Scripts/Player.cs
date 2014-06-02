using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {

	public static GameObject player;
	// Use this for initialization
	void Awake () {
		player = this.gameObject;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
