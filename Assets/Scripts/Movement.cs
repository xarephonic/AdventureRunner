using UnityEngine;
using System.Collections;

public class Movement : MonoBehaviour {



	void Update(){
		if(transform.position.x > -15)
		{
			transform.Translate(new Vector3(SpeedControl.currentSpeed*Time.deltaTime*-1,0,0));
		}
	}

}
