using UnityEngine;
using System.Collections;

public class QuestGiver : MonoBehaviour {

	public float talkingRange = 1;
	public bool talkStarted;
	public bool talkEnded;

	public bool questTaken;
	public bool showQuestInterface;

	public GameObject currentIcon;
	SpriteRenderer spr;
	public Sprite questIcon;
	public Sprite questTakenIcon;

	public bool speedTaken;
	public float previousSpeed;


	void Start () {
		spr = currentIcon.GetComponent<SpriteRenderer>();
	}
	
	// Update is called once per frame
	void Update () {
		float dist = Vector3.Distance(transform.position,Player.player.transform.position);
		if(dist < talkingRange)
		{
			if(!questTaken && !talkStarted)
			{
				talkStarted = true;
				SpeedControl.currentSpeed = 0;
				showQuestInterface = true;
			}
		}
		else
		{
			talkEnded = false;
			talkStarted = false;
		}


		if(questTaken)
			spr.sprite = questTakenIcon;
		else
			spr.sprite = questIcon;
	}
	void OnGUI(){
		if(showQuestInterface)
			GUI.Window(1000,new Rect(Screen.width/2-100,Screen.height/2-100,200,200),QuestWindow,"Quest");
	}

	void QuestWindow(int id){
		GUI.Label(new Rect(10,25,180,100),"Hello,"+"\n"+"Please send my regards to my pink friend."+"\n"+"Thank you!");
		if(GUI.Button(new Rect(0,150,100,50),"Accept"))
		{
			questTaken = true;
			showQuestInterface = false;
			SpeedControl.currentSpeed = 8;
		}
		if(GUI.Button(new Rect(100,150,100,50),"Decline"))
		{
			showQuestInterface = false;
			SpeedControl.currentSpeed = 8;
		}
	}
}
