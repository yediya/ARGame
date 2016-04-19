using UnityEngine;
using System.Collections;
using Vuforia;
using UnityEngine.UI;

public class CONTROL_turns: MonoBehaviour{

//	[SerializeField] 
	public int curTurn;
//	[SerializeField] public string curMarker;
	public int curPlayer, prevPlayer;
	public int curUnit, prevUnit;
	public bool changedPlayer, newUnitPlayed;
//	public int oldTurn;
//	public GameObject p1, p2;
	private bool init;
	public bool Player1CanMove, Player2CanMove;
	public static int armyMaxSize= 6;
	public int[] armies_count= new int[ 2];
	public int[,] armies_markers= new int[ 2, armyMaxSize]; // 1D array 1 for player 1, 2 for 2
	public string[,] armies_titles= new string[ 2, armyMaxSize]; // 2D for linked cards eg. army[ 1][ 1]== 13/archer for P1
	
	void Start(){
	//	armies_count[ 0]= 0; armies_count[ 1]= 0;
		for( int i= 0; i< 2; i++){
			for( int j= 0; j< armyMaxSize; j++){
				armies_markers[ i, j]= -1;
				armies_titles[ i, j]= "empty";
			}
			armies_count[ i]= 0;
		}
		curPlayer= prevPlayer= curTurn= 0;
		curUnit= prevUnit= 0;
		changedPlayer= newUnitPlayed= Player1CanMove = Player2CanMove = false;
		init= true;

	}
	
	// Update is called once per frame
	void Update(){
		if( curPlayer== 0); // show all cards on desk as invalid (out of battlefield and turn's)
		else{
//			if( init)
			init= false;
			if( curPlayer== 1&&( curPlayer!= prevPlayer|| prevPlayer== 0)){
				Debug.Log( "PLAYER "+ curPlayer+" TURN: "+ curTurn);
				prevPlayer= curPlayer; changedPlayer= true;
			}
			else if( curPlayer== 2&&( curPlayer!= prevPlayer|| prevPlayer== 0)){
				Debug.Log( "PLAYER "+ curPlayer+" TURN: "+ curTurn);
				prevPlayer= curPlayer; changedPlayer= true;
			}
			else if( !newUnitPlayed&& curUnit!= 0){
				bool newUnit= true; 
				foreach( int num in armies_markers) if( curUnit== num) newUnit= false;
				if( newUnit){
					GameObject marker = GameObject.FindWithTag(curUnit.ToString());
					marker.transform.GetChild(0).GetComponent<stats>().owner = curPlayer;
					Debug.Log( "UNIT "+ curUnit+" FOR PLAYER: "+ curPlayer);
	//				Debug.Log( "ARMY COUNT (should be 0): "+ armies_count[ 0]);
	//				Debug.Log( "ARMY COUNT (should be 1): "+ armies_count[ curPlayer- 1]);
					string type= "WRONG";
					if( curUnit>= 11&& curUnit< 13) type= "fighter";
					else if( curUnit>= 13&& curUnit< 15) type= "archer";
					else if( curUnit>= 15&& curUnit< 17) type= "cavalry";
					armies_titles[ curPlayer- 1, armies_count[ curPlayer- 1]]= type;
					armies_markers[ curPlayer- 1, armies_count[ curPlayer- 1]]= curUnit;
					armies_count[ curPlayer- 1]++;
					prevUnit= curUnit; newUnitPlayed= true;
				}
			}
//			else Debug.Log( "NO TURN CHANGE, PLAYER IS: "+ curPlayer);
		}

		if( changedPlayer){
			Debug.Log( "TurnChangedMOFOS");
			StartCoroutine( "Battle");
			curTurn++;
			changedPlayer= newUnitPlayed= false;
		}
	}

	IEnumerator Battle(){
		if( !init){

			//PLACE THE BATTLE COMPUTATIONS HERE

			yield return new WaitForSeconds( 3);

			if( curTurn == 1){

				Player1CanMove= true;
				Player2CanMove= false;
				Debug.Log( "Player1 can move now");
			}
			if( curTurn == 2){
				Player2CanMove= true;
				Player1CanMove= false;
				Debug.Log( "Player2 can move now");
			}
		}
	}

	void OnGUI(){
		float height= Screen.height- 30f, width= 10f; //Screen.width/ 2- 100f;
//		Debug.Log ( "PLAYER: "+ curPlayer+" - curTurn: "+ curTurn);
		if( curPlayer== 0);
//		if( curPlayer!= 0){
//			if( init){
//				GUI.Label( new Rect( width, height, 400, 40), "TOSS PLAYERS' MARKER"); height-= 20;
//				GUI.Label( new Rect( width, height, 400, 40), "GAME NOT STARTED"); height-= 20;
//			}
		else{
			if( curPlayer== 1) GUI.color= Color.cyan; else GUI.color= Color.red;
			if( armies_titles!= null) for( int i= 0; i< armyMaxSize; i++){
					GUI.Label( new Rect( width, height, 400, 40), 
				          " -"+ armies_titles[ curPlayer- 1, i]+" (M "+ armies_markers[ curPlayer- 1, i]+")");
					height-= 20;
			}
			GUI.Label( new Rect( width, height, 400, 40), "P"+ curPlayer+" ARMY: "); height-= 20;
			height-= 20; GUI.color= Color.white;
			GUI.Label( new Rect( width, height, 400, 40), "PLAYER: "+ curPlayer); height-= 20;
			GUI.Label( new Rect( width, height, 400, 40), "TURN: "+( ( curTurn+ 1)/ 2)); height-= 20;
	//		}
		}
	}
}
