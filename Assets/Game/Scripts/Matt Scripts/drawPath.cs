using UnityEngine;
using System.Collections;

public class drawPath : MonoBehaviour {

	public Vector3[] path;

	movement movement;
	private LineRenderer LineDrawer;


	// Use this for initialization
	void Start () 
	{
		//Line renderer for drawing the path
		LineDrawer = GetComponent<LineRenderer>();
		LineDrawer.SetWidth (0.1f, 0.1f);

		movement = this.transform.parent.GetComponent<movement> ();

	}
	
	// Update is called once per frame
	void Update () 
	{
		//Draw the path we have taken so far
		Color red = new Color (1, 0, 0, 0);
		LineDrawer.SetColors (red, red);
		LineDrawer.SetVertexCount (movement.pathLength+1); 
		for (int i = 0; i < movement.pathLength; i++) 
		{                    
			LineDrawer.SetPosition (i, movement.path [i]);
		}

	}
}
