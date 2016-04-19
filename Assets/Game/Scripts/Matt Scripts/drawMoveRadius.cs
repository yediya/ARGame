using UnityEngine;
using System.Collections;

public class drawMoveRadius : MonoBehaviour 
{
	public float ThetaScale = 0.01f;
	//radius it the amount of movement points
	public float radius;
	private int sizes;
	private LineRenderer[] lines;
	private LineRenderer LineDrawer;
	private float Theta = 0f;

	public Vector3 initPos;
	public float initMovP;
	
	void Start ()
	{       
		LineDrawer = GetComponent<LineRenderer>();
	}
	
	void Update ()
	{   
		//This is the decreasing circle around the player
		radius = this.transform.parent.GetComponent<stats> ().movP;
		if(radius > 0 )
		{
			drawCharCircle ();
		}
		else
		{
			LineDrawer.SetVertexCount (0);
		}
	}

	void drawCharCircle ()
	{
		LineDrawer.SetWidth (0.1f, 0.1f);
		Vector3 pos = this.transform.parent.transform.position;

		//Vector3 pos = this.transform.parent.transform.position;
		Color red = new Color (1, 0, 0, 0);
		LineDrawer.SetColors (red, red);
		Theta = 0f;
		sizes = (int)((1f / ThetaScale) + 1f);
		LineDrawer.SetVertexCount (sizes); 
		for (int i = 0; i < sizes; i++) 
		{          
			Theta += (2.0f * Mathf.PI * ThetaScale);         
			float x = pos.x + radius * Mathf.Cos (Theta);
			float z = pos.z + radius * Mathf.Sin (Theta);          
			LineDrawer.SetPosition (i, new Vector3 (x, 1, z));
		}
	}
}
