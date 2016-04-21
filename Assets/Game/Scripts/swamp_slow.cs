using UnityEngine;
using System.Collections;

public class swamp_slow : MonoBehaviour {

	int turn_begin;
	int duration;
	CONTROL_turns controller;
	bool activated;

	// Use this for initialization
	void Start () 
	{
		controller = GameObject.FindWithTag ("GameController").GetComponent<CONTROL_turns>();
		turn_begin = controller.curTurn;
		duration = 3;
		activated = false;

	}

	void OnCollisionEnter (Collision col)
	{
		if(activated)
		{
			if(col.gameObject.tag == "unit")
			{
				col.gameObject.GetComponent<stats>().mov_modifier = 0.5f;
			}
		}
	}
	
	void OnCollisionExit(Collision col) 
	{
		if(activated)
		{
			if(col.gameObject.tag == "unit")
			{
				col.gameObject.GetComponent<stats>().mov_modifier = 1.0f;
			}
		}
	}
	
	// Update is called once per frame
	void Update () 
	{
		//Delete if over duration
		if (turn_begin + duration == controller.curTurn) 
		{
			Destroy (this);
		}
	}
}
