using UnityEngine;
using System.Collections;

public class SPELL_haste : MonoBehaviour 
{
	
	int turn_begin;
	int duration;
	stats target_stats;
	CONTROL_turns controller;
	bool activated;
	bool used;
	
	// Use this for initialization
	void Start () 
	{
		controller = GameObject.FindWithTag ("GameController").GetComponent<CONTROL_turns>();
		turn_begin = controller.curTurn;
		duration = 3;
		activated = false;
		target_stats = null;
		
	}
	
	void OnCollisionEnter (Collision col)
	{
		//So only one unit can be affected. Spell may have an arrow hotbox, as to make targetting easier
		if(activated && !used)
		{
			if(col.gameObject.tag == "unit")
			{
				used = true;
				target_stats = col.gameObject.GetComponent<stats>();
				target_stats.mov_modifier = 2.0f;

			}
		}
	}
	
	// Update is called once per frame
	void Update () 
	{
		if(target_stats != null)
		{
			//If over duration
			if (turn_begin + duration == controller.curTurn) 
			{
				//Reset the modifier to what it should be
				target_stats.mov_modifier = 1.0f;
			}
		}
	}
}
