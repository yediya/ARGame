using UnityEngine;
using System.Collections;

public class stats : MonoBehaviour {

	public int hp;
	public int atk;
	//Current amount
	public float movP;
	//Amount to reset to
	public float maxMovP;
	//MovP modifier - X < 1 for increased speed (haste), X > 1 for slowed speed (swamp)
	public float mov_modifier;
	//Validity of position 
	public bool valid;
	//IF the model should be on top of the marker
	public bool sync;
	//Set to 1 or 2
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
		sync = true;
 		owner = -1;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
