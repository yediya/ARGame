using UnityEngine;
using System.Collections;

public class shootMeteor : MonoBehaviour {

	public GameObject meteorPF;
	public GameObject meteor;
	public GameObject player1;
	public GameObject player2;
	Vector3 pos;
	public bool shotActive;
	
	// Use this for initialization
	void Start () 
	{
		player1 = GameObject.FindWithTag ("player1");
		player2 = GameObject.FindWithTag ("player2");
		if (player1 == null || player2 == null) 
		{
			Debug.Log ("Player not set to anything!");
		}
		

	}
	
	// Update is called once per frame
	void Update () 
	{
		
		if (Input.GetButtonDown ("g") == true) 
		{
			pos = player2.transform.position;

			Debug.Log ("meteor");
			if(true)
			{
				
				shotActive = true;
				meteor = (GameObject)Instantiate (meteorPF, new Vector3(pos.x, pos.y+5, pos.z), Quaternion.identity);
				meteor.transform.LookAt (player2.transform);
				
			}
			
			
		}
		
		if (meteor != null) {
			//meteor movement
			var move = new Vector3 (0, -1, 0);
			meteor.transform.position += move * 5.0f * Time.deltaTime;
		}
	}
}
