using UnityEngine;
using System.Collections;

public class SPELL_meteor: MonoBehaviour{

	public GameObject meteorPF;
	public GameObject meteor;
	public GameObject player1;
	public GameObject player2;
	Vector3 posStart;
//	public bool shotActive;
	Vector3 moveDir= new Vector3( 0, -1, 0);
	
	// Use this for initialization
	void Start(){
		player1= GameObject.FindWithTag( "11");
		player2= GameObject.FindWithTag( "12");
		if( player1== null || player2== null)
			Debug.Log( "METEOR: Player not set to anything!");
	}
	
	// Update is called once per frame
	void Update(){
		if( Input.GetButtonDown( "g")== true&& meteor== null){
			Debug.Log( "METEOR!!!!");
			posStart= player1.transform.position;
			posStart.y+= 5;
			meteor=( GameObject) Instantiate( meteorPF, posStart, Quaternion.identity);
		}
		if( meteor!= null){
			Vector3 posMove= meteor.transform.position;
			if( posMove.y<( posStart.y- 5)) Destroy( meteor);
			else meteor.transform.position+= moveDir* 5.0f* Time.deltaTime;
			Debug.Log( "METEOR IMPACT IN: "+( int)( posMove.y- posStart.y+ 5));
		}
	}
}
