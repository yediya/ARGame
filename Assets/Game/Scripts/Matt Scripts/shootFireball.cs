using UnityEngine;
using System;
using System.Collections;

public class shootFireball : MonoBehaviour {

	public GameObject fireballPF;
	public GameObject fireball;
	public GameObject player1;
	public GameObject player2;
	Vector3 pos;
	Vector3 pos2;
	Vector3 pos3;
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

		if (Input.GetButtonDown ("f") == true) 
		{
			pos = player1.transform.position;
			pos2 = player2.transform.position;
			pos3 = pos2 - pos;
			Debug.Log ("FIREBALL");
			if(true)
			{
				shotActive = true;
				fireball = (GameObject)Instantiate (fireballPF, new Vector3(pos.x, pos.y +1, pos.z), Quaternion.identity);

			}


		}

		if (fireball != null) 
		{
			if (Input.GetButtonDown ("h") == true) 
			{
				Destroy (fireball);
			}
			//Fireball movement
			var move = pos3;
			fireball.transform.position += move * 5.0f * Time.deltaTime;

			if(Math.Abs(fireball.transform.position.magnitude - pos2.magnitude) < 0.2)
			{
				Destroy (fireball);
			}

		}
	}
}
