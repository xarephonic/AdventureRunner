using UnityEngine;
using System.Collections;

public class BackgroundScroller : MonoBehaviour {


	float offset;
	void Start () {
	
	}

	void Update () {
		offset += SpeedControl.currentSpeed*Time.deltaTime/15;
		if(offset > 1)
			offset -= 1;

		renderer.material.mainTextureOffset = new Vector2(offset,0);
	}
}
