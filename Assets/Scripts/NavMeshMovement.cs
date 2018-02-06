using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NavMeshMovement : MonoBehaviour
{
	public NavMeshAgent agent;
	public GameObject target;

	private void Update()
	{
		MoveOnNavMesh();
	}

	private void MoveOnNavMesh()
	{
		if (target != null)
		{
			agent.isStopped = false;
			agent.SetDestination(target.transform.position);
		}
	}
}
