using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public class MapGenerator : MonoBehaviour {


	public GameObject player;

	public List<GameObject> terra = new List<GameObject>();
	public GameObject[] onScreen = new GameObject[4];


	void generateTerra(){
		int rand = Random.Range(0,terra.Count-1);
		terra[rand].transform.position = new Vector3(onScreen[2].transform.position.x+7,0,0);
		onScreen[3] = terra[rand];
		terra.RemoveAt(rand);
	}
	void shiftLeft(){
		terra.Add(onScreen[0]);
		for (int i = 0; i < onScreen.Length-1; i++) 
		{
			onScreen[i] = onScreen[i+1];
		}
		onScreen[onScreen.Length-1] = null;
	}

	void Start () 
	{

	}
	

	void Update () 
	{
		if(onScreen[3].transform.position.x < 16)
		{

			shiftLeft();
			generateTerra();
		}
	}
}
