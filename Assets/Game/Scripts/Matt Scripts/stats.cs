using UnityEngine;
using System.Collections;

public class stats : MonoBehaviour {

	public int hp;
	public int atk;
	//Current amount
	public float movP;
	//Amount to reset to
	public float maxMovP;
	//Validity of position 
	public bool valid;

	public int owner;

	// Use this for initialization
	void Start () 
	{
		init ();	
	}

	void init()
	{
		hp = 4;
		atk = 1;
		movP = 3;
		maxMovP = 3;
		valid = true;
		owner = -1;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
