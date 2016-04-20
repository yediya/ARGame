using UnityEngine;
using System;
using System.Collections;

public class movement : MonoBehaviour 
{
	//Our peices movement points - how far it can move per turn
	float movP;



	//Peices position
	Vector3 pos;

	Vector3 oldPos;

	public float stepSize;
	private stats stats;
	public CONTROL_turns controller;
	public int pathLength;
	public Vector3[] path;

	//Have we started moving
	bool startMov;


	public float initMovP;
	public Vector3 initPos;

	//These variables are for changing the base color
	public Renderer rend;
	public Color red = Color.red;
	public Color white = Color.white;


	// Use this for initialization
	void Start () 
	{
		controller = GameObject.FindWithTag ("GameController").GetComponent<CONTROL_turns>();
	
		//Read in data from stats script
		stats = this.GetComponent<stats> ();

		movP = stats.movP;
		pos = gameObject.transform.position;

		initMovP = movP;
		initPos = pos;

		//Access the color of the base
		rend = GetComponent<Renderer>();

		oldPos = gameObject.transform.position;

		stepSize = 1.0f;

		startMov = false;

		path = new Vector3[100];
		//Debug.Log ("----------------Array Length1----------------------: " + path.Length);
		pathLength = 0;
	
	}
	
	// Update is called once per frame
	void Update ()
	{
		//pos = gameObject.transform.position;

		if (controller.curPlayer == stats.owner) 
		{
			//If we start moving the marker, but it is so far less than our stepSize,
			//de-sync the model on top
			if (Math.Abs (oldPos.magnitude - pos.magnitude) < stepSize) 
			{
				stats.sync = false;
			}

			//If we moved greater than stepSize units, 
			if (Math.Abs (oldPos.magnitude - pos.magnitude) > stepSize) 
			{
				if (startMov == false) 
				{
					initPos = pos;
					initMovP = movP;
				}
				  
				//Object has started moving
				startMov = true;
			
				//sync with marker
				stats.sync = true;

				Debug.Log ("Path Length: " + pathLength);
				Debug.Log ("Array Length: " + path.Length);

				//Save this point of the path
				path [pathLength] = pos;
				pathLength++;

				//update oldPos
				oldPos = pos;
				//And reduce our movement points
				//this.GetComponent<stats> ().movP -= Math.Abs (oldPos.magnitude - pos.magnitude);
				if (stats.movP >= stepSize*(1/stats.mov_modifier)) 
				{
					stats.movP -= stepSize*(1/stats.mov_modifier);
				}
				//Will not allow to move to the point of death
				else if(stats.hp > stepSize*(1/stats.mov_modifier))
				{
					stats.hp -= (int)(stepSize*(1/stats.mov_modifier));
				}

				//If we move at the cost of hit points, set the color to red
				if (stats.movP < 0) 
				{
					rend.material.SetColor ("_Color", Color.red);
				} 
				else 
				{
					rend.material.SetColor ("_Color", Color.white);
				}

			}
			else
			{
				//Peice should not be moved. It belongs to a player whose turn it isnt.

			}

	
		}
	}
}
