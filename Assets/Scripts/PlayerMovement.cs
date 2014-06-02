using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PlayerMovement : MonoBehaviour {

	public bool grounded;
	public List<GameObject> touchedGround = new List<GameObject>();


	public bool jumpAvailable = true;
	float jumpCooldownAmount = 0.5f;

	IEnumerator jumpCooldown(){
		Debug.Log("invoke started");
		yield return new WaitForSeconds(jumpCooldownAmount);
		Debug.Log("invoke complete");
		jumpAvailable = true;
	}

	void OnCollisionEnter2D(Collision2D col)
	{
		if(col.gameObject.tag == "ground")
		{
			if(!touchedGround.Contains(col.gameObject))
				touchedGround.Add(col.gameObject);
		}
	}

	void OnCollisionExit2D(Collision2D col)
	{
		if(col.gameObject.tag == "ground")
		{
			if(touchedGround.Contains(col.gameObject))
				touchedGround.Remove(col.gameObject);
		}
	}

	void UpdateGroundedStatus(){
		if(touchedGround.Count > 0)
			grounded = true;
		else
			grounded = false;
	}


	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		UpdateGroundedStatus();
		if(Input.touchCount > 0 && grounded && jumpAvailable)
		{
			rigidbody2D.velocity = new Vector2(0,6);
			grounded = false;
			jumpAvailable = false;
			StartCoroutine(jumpCooldown());
		}
		if(Input.GetKey(KeyCode.Mouse0) && grounded && jumpAvailable)
		{
			rigidbody2D.velocity = new Vector2(0,6);
			grounded = false;
			jumpAvailable = false;
			StartCoroutine(jumpCooldown());
		}
		if(Input.GetKey(KeyCode.Escape))
			Application.Quit();
	}
}
