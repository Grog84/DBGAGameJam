using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NavigationController : MonoBehaviour
{
	public NavMeshAgent agent;
	public Transform currentTarget;
	//private Transform lastTarget;

	public void StartMovement(Transform target)
	{
		if (target != null)
		{
			agent.isStopped = false;
			agent.destination = currentTarget.position;
		}
	}

	public void StopMovement()
	{
		agent.isStopped = true;
	}
}
