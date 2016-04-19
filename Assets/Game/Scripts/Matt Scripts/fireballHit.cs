using UnityEngine;
using System.Collections;

public class fireballHit : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}

	void OnTriggerEnter(Collider col)
	{
		//all projectile colliding game objects should be tagged "Enemy" or whatever in inspector but that tag must be reflected in the below if conditional
		if (true)
			//col.gameObject.tag == "unit") 
		{
			Debug.Log ("Hit unit");
			Destroy (gameObject);
		}

		Destroy (gameObject);
	}

	void OnCollisionEnter (Collision col)
	{
		Debug.Log ("Hit unit2");
			Destroy(col.gameObject);
	
	}
		
		// Update is called once per frame
	void Update () {
	
	}
}
