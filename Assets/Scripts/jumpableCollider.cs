using UnityEngine;
using System.Collections;

public class jumpableCollider : MonoBehaviour {

	public float myHeight;
	public float playerHeight;
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		myHeight = transform.position.y;
		playerHeight = Player.player.transform.position.y;

		if (Player.player.transform.position.y > transform.position.y+0.9f) 
			gameObject.collider2D.enabled = true;
		else if(Player.player.transform.position.y <= transform.position.y+0.9f)
			gameObject.collider2D.enabled = false;
	}
}
