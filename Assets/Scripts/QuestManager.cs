using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;
using fk.adventureRunner;

public class QuestManager : MonoBehaviour {

	Quest currentQuestNegotiated;
	GameObject currentNegotiatedQuestGiver;
	bool showQuestTalkInterface;

	public void showQuestGiverInterface(GameObject g,QuestGiver.QuestEventArgs e)
	{
		showQuestTalkInterface = true;
		currentNegotiatedQuestGiver = g;
		currentQuestNegotiated = e.q;
		Time.timeScale = 0;
	}


	void Start () {
		QuestGiver.talkStart += showQuestGiverInterface;
	}

	void Update () {
	
	}

	void OnGUI(){
		if(showQuestTalkInterface)
		{
			if(GUI.Button(new Rect(100,100,25,25),"X"))
			{
				showQuestTalkInterface = false;
				Time.timeScale = 1;
			}
		}
	}


}
