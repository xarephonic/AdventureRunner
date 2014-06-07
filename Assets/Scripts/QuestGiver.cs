using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;
using fk.adventureRunner;

public class QuestGiver : MonoBehaviour {

	public float talkingRange = 1;
	public bool eventSent;
	public Quest myQuest;
	public string myName;

	public GameObject currentIcon;
	SpriteRenderer spr;
	public Sprite questIcon;
	public Sprite questTakenIcon;

	public delegate void QGiverEventHandler(GameObject sender,QuestEventArgs e);

	public static event QGiverEventHandler talkStart;

	public static void OnTalkStart(GameObject sender,QuestEventArgs e)
	{
		if(talkStart != null)
		{
			talkStart(sender,e);
		}
	}

	public class QuestEventArgs : EventArgs
	{
		public string giverName;
		public Quest q;

		public QuestEventArgs(Quest quest, string giver)
		{
			this.giverName = giver;
			this.q = quest;
		}

	}

	void Start () {
		spr = currentIcon.GetComponent<SpriteRenderer>();
	}
	
	// Update is called once per frame
	void Update () {
		float dist = Vector3.Distance(transform.position,Player.player.transform.position);
		if(dist < talkingRange && !eventSent)
		{
			talkStart(gameObject,new QuestEventArgs(myQuest,myName));
			eventSent = true;
		}
		else if(dist >= talkingRange)
		{
			eventSent = false;
		}
	}
}
