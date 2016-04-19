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
	public Renderer rend;
	public Color red = Color.red;
	public Color white = Color.white;
	public float stepSize;
	public stats stats;
	public CONTROL_turns controller;
	public int pathLength;
	public Vector3[] path;

	//Have we started moving
	bool startMov;


	public float initMovP;
	public Vector3 initPos;

	private LineRenderer LineDrawer;


	// Use this for initialization
	void Start () 
	{
		controller = GameObject.FindWithTag ("GameController").GetComponent<CONTROL_turns>();
		LineDrawer = GetComponent<LineRenderer>();
		LineDrawer.SetWidth (0.1f, 0.1f);

		//Read in data from stats script
		stats = this.GetComponent<stats> ();

		movP = stats.movP;
		pos = gameObject.transform.position;

		initMovP = movP;
		initPos = pos;

		//Access the color of the base
		rend = GetComponent<Renderer>();

		oldPos = gameObject.transform.position;

		stepSize = 0.1f;

		startMov = false;

		path = new Vector3[100];
		//Debug.Log ("----------------Array Length1----------------------: " + path.Length);
		pathLength = 0;
	
	}
	
	// Update is called once per frame
	void Update ()
	{
		if (controller.curPlayer == stats.owner) 
		{
			pos = gameObject.transform.position;
			//if(controller.curPlayer == stats.owner)		
			//If we moved greater than stepSize units, 
			if (Math.Abs (oldPos.magnitude - pos.magnitude) > stepSize) {
				if (startMov == false) {
					initPos = pos;
					initMovP = movP;
				}
				  
				//Object has started moving
				startMov = true;
			

				//Save this point of the path
				Debug.Log ("Path Length: " + pathLength);
				Debug.Log ("Array Length: " + path.Length);

				path [pathLength] = pos;
				pathLength++;

				//update oldPos
				oldPos = pos;
				//And reduce our movement points
				//this.GetComponent<stats> ().movP -= Math.Abs (oldPos.magnitude - pos.magnitude);
				if (stats.movP > 0) {
					stats.movP -= stepSize;
				}

			}
			//f we move too far, set the color to red
			if (stats.movP < 0) {
				rend.material.SetColor ("_Color", Color.red);
				stats.valid = false;
			} else {
				rend.material.SetColor ("_Color", Color.white);
				stats.valid = true;
			}
		}
	}
}
