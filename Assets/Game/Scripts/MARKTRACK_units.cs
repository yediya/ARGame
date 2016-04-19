using UnityEngine;
using System.Collections;
using Vuforia;
using UnityEngine.UI;

public class MARKTRACK_units: MonoBehaviour, ITrackableEventHandler{

	private TrackableBehaviour myTrackableBehaviour;
//	private bool turnChange;

	// Use this for initialization
	void Start(){
		myTrackableBehaviour= GetComponent< TrackableBehaviour>();
		if( myTrackableBehaviour) myTrackableBehaviour.RegisterTrackableEventHandler( this);
	}

	public void OnTrackableStateChanged( TrackableBehaviour.Status previousStatus,
		TrackableBehaviour.Status newStatus){
		if( newStatus== TrackableBehaviour.Status.DETECTED
		 || newStatus== TrackableBehaviour.Status.TRACKED
		 || newStatus== TrackableBehaviour.Status.EXTENDED_TRACKED){
//			Debug.Log( "XXXXXXXXXX "+ myTrackableBehaviour.tag);
			GameObject.Find( "GameManager").GetComponent< CONTROL_turns>().curUnit= 
				int.Parse( myTrackableBehaviour.tag);
		}
		else{
			//  When turn target is lost
		}
	}
}
