using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using fk.adventureRunner;

public class EncounterManager : MonoBehaviour {

	
	public List<EnemyObject> encounteredEnemies = new List<EnemyObject>();
	public PlayerObject pObj;

	void Start () {
		pObj = Player.playerRef.pObj;
	}
	

	void Update () {
	
	}
}
