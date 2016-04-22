using UnityEngine;
using System;
using System.Collections;

public class SPELL_fireball: MonoBehaviour{

	public GameObject fireball_effect;
	public GameObject fireballPF;
	public GameObject fireball;
	public GameObject target;
	bool activated;
	Vector3 pos1;
	Vector3 pos2;
	Vector3 posM;
	Vector3 posStart;
	//	public bool shotActive;
	Vector3 moveDir= new Vector3( 0, -1, 0);
//	public bool shotActive;

	// Use this for initialization
	void Start()
	{
		activated = false;
		target = null;
		//Set to player castle in future
		pos1 = new Vector3 (0, 0, 0);
	}

	//Set the target 
	void OnCollisionEnter (Collision col)
	{
		if(target == null)
		{
			if(col.gameObject.tag == "unit")
			{
				target = col.gameObject;
			}
		}
	}

	//How to untarget (and choose another if need)
	void OnCollisionExit(Collision col) 
	{
		if (target != null)
		{
			if(col.gameObject == target)
			{
				target = null;
			}
		}
	}

	// Update is called once per frame
	void Update()
	{
		if (activated && target != null) 
		{
			pos2 = target.transform.position;
			posM= pos2- pos1;
			fireball = (GameObject)Instantiate (fireballPF, pos1, Quaternion.identity);

			//Fireball movement
			var move = posM;
			fireball.transform.position += move * 5.0f * Time.deltaTime;

			//Fireball explode - put explode animation here
			if (Math.Abs (fireball.transform.position.magnitude - pos2.magnitude) < 0.2)
			{
				Destroy (fireball);

				//We then leave behind a fireball effect, with which we can resolve AOE, 
				//which could damage for x turns etc;
				fireball = (GameObject)Instantiate (fireball_effect, this.transform.position, this.transform.rotation);
			}
		}
	}
}

	////////////////////OLD FIREBALL CODE///////////////////////////////


			
			/*if( Input.GetButtonDown( "f")== true){
			if( player1== null || player2== null){
				Debug.Log( "FIREBALL: Player not set to anything!");
			}
			else{
				pos1= player1.transform.position;
				pos2= player2.transform.position;
				posM= posP2- posP1;
				Debug.Log( "FIREBALL");
		//		if( true){
//					shotActive= true;
					fireball=( GameObject) Instantiate( fireballPF, new Vector3( posP1.x, posP1.y +1, posP1.z), Quaternion.identity);
		//		}
			}
		}

		//This animates the fireball
		if (fireball != null) 
		{
			if (Input.GetButtonDown( "h")== true){
				Destroy (fireball);
			}
			//Fireball movement
			var move = posM;
			fireball.transform.position += move * 5.0f * Time.deltaTime;

			if(Math.Abs(fireball.transform.position.magnitude - posP2.magnitude) < 0.2)
			{
				Destroy( fireball);
				//We then leave behind a fireball effect, with which we can resolve AOE, 
				//which could damage for x turns etc;
				fireball = (GameObject)Instantiate (fireball_effect, this.transform.position, this.transform.rotation);
			}

		}

	}
}*/
