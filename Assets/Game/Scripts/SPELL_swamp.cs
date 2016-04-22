using UnityEngine;
using System.Collections;

public class SPELL_swamp : MonoBehaviour {

	GameObject swamp;
	public GameObject swamp_pf;
	public bool activated;

 
	// Use this for initialization
	void Start () 
	{

	}
	
	// Update is called once per frame
	void Update () 
	{
		/*if (!activated) 
		{
			//Keep being able to move until activated
			swamp.transform.position = this.transform.position;
			swamp.transform.rotation = this.transform.rotation;
		}*/
		if (activated) 
		{
			swamp = (GameObject)Instantiate (swamp_pf, this.transform.position, this.transform.rotation);
		}

	}
}
