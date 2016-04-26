using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class AttackAreaTrigger : MonoBehaviour {

	/* Variables For Battle */
	private List<Collider> targets;
	public bool isEnemyOnRange;

	void Start()
	{
		targets = new List<Collider>();
		isEnemyOnRange = false;
	}

	void OnTriggerEnter(Collider c)
	{
		if (
			//if c is an unit
			c.tag == "unit"
			&&
			//and if c's owner is different than THIS owner
			c.transform.parent.GetComponent<stats>().owner != transform.parent.GetComponent<stats>().owner
		)
		{
			isEnemyOnRange = true;
			Debug.Log ("enter");
			targets.Add(c);
		}
	}

	void OnTriggerExit(Collider c)
	{
		if (
			//if c is an unit
			c.tag == "unit"
			&&
			//and if c's owner is different than THIS owner
			c.transform.parent.GetComponent<stats>().owner != transform.parent.GetComponent<stats>().owner
		)
		{
			isEnemyOnRange = false;
			Debug.Log ("exit");
			targets.Remove(c);
		}
	}

	public void fireAttack()
	{
		/* Temporary : deal damage to all targets */
		int damageAmount = transform.parent.GetComponent<stats> ().atk;
		foreach (Collider t in targets)
		{
			t.transform.parent.GetComponent<stats>().takeDamage(damageAmount);
		}
	}
}
