using UnityEngine;
using System.Collections;

public class setPlayers : MonoBehaviour {

	[SerializeField] public GameObject playerPrefab;
	[SerializeField] public GameObject player1;
	[SerializeField] public GameObject player2;

	// Use this for initialization
	void Start () 
	{
		player1 = (GameObject) Instantiate (playerPrefab, new Vector3 (-5, 0, 0), Quaternion.identity);
		//player1.tag = "player1";
		player1.GetComponent<stats>().hp = 3;
		player1.GetComponent<stats>().atk = 3;
		player1.GetComponent<stats>().movP = 3;
		Debug.Log (GameObject.FindWithTag ("player1").transform.position.x);
		Debug.Log (player1.tag);
		player2 = (GameObject) Instantiate (playerPrefab, new Vector3 (5, 0, 0), Quaternion.identity);
		//player2.tag = "player2";
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
