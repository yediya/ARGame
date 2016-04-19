using UnityEngine;
using System;
using System.Collections;

public class SPELL_fireball: MonoBehaviour{

	public GameObject fireballPF;
	public GameObject fireball;
	public GameObject player1;
	public GameObject player2;
	Vector3 posP1;
	Vector3 posP2;
	Vector3 posM;
	Vector3 posStart;
	//	public bool shotActive;
	Vector3 moveDir= new Vector3( 0, -1, 0);
//	public bool shotActive;

	// Use this for initialization
	void Start(){
		player1= GameObject.FindWithTag( "11");
		player2= GameObject.FindWithTag( "12");
	}

	// Update is called once per frame
	void Update(){
		if( Input.GetButtonDown( "f")== true){
			if( player1== null || player2== null){
				Debug.Log( "FIREBALL: Player not set to anything!");
			}
			else{
				posP1= player1.transform.position;
				posP2= player2.transform.position;
				posM= posP2- posP1;
				Debug.Log( "FIREBALL");
		//		if( true){
//					shotActive= true;
					fireball=( GameObject) Instantiate( fireballPF, new Vector3( posP1.x, posP1.y +1, posP1.z), Quaternion.identity);
		//		}
			}
		}

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
			}

		}
	}
}
