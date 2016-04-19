using UnityEngine;
using System;
using System.Collections;

public class stabilise : MonoBehaviour {

	int lockPos = 0;
	Transform oldTrans;

	// Use this for initialization
	void Start () {

		//Save original position
		oldTrans = transform;
	
	}
	
	// Update is called once per frame
	void Update () 
	{
		Vector3 pos = transform.position;
		Vector3 oldPos = oldTrans.position;
		float rot = transform.rotation.eulerAngles.y;
		float oldRot = oldTrans.rotation.eulerAngles.y;

		//Lock x and z transforms
		transform.rotation = Quaternion.Euler(lockPos, rot, lockPos);

		//Y position should always = 0
		transform.position = new Vector3 (pos.x, 0, pos.z);

	


		float mag = pos.magnitude;
		float oldMag = oldPos.magnitude;
		//If position or rotation has not changed significantly, keep old one
		if (Math.Abs(oldPos.x - pos.x)<0.1) 
		{
			pos = oldPos;
		}
		if (Math.Abs (rot - oldRot) < 1) 
		{
			rot = oldRot;
		}

		oldTrans = transform;


	}
}
