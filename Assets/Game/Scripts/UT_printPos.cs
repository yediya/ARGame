using UnityEngine;
using System.Collections;

public class UT_printPos: MonoBehaviour{
	
	GameObject board;
	GameObject player1;
	GameObject player2;
	
	public float boardx;
	public float play1x;
	public float play2x;
	public float boardy;
	public float play1y;
	public float play2y;
	public float boardz;
	public float play1z;
	public float play2z;
//	Vector3 pos;


	// Use this for initialization
	void Start(){
		board= GameObject.FindWithTag( "board");
		player1= GameObject.FindWithTag( "player1");
		player2= GameObject.FindWithTag( "player2");
	}
	
	// Update is called once per frame
	void Update(){
		play1x= player1.transform.position.x;
		play1y= player1.transform.position.y;
		play1z= player1.transform.position.z;
		play2x= player2.transform.position.x;
		play2y= player2.transform.position.y;
		play2z= player2.transform.position.z;
		boardx= board.transform.position.x;
		boardy= board.transform.position.y;
		boardz= board.transform.position.z;
	}
}
