using UnityEngine;
using System.Collections;
using Vuforia;

public class modelInstantiator : MonoBehaviour, ITrackableEventHandler 
{
	private TrackableBehaviour mTrackableBehaviour;
	
	public Transform myModelPrefab;

	public Transform myModelTrf;
	
	// Use this for initialization
	void Start ()
	{
		mTrackableBehaviour = GetComponent<TrackableBehaviour>();
		
		if (mTrackableBehaviour)
		{
			mTrackableBehaviour.RegisterTrackableEventHandler(this);
		}
	}
	
	public void OnTrackableStateChanged(
		TrackableBehaviour.Status previousStatus,
		TrackableBehaviour.Status newStatus)
	{
		if (newStatus == TrackableBehaviour.Status.DETECTED ||
		    newStatus == TrackableBehaviour.Status.TRACKED ||
		    newStatus == TrackableBehaviour.Status.EXTENDED_TRACKED)
		{
			OnTrackingFound();
		}
	}
	private void OnTrackingFound()
	{
		if (myModelPrefab != null)
		{
			//On the first time it is found, instantiate the object
			if(myModelTrf == null)
			{
				myModelTrf = GameObject.Instantiate(myModelPrefab) as Transform;
			}

			myModelTrf.parent = mTrackableBehaviour.transform;             
			myModelTrf.localPosition = new Vector3(0f, 0f, 0f);
			myModelTrf.localRotation = Quaternion.identity;
			myModelTrf.localScale = new Vector3(1.0f,0.1f,1.0f);
			
			myModelTrf.gameObject.SetActive(true);
		}
	}
}