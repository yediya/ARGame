using UnityEngine;
using System.Collections;

public class Player1 : MonoBehaviour {
	
	[SerializeField] float hp;
	[SerializeField] float mp;
	[SerializeField] float movP;



	// Use this for initialization
	void Start () {

		hp = 30;
		mp = 10;
		movP = 5;
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
