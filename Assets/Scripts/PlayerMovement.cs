using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour {

	public bool grounded;

	public bool jumpAvailable = true;
	float jumpCooldownAmount = 1.0f;

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
			grounded = true;
		}
	}


	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
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
