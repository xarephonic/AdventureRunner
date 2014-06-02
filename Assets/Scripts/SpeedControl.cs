using UnityEngine;
using System.Collections;

public class SpeedControl : MonoBehaviour {

	public static float currentSpeed;
	// Use this for initialization
	void Awake () {
		currentSpeed = 8;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnGUI(){
		if(GUI.Button(new Rect(Screen.width-75,0,25,25),"+"))
		{
			currentSpeed+=1;
		}
		GUI.Label(new Rect(Screen.width-50,0,25,25),currentSpeed.ToString());
		if(GUI.Button(new Rect(Screen.width-25,0,25,25),"-"))
		{
			currentSpeed-=1;
		}
	}
}
