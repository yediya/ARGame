using UnityEngine;
using System;
using System.Collections;

public class UT_stabilise: MonoBehaviour{

	int lockPos= 0;
	Transform oldTrans;

	// Use this for initialization
	void Start(){
		//Save original position
		oldTrans= transform;
	}
	
	// Update is called once per frame
	void Update(){
		Vector3 pos = transform.position;
		Vector3 oldPos = oldTrans.position;
		float rotX = transform.rotation.eulerAngles.x;
		float oldRotX = oldTrans.rotation.eulerAngles.x;
		float rotY = transform.rotation.eulerAngles.y;
		float oldRotY = oldTrans.rotation.eulerAngles.y;
		float rotZ = transform.rotation.eulerAngles.z;
		float oldRotZ = oldTrans.rotation.eulerAngles.z;

		//Lock x and z transforms
		transform.rotation= Quaternion.Euler( lockPos, rotY, lockPos);
		//Y position should always = 0
		transform.position= new Vector3( pos.x, 0, pos.z);

//		float mag = pos.magnitude;
//		float oldMag = oldPos.magnitude;
		//If position or rotation has not changed significantly, keep old one
		if( Math.Abs( oldPos.x- pos.x)< 10 
		 && Math.Abs( oldPos.y- pos.y)< 10
		 && Math.Abs( oldPos.z- pos.z)< 10){
			pos= oldPos;
		}
		if( Math.Abs( rotX- oldRotX)< 180
		 && Math.Abs( rotY- oldRotY)< 180
		 && Math.Abs( rotZ- oldRotZ)< 180){
			rotX= oldRotX;
			rotY= oldRotY;
			rotZ= oldRotZ;
		}

		oldTrans= transform;


	}
}
