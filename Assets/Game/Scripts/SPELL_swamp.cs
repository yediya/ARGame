using UnityEngine;
using System.Collections;

public class SPELL_swamp : MonoBehaviour {

	GameObject swamp;
	public GameObject swamp_pf;
	Vector3 pos;
	public bool activated;
	public int duration;
	public int turns_active;
 
	// Use this for initialization
	void Start () 
	{
		turns_active = 0;
		duration = 3;
		swamp = (GameObject)Instantiate (swamp_pf, this.transform.position, this.transform.rotation);
	}
	
	// Update is called once per frame
	void Update () 
	{
		//Need to count the turns somehow - as the card effect will persist 

		//Psuedocode
		//for(3 turns)

		if (!activated) 
		{
			swamp.transform.position = this.transform.position;
			swamp.transform.rotation = this.transform.rotation;
		}
	}
}
