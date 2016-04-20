using UnityEngine;
using System.Collections;

public class connectModel : MonoBehaviour {

	public GameObject model;
	public stats stats;

	// Use this for initialization
	void Start () 
	{
		stats = model.GetComponent<stats>();
	}
	
	// Update is called once per frame
	void Update () 
	{
		if(stats.sync == true)
		{
			model.transform.position = this.transform.position;
			model.transform.rotation = this.transform.rotation;
		}
	}
}
