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
	

}
